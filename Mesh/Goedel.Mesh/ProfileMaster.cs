﻿using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Protocol;

namespace Goedel.Mesh {
    public partial class ProfileMaster {

        public string UDF => MasterSignatureKey.UDF;
        public byte[] UDFBytes => MasterSignatureKey.KeyPair.PKIXPublicKey.UDFBytes(512);

        public override string _PrimaryKey => MasterSignatureKey.UDF;


        /// <summary>
        /// The signed device profile
        /// </summary>
        public override DareMessage ProfileSigned => ProfileMasterSigned;

        /// <summary>
        /// The signed device profile
        /// </summary>
        public DareMessage ProfileMasterSigned { get; private set; }

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ProfileMaster() {
            }

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ProfileMaster(DareMessage dareMessage) {
            }

        /// <summary>
        /// Create a new master profile.
        /// </summary>
        /// <param name="algorithmSign"></param>
        /// <param name="algorithmEncrypt"></param>
        public static ProfileMaster Generate(
                        ProfileDevice profileDevice,
                        KeyPair keyPublicSign,
                        KeyPair keyPublicEncrypt) {

            List<PublicKey> masterEscrowKeys=null;
            if (keyPublicEncrypt != null) {
                masterEscrowKeys = new List<PublicKey> {
                    new PublicKey(keyPublicEncrypt.KeyPairPublic()) };
                }

            var profileMaster = new ProfileMaster() {
                MasterSignatureKey = new PublicKey(keyPublicSign.KeyPairPublic()),
                MasterEscrowKeys = masterEscrowKeys
                };
            profileMaster.Add(profileDevice);

            var bytes = profileMaster.GetBytes(tag: true);

            profileMaster.ProfileMasterSigned = DareMessage.Encode(bytes,
                    signingKey: keyPublicSign, contentType: "application/mmm");
            return profileMaster;
            }


        public void Add(ProfileDevice profileDevice) {
            OnlineSignatureKeys = OnlineSignatureKeys ?? new List<PublicKey>();
            OnlineSignatureKeys.Add(profileDevice.DeviceSignatureKey);
            }

        public bool IsAdministrator(string UDF) {
            Assert.NotNull(OnlineSignatureKeys, InvalidProfile.Throw);

            foreach (var admin in OnlineSignatureKeys) {
                if (admin.UDF == UDF) {
                    return true;
                    }
                }
            return false;
            }


        public static ProfileMaster Decode(DareMessage message) {
            var result = FromJSON(message.GetBodyReader(), true);
            result.ProfileMasterSigned = message;
            return result;
            }
        }

    }
