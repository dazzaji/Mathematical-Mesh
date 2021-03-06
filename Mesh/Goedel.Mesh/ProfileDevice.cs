﻿using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Protocol;
namespace Goedel.Mesh {

    public partial class Profile {

        /// <summary>
        /// The signed device profile
        /// </summary>
        public virtual DareMessage ProfileSigned { get;  }
        }

    public partial class ProfileDevice {

        public override string _PrimaryKey => UDF;


        public string UDF => DeviceSignatureKey.UDF;

        public byte[] UDFBytes => DeviceSignatureKey.KeyPair.PKIXPublicKey.UDFBytes(512);

        /// <summary>
        /// The signed device profile
        /// </summary>
        public override DareMessage ProfileSigned => ProfileDeviceSigned;

        /// <summary>
        /// The signed device profile
        /// </summary>
        public DareMessage ProfileDeviceSigned { get; private set; }

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ProfileDevice() {
            }

        /// <summary>
        /// Create a new master profile.
        /// </summary>
        /// <param name="AlgorithmSign"></param>
        /// <param name="AlgorithmEncrypt"></param>
        public static ProfileDevice Generate(
                        KeyPair keyPublicSign,
                        KeyPair keyPublicEncrypt,
                        KeyPair keyPublicAuthenticate) {

            var ProfileDevice = new ProfileDevice() {
                DeviceSignatureKey = new PublicKey (keyPublicSign.KeyPairPublic()),
                DeviceAuthenticationKey = new PublicKey(keyPublicAuthenticate.KeyPairPublic()),
                DeviceEncryptionKey = new PublicKey(keyPublicEncrypt.KeyPairPublic())
                };

            var bytes = ProfileDevice.GetBytes(tag:true);

            ProfileDevice.ProfileDeviceSigned = DareMessage.Encode(bytes,
                    signingKey: keyPublicSign, contentType: "application/mmm");

            return ProfileDevice;

            }


        public static ProfileDevice Decode(DareMessage message)=>
            FromJSON(message.GetBodyReader(), true);

        }


    public partial class ProfileMeshDevicePrivate {
        public static ProfileMeshDevicePrivate Decode(DareMessage message) =>
                FromJSON(message.GetBodyReader(), true);
        }

    public partial class ProfileMeshDevicePublic {
        public static ProfileMeshDevicePublic Decode(DareMessage message) =>
                FromJSON(message.GetBodyReader(), true);
        }


    }
