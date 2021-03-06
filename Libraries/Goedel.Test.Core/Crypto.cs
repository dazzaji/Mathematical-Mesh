﻿using System;
using System.Threading;
using System.Collections.Generic;
using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Core;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;
using Goedel.Cryptography.PKIX;

namespace Goedel.Test.Core {

    public class CryptoStackDebug : CryptoStack {
        byte[] ThisSalt;
        public byte[] KeyEncrypt;
        public byte[] KeyMac;
        public byte[] IV;

        /// <summary>
        /// Create a CryptoStack instance to encode data with the specified cryptographic
        /// parameters.
        /// </summary>
        public CryptoStackDebug(
                        CryptoParameters cryptoParameters
                        ) : base(cryptoParameters) {
            CalculateParameters(Salt, out KeyEncrypt, out KeyMac, out IV);
            }

        /// <summary>
        /// Add a recipient.
        /// </summary>
        /// <param name="MasterKey"></param>
        /// <param name="EncryptionKey"></param>
        public override void MakeRecipient(byte[] MasterKey, KeyPair EncryptionKey) =>
                Recipients.Add(new DareRecipientDebug(MasterSecret, EncryptionKey));
        }


    public class DareRecipientDebug : DareRecipient {

        public Key EphemeralPrivate;

        public byte[] KeyAgreement;

        public byte[] EncryptionKey;

        /// <summary>
        /// Create a DARERecipient using the specified cryptographic parameters.
        /// </summary>
        /// <param name="MasterKey">The master key</param>
        /// <param name="PublicKey">The recipient public key.</param>
        /// <returns>The recipient informatin object.</returns>
        public DareRecipientDebug(byte[] MasterKey, KeyPair PublicKey) {

            var Secret = Platform.GetRandomBytes(32);
            var PrivateKey = new CurveEdwards25519Private();
            var Ephemeralpublic = PrivateKey.PublicKey;
            var PKIXPublicKeyECDH = new PKIXPublicKeyEd25519(Ephemeralpublic.Encoding);
            var PKIXPrivateKeyECDH = new PKIXPrivateKeyEd25519(Secret, PKIXPublicKeyECDH);
            EphemeralPrivate = new PrivateKeyECDH(PKIXPrivateKeyECDH);

            var PublicKeyEd = PublicKey as KeyPairEd25519;

            var result = new CurveEdwards25519Result() {
                EphemeralPublicValue = PrivateKey.PublicKey,
                Agreement = PrivateKey.Agreement(PublicKeyEd.IKeyAdvancedPublic as CurveEdwards25519Public)
                };

            EncryptionKey = result.KeyDerive.Derive(KDFSalt, Length: 256);
            KeyAgreement = result.IKM;

            var exchange = Platform.KeyWrapRFC3394.Wrap(EncryptionKey, MasterKey);

            var JoseKey = Key.GetPublic(result.EphemeralKeyPair);

            KeyIdentifier = PublicKey.UDF;
            Epk = JoseKey;
            WrappedMasterKey = exchange;
            }
        }

    public class CryptoParametersTest : CryptoParameters {


        public CryptoParametersTest(
                    List<string> Recipients = null,
                    List<string> Signers = null,
                    CryptoAlgorithmID EncryptID = CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID DigestID = CryptoAlgorithmID.NULL) :
            base(new KeyCollectionCore(), Recipients, Signers, EncryptID, DigestID) {
            }

        protected override void AddEncrypt(string AccountId) => AddEncrypt(AccountId, true);

        public void AddEncrypt(string AccountId, bool Register = true) {
            EncryptionKeys = EncryptionKeys ?? new List<KeyPair>();

            var Keypair = new KeyPairDH();
            var Pub = Keypair.KeyPairPublic();
            var PublicKeyKeypair = Keypair.KeyPairPublic();
            EncryptionKeys.Add(PublicKeyKeypair);

            Console.WriteLine($"Keypair is {Keypair.UDF}");
            Console.WriteLine($"  Public {Keypair.PKIXPublicKeyDH}");
            Console.WriteLine($"  Public {PublicKeyKeypair.UDF}");

            if (Register) {
                KeyCollection.Add(Keypair);
                }

            }

        protected override void AddSign(string AccountId) => AddSign(AccountId, true);
        public void AddSign(string AccountId, bool Register) {
            SignerKeys = SignerKeys ?? new List<KeyPair>();

            var Keypair = KeyPair.KeyPairFactoryRSA(keyType: KeySecurity.Ephemeral);
            var PublicKeyKeypair = Keypair.KeyPairPublic();
            SignerKeys.Add(Keypair);

            //Console.WriteLine($"Keypair is {Keypair.UDF}");
            //Console.WriteLine($"  Public {PublicKeyKeypair.UDF}");

            if (Register) {
                KeyCollection.Add(Keypair);
                }
            }

        }



    public class TestKeys {

        KeyCollection KeyCollection;

        public List<KeyPair> EncryptionKeys;
        public List<KeyPair> SignerKeys;

        public TestKeys(KeyCollection KeyCollection = null) => this.KeyCollection = KeyCollection ?? KeyCollection.Default;

        public void AddEncrypt(bool Register = true) {
            EncryptionKeys = EncryptionKeys ?? new List<KeyPair>();

            var Keypair = new KeyPairDH();
            var Public = Keypair.PKIXPublicKeyDH;
            var PublicKeyKeypair = KeyPairDH.KeyPairPublicFactory(Public);
            EncryptionKeys.Add(PublicKeyKeypair);

            //Console.WriteLine($"Keypair is {Keypair.UDF}");
            //Console.WriteLine($"  Public {Keypair.PKIXPublicKeyDH}");
            //Console.WriteLine($"  Public {PublicKeyKeypair.UDF}");

            if (Register) {
                KeyCollection.Default.Add(Keypair);
                }
            }

        public void AddSign(bool Register = true) {
            SignerKeys = SignerKeys ?? new List<KeyPair>();

            throw new NYI();
            }
        }

    }
