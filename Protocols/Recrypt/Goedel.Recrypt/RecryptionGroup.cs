﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Mesh;
using Goedel.Protocol;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;

namespace Goedel.Recrypt {
    public partial class RecryptionGroup {
        
        /// <summary>The recryption service provider.</summary>
        public CryptoProviderRecryption RecryptionProvider;
        
        /// <summary>The recryption key pair.</summary>
        public PublicKey RecryptionKeyPair;

        /// <summary>
        /// Initialize a newly created Recryption group.
        /// </summary>
        /// <param name="DeviceProfile">Initial device profile.</param>
        public void Generate (DeviceProfile DeviceProfile) {
            Master = new MasterProfile(CryptoCatalog.Default);

            RecryptionProvider = new CryptoProviderExchangeDH(KeySecurity: KeySecurity.Application);
            RecryptionKeyPair = new PublicKey(RecryptionProvider.KeyPair);


            var EncryptionKey = new PublicKey() {
                PublicParameters = RecryptionKeyPair.PublicParameters
                };

            var WrappedEncryptionKey = new RecryptionKey() {
                EncryptionKey = EncryptionKey
                };

            CurrentEncryptionKey = new JoseWebSignature(WrappedEncryptionKey, SigningKey: Master.AdministrationKey);

            }

        /// <summary>Get the current encryption key.</summary>
        public KeyPair ValidatedCurrentEncryptionKey  => GetValidatedCurrentEncryptionKey(); 

        KeyPair _ValidatedCurrentEncryptionKey;
        KeyPair GetValidatedCurrentEncryptionKey () {
            if (_ValidatedCurrentEncryptionKey == null) {


                // NYI check the signature chain on current encryption key

                var Key = RecryptionKey.FromJSON(CurrentEncryptionKey.Payload.JSONReader());
                _ValidatedCurrentEncryptionKey = Key.EncryptionKey.KeyPair;
                }
            return _ValidatedCurrentEncryptionKey;
            }

        /// <summary>
        /// Add member to the recryption group.
        /// </summary>
        /// <param name="Personal">Member's personal profile.</param>
        /// <param name="Recrypt">Member's recryption profile.</param>
        /// <returns>The new member</returns>
        public MemberEntry AddMember (PersonalProfile Personal, RecryptProfile Recrypt) {
            Members = Members ?? new List<MemberEntry>();


            var GroupPrivate = GetGroupPrivate();

            var MemberEntry = new MemberEntry() {
                UDF = Personal.UDF,
                RecryptUDF = Recrypt.Identifier,
                Status = "Active",
                Entries = new List<UserDecryptionEntry>()
                };




            foreach (var EncryptKey in Recrypt.EncryptKeys) {
                MemberEntry.Entries.Add(MakeUserDecryptionEntry(GroupPrivate, EncryptKey));
                }

            Members.Add(MemberEntry);
            return MemberEntry;
            }


        KeyPair GetGroupPrivate () {
            if (RecryptionKeyPair != null) {
                return RecryptionKeyPair.KeyPair;
                }

            return KeyPair.FindLocal(ValidatedCurrentEncryptionKey.UDF);
            }


        /// <summary>
        /// Create a decryption entry for the specified member.
        /// </summary>
        /// <param name="GroupPrivate">The group private key</param>
        /// <param name="EncryptKey">The member's encryption key</param>
        /// <returns>The user decryption data</returns>
        public UserDecryptionEntry MakeUserDecryptionEntry (KeyPair GroupPrivate, PublicKey EncryptKey) {
            var RecryptionProvider = new CryptoProviderExchangeDH(GroupPrivate);

            RecryptionProvider.GenerateRecryptionPair(out var Recryption, out var Completion);
            var RecryptionKey = Key.FactoryPrivate(Recryption);
            var CompletionKey = Key.FactoryPrivate(Completion);

            var RecryptionBlob = new JoseWebEncryption(
                    CompletionKey, EncryptionKey: EncryptKey.KeyPair);

            return new UserDecryptionEntry() {
                EncryptionKeyUDF = GroupPrivate.UDF,
                MemberKeyUDF = EncryptKey.PublicParameters.Kid,
                DecryptionKey = RecryptionBlob,
                RecryptionKey = RecryptionKey
                };
            }


        //public PublicKey EncryptionKey { get => GetEncryptionKey(); }

        PublicKey GetEncryptionKey () {

            var Keydata = RecryptionKey.FromJSON(CurrentEncryptionKey.Payload.JSONReader());
            var Result = Keydata.EncryptionKey;

            return Result;
            }
        }


    public partial class RecryptionKey {
        
        /// <summary>
        /// Get encryption key from signed data.
        /// </summary>
        /// <param name="SignedRecryptionKey">The signed recryption key.</param>
        /// <returns>The recryption key.</returns>
        public static PublicKey GetEncryptionKey (JoseWebSignature SignedRecryptionKey) {

            var Keydata = FromJSON(SignedRecryptionKey.Payload.JSONReader());
            return Keydata.EncryptionKey;
            }
        }
    }
