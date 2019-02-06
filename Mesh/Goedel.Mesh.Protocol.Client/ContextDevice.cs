﻿using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Protocol;

namespace Goedel.Mesh.Protocol.Client {

    /// <summary>
    /// Class that represents a device's view of the current state of a
    /// Mesh profile
    /// </summary>
    public partial class ContextDevice : Disposable {

        public Dictionary<string, Store> DictionaryStores = new Dictionary<string, Store>();
        protected override void Disposing() {

            foreach (var entry in DictionaryStores) {
                entry.Value.Dispose();
                }
            }


        ///<summary>The Machine context</summary>
        public virtual IMeshMachine MeshMachine { get; }

        ///<summary>The active profile. A client may have multiple profiles open at once on the
        ///same device but each one must be accessed through a different context.</summary>
        public ProfileMesh ProfileMesh;

        ///<summary>The active client connection to the service.</summary>
        protected MeshService MeshService;

        protected MeshClientSession MeshClientSession => meshClientSession ??
            new MeshClientSession(this).CacheValue(out meshClientSession);
        MeshClientSession meshClientSession;

        ///<summary>If true, the associated device profile is the default</summary>
        public bool DefaultDevice;

        ///<summary>If true, the associated personal profile is the default</summary>
        public bool DefaultPersonal;

        ///<summary>The account name</summary>
        protected string AccountName => ProfileMesh.Account;

        ///<summary>The device profile</summary>
        public virtual ProfileDevice ProfileDevice { get; }

        DareMessage ProfileDeviceSigned => ProfileDevice.ProfileDeviceSigned;

        ///<summary>The active KeyCollection (from Machine)</summary>
        public KeyCollection KeyCollection => MeshMachine.KeyCollection;

        #region // Convenience properties for accessing default stores and spools.
        //public CatalogCredential CatalogCredential =>
        //    (catalogCredential ?? GetStore(CatalogCredential.Factory, CatalogCredential.Label).CacheValue(out catalogCredential)) as CatalogCredential;
        //Store catalogCredential;

        public CatalogDevice CatalogDevice =>
            (catalogDevice ?? GetStore(CatalogDevice.Label).CacheValue(out catalogDevice)) as CatalogDevice;
        Store catalogDevice = null;

        public CatalogContact CatalogContact =>
            (catalogContact ?? GetStore(CatalogContact.Label).CacheValue(out catalogContact)) as CatalogContact;
        Store catalogContact;

        public CatalogApplication CatalogApplication =>
            (catalogApplication ?? GetStore(CatalogApplication.Label).CacheValue(out catalogApplication)) as CatalogApplication;
        Store catalogApplication;



        public CatalogBookmark GetCatalogBookmark() =>
            GetStore(CatalogBookmark.Label) as CatalogBookmark;

        public CatalogCredential GetCatalogCredential() =>
            GetStore(CatalogCredential.Label) as CatalogCredential;

        public CatalogContact GetCatalogContact() =>
            GetStore(CatalogContact.Label) as CatalogContact;

        public CatalogCalendar GetCatalogCalendar() =>
            GetStore(CatalogCalendar.Label) as CatalogCalendar;

        public CatalogDevice GetCatalogDevice() =>
            GetStore(CatalogDevice.Label) as CatalogDevice;

        public CatalogApplication GetCatalogApplication() =>
            GetStore(CatalogApplication.Label) as CatalogApplication;

        public CatalogNetwork GetCatalogNetwork() =>
            GetStore(CatalogNetwork.Label) as CatalogNetwork;



        public Spool SpoolInbound =>
            (spoolInbound ?? GetStore(Spool.SpoolInbound).CacheValue(out spoolInbound)) as Spool;
        Store spoolInbound;

        public Spool Outbound =>
            (spoolOutbound ?? GetStore(Spool.SpoolOutbound).CacheValue(out spoolOutbound)) as Spool;
        Store spoolOutbound;
        #endregion
        #region // Convenience properties for accessing private keys.
        KeyPair KeySign => keySign ?? KeyCollection.LocatePrivate(ProfileDevice.DeviceSignatureKey.UDF).CacheValue(out keySign);
        KeyPair keySign;

        KeyPair KeyEncrypt => keyEncrypt ?? KeyCollection.LocatePrivate(ProfileDevice.DeviceEncryptionKey.UDF).CacheValue(out keyEncrypt);
        KeyPair keyEncrypt;

        KeyPair KeyAuthenticate => keyAuthenticate ?? KeyCollection.LocatePrivate(ProfileDevice.DeviceAuthenticationKey.UDF).CacheValue(out keyAuthenticate);
        KeyPair keyAuthenticate;
        #endregion

        public ContextDevice(IMeshMachine machine, ProfileDevice profileDevice,
                    KeyPair keySign = null, KeyPair keyEncrypt = null, KeyPair keyAuthenticate = null) {
            MeshMachine = machine;
            ProfileDevice = profileDevice;
            this.keySign = keySign;
            this.keyEncrypt = keyEncrypt;
            this.keyAuthenticate = keyAuthenticate;
            }

        /// <summary>
        /// Construct a context connecting to an existing profile.
        /// </summary>
        /// <param name="machine">The Machine context in which the account data is stored.</param>
        /// <param name="accountName">Select profile by account name.</param>
        /// <param name="deviceUDF">Select profile by device profile.</param>
        public ContextDevice(
                    IMeshMachine machine,
                    string accountName = null,
                    string deviceUDF = null) {
            MeshMachine = machine;
            ProfileMesh = MeshMachine.GetConnection(accountName, deviceUDF);
            }

        public ContextDevice(
                    IMeshMachine machine,
                    ProfileMesh profileMesh,
                    ProfileDevice profileDevice) : this(machine, profileDevice) => ProfileMesh = profileMesh;

        /// <summary>
        /// Generate a new device profile and register to the specified account.
        /// </summary>
        /// <param name="machine">The Machine context to which the account data is to be stored.</param>
        /// <param name="algorithmSign">The signature algorithm.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm.</param>
        /// <param name="algorithmAuthenticate">The authenticaton algorithm.</param>
        /// <returns>The newly created context.</returns>
        public static ContextDevice Generate(
                    IMeshMachine machine = null,
                    CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default,
                    string description = null) {

            machine = machine ?? Mesh.MeshMachine.GetMachine();
            var KeyCollection = machine.KeyCollection;

            algorithmSign = algorithmSign.DefaultMeta(CryptoAlgorithmID.Ed448);
            algorithmEncrypt = algorithmEncrypt.DefaultMeta(CryptoAlgorithmID.Ed448);
            algorithmAuthenticate = algorithmAuthenticate.DefaultMeta(CryptoAlgorithmID.Ed448);

            // Create the key set. 
            var keySign = KeyPair.Factory(algorithmSign, KeySecurity.Device, KeyCollection, keyUses: KeyUses.Sign);
            var keyEncrypt = KeyPair.Factory(algorithmEncrypt, KeySecurity.Device, KeyCollection, keyUses: KeyUses.Encrypt);
            var keyAuthenticate = KeyPair.Factory(algorithmAuthenticate, KeySecurity.Device, keyUses: KeyUses.Encrypt);

            // Generate the profile
            var Profile = Mesh.ProfileDevice.Generate(keySign, keyEncrypt, keyAuthenticate);
            Profile.Description = description;

            // Register the profile locally
            machine.Register(Profile);

            return new ContextDevice(machine, Profile, keySign, keyEncrypt, keyAuthenticate);

            }

        /// <summary>
        /// Generate a new Master profile.
        /// </summary>
        /// <param name="algorithmSign"></param>
        /// <param name="algorithmEncrypt"></param>
        /// <returns></returns>
        public ContextMaster GenerateMaster(
            CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
            CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {

            algorithmSign = algorithmSign.DefaultMeta(CryptoAlgorithmID.Ed448);
            algorithmEncrypt = algorithmEncrypt.DefaultMeta(CryptoAlgorithmID.Ed448);

            var keySign = KeyPair.Factory(algorithmSign, KeySecurity.Master, KeyCollection, keyUses: KeyUses.Sign);
            var keyEncrypt = KeyPair.Factory(algorithmEncrypt, KeySecurity.Master, KeyCollection, keyUses: KeyUses.Encrypt);


            var Profile = Mesh.ProfileMaster.Generate(ProfileDevice, keySign, keyEncrypt);


            // Register the profile locally
            MeshMachine.Register(Profile);
            return new ContextMaster(this, Profile);



            }


        public static ContextDevice GetContextDevice(
                    IMeshMachine machine,
                    string deviceUDF,
                    string deviceID) {
            throw new NYI();
            }


        public ProfileMaster Recover(DareMessage escrow, IEnumerable<string> shares) {
            var secret = new Secret(shares);
            return Recover(escrow, secret);
            }

        public ProfileMaster Recover(DareMessage escrow, KeyShare[] shares) {
            var secret = new Secret(shares);
            return Recover(escrow, secret);
            }

        public ProfileMaster Recover(DareMessage escrow, Secret secret) {


            var cryptoStack = new CryptoStack(secret, CryptoAlgorithmID.AES256CBC) {
                Salt = escrow.Header.Salt
                };
            var Decrypted = cryptoStack.DecodeBody(escrow.Body);

            var escrowedKeySet = EscrowedKeySet.FromJSON(Decrypted.JSONReader(), true);

            var masterSignatureKey = escrowedKeySet.MasterSignatureKey.GetKeyPair(KeySecurity.Exportable);
            var profileMaster = ProfileMaster.Generate(ProfileDevice, masterSignatureKey,
                null);

            return profileMaster;
            }


        public void Add(MeshMessageComplete completion, string catalogID = null, CatalogEntry entry = null) {

            completion.MessageID = completion.MessageID ?? UDF.Random(200);

            var message = DareMessage.Encode(completion.GetBytes());

            var uploadRequest = new UploadRequest() {
                Account = AccountName,
                Self = new List<DareMessage> { message }
                };

            DareMessage catalogEntry = null;
            Catalog catalog = null;

            if (catalogID != null) {
                catalog = GetStore(catalogID) as Catalog;
                catalogEntry = catalog.ContainerEntry(entry, ContainerPersistenceStore.EventNew);
                var update = new ContainerUpdate() {
                    Container = catalogID,
                    Message = new List<DareMessage> { catalogEntry }
                    };
                uploadRequest.Updates = new List<ContainerUpdate> { update };
                }

            var result = MeshService.Upload(uploadRequest, MeshClientSession);

            if (result.Success()) {
                if (catalog != null) {
                    catalog.AppendDirect(catalogEntry);
                    }
                }
            }

        /// <summary>
        /// Return catalog or container by name, using the cached value if it exists or opening it otherwise.
        /// </summary>
        /// <param name="storeFactoryDelegate">The store creation delegate</param>
        /// <param name="name">The catalog or spool name.</param>
        /// <returns>The opened store.</returns>
        public Store GetStore(string name) {

            if (DictionaryStores.TryGetValue(name, out var store)) {
                return store;
                }
            store = MakeStore(name);
            DictionaryStores.Add(name, store);

            return store;
            }

        Store MakeStore(string name) {

            switch (name) {
                case Spool.SpoolInbound: return new Spool(MeshMachine.DirectoryMesh, name, null, KeyCollection);
                case Spool.SpoolOutbound: return new Spool(MeshMachine.DirectoryMesh, name, null, KeyCollection);
                case Spool.SpoolArchive: return new Spool(MeshMachine.DirectoryMesh, name, null, KeyCollection);

                case CatalogCredential.Label: return new CatalogCredential(MeshMachine.DirectoryMesh, name, null, KeyCollection);
                case CatalogDevice.Label: return new CatalogDevice(MeshMachine.DirectoryMesh, name, null, KeyCollection);
                case CatalogContact.Label: return new CatalogContact(MeshMachine.DirectoryMesh, name, null, KeyCollection);
                case CatalogCalendar.Label: return new CatalogCalendar(MeshMachine.DirectoryMesh, name, null, KeyCollection);
                case CatalogBookmark.Label: return new CatalogBookmark(MeshMachine.DirectoryMesh, name, null, KeyCollection);
                case CatalogNetwork.Label: return new CatalogNetwork(MeshMachine.DirectoryMesh, name, null, KeyCollection);


                case CatalogApplication.Label: return new CatalogApplication(MeshMachine.DirectoryMesh, name, null, KeyCollection);

                }

            throw new NYI();
            }


        public DareMessage SignContact(string recipient, Contact contact) {
            var signedContact = DareMessage.Encode(contact.GetBytes(tag: true),
                    signingKey: KeySign, contentType: "application/mmm");

            var request = new MessageContactRequest() {
                Contact = signedContact,
                Recipient = recipient
                };

            return Sign(request);
            }

        protected DareMessage Sign(JSONObject data) =>
                    DareMessage.Encode(data.GetBytes(tag: true),
                        signingKey: KeySign, contentType: "application/mmm");

        public virtual void ProcessConnectionRequest(
                    MessageConnectionRequest messageConnectionRequest,
                    bool accept) {

            throw new NotAdministrator();
            }

        public void ProcessContactRequest(
                    MessageContactRequest messageContactRequest,
                    bool Accept) {
            if (!Accept) {
                // here decide if we are going to send a rejection notice

                // if sending notification, do so.
                throw new NYI();
                }

            var contact = messageContactRequest.Contact;

            CatalogContact.Add(contact);
            }

        public void ProcessConfirmationRequest(
                    MessageConfirmationRequest messageConfirmationRequest,
                    bool accept) {
            var result = ConfirmationResponse(
                messageConfirmationRequest, accept);
            }




        }

    }
