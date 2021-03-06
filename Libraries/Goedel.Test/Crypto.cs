﻿using System;
using System.Threading;
using System.Collections.Generic;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Cryptography;
using Goedel.Cryptography.Core;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;
using Goedel.Cryptography.Algorithms;

namespace Goedel.Test {


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

            //Console.WriteLine($"Keypair is {Keypair.UDF}");
            //Console.WriteLine($"  Public {Keypair.PKIXPublicKeyDH}");
            //Console.WriteLine($"  Public {PublicKeyKeypair.UDF}");

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


    //public static class Crypto {

    //    static int IDCount = 0;
    //    public static string MakeUnique(this string Base) {
    //        var Count = Interlocked.Increment(ref IDCount);
    //        var Split = Base.Split('@');

    //        return Split[0] + "_" + Count.ToString() + "@" + Split[1];
    //        }


    //    static Crypto() {
    //        }

    //    //public const string TestString = "This is a test";

    //    public static void Test_EncryptDecrypt(this KeyPair KeyPair) {

    //        var Key = Platform.GetRandomBits(256);

    //        KeyPair.Encrypt(Key, out var Exchange, out var Ephemeral);
    //        var Result = KeyPair.Decrypt(Exchange, Ephemeral);

    //        UT.Assert.IsTrue(Key.IsEqualTo (Result));

    //        }


    //    public static void Test_Lifecycle(this CryptoAlgorithmID CryptoAlgorithmID, int KeySize = 2048) {
    //        Test_LifecycleMaster(CryptoAlgorithmID, KeySize);
    //        Test_LifecycleAdmin(CryptoAlgorithmID, KeySize);
    //        Test_LifecycleDevice(CryptoAlgorithmID, KeySize);
    //        Test_LifecycleEphemeral(CryptoAlgorithmID, KeySize);
    //        Test_LifecycleExportable(CryptoAlgorithmID, KeySize);
    //        }



    //    public static void Test_LifecycleMaster(this CryptoAlgorithmID CryptoAlgorithmID, int KeySize = 2048) {
    //        var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.Master, KeySize:KeySize);
    //        Encrypter.Test_EncryptDecrypt();
    //        var UDF = Encrypter.UDF;

    //        ExportPrivate(UDF, true);
    //        CheckPersisted(UDF, true);


    //        }

    //    public static void Test_LifecycleAdmin(this CryptoAlgorithmID CryptoAlgorithmID, int KeySize = 2048) {
    //        var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.Admin, KeySize: KeySize);
    //        Encrypter.Test_EncryptDecrypt();
    //        var UDF = Encrypter.UDF;

    //        ExportPrivate(UDF, false);
    //        CheckPersisted(UDF, true);
    //        }



    //    public static void Test_LifecycleDevice(this CryptoAlgorithmID CryptoAlgorithmID, int KeySize = 2048) {
    //        var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.Device, KeySize: KeySize);
    //        Encrypter.Test_EncryptDecrypt();
    //        var UDF = Encrypter.UDF;

    //        ExportPrivate(UDF, false);
    //        CheckPersisted(UDF, true);
    //        }


    //    /// <summary>Test for lifecycle of ephemeral key. Key can be created and used but FindLocal
    //    /// fails as the key is never written to the local store</summary>
    //    /// <param name="CryptoAlgorithmID"></param>
    //    public static void Test_LifecycleEphemeral(this CryptoAlgorithmID CryptoAlgorithmID, int KeySize = 2048) {
    //        var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.Ephemeral, KeySize: KeySize);
    //        Encrypter.Test_EncryptDecrypt();
    //        var UDF = Encrypter.UDF;

    //        CheckPersisted(UDF, false);

    //        IPKIXPrivateKey Private = null;
    //        try {
    //            Private = Encrypter.PKIXPrivateKey;
    //            UT.Assert.Fail();
    //            }
    //        catch (NotExportable) {
    //            UT.Assert.IsNull(Private);
    //            }

            
    //        }

    //    /// <summary>Test for lifecycle of ephemeral key. Key can be created and used but FindLocal
    //    /// fails as the key is never written to the local store</summary>
    //    /// <param name="CryptoAlgorithmID"></param>
    //    public static void Test_LifecycleExportable(this CryptoAlgorithmID CryptoAlgorithmID, int KeySize=2048) {
    //        //var Encrypter = CryptoCatalog.Default.GetExchange(CryptoAlgorithmID);
    //        //Encrypter.Generate(KeySecurity.Exportable, KeySize: 2048);


    //        var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.Exportable, KeySize: KeySize);


    //        Encrypter.Test_EncryptDecrypt();
    //        var UDF = Encrypter.UDF;

    //        CheckPersisted(UDF, false);
    //        var Private = Encrypter.PKIXPrivateKey;
    //        UT.Assert.IsNotNull(Private);
    //        }



    //    /// <summary>
    //    /// Check persistence of the key, that it can be found in the local store and
    //    /// then that it cannot be found after deletion.
    //    /// </summary>
    //    /// <param name="UDF"></param>
    //    static void CheckPersisted(string UDF, bool Succeed) {
    //        var Encrypter2 = KeyPair.FindLocal(UDF);

    //        if (!Succeed) {
    //            UT.Assert.IsNull(Encrypter2);
    //            return; // No more testing possible
    //            }

    //        UT.Assert.IsNotNull(Encrypter2);
    //        Encrypter2.Test_EncryptDecrypt();

    //        Encrypter2.EraseFromDevice();

    //        var Encrypter3 = KeyPair.FindLocal(UDF);
    //        UT.Assert.IsNull(Encrypter3);
    //        }


    //    static void ExportPrivate(string UDF, bool Succeed) {
    //        try {
    //            var Encrypter2 = KeyPair.FindLocal(UDF);
    //            var Private = Encrypter2.PKIXPrivateKey;
    //            UT.Assert.IsTrue(Succeed);
    //            }

    //        catch (NotExportable) {
    //            UT.Assert.IsFalse(Succeed);
    //            }
    //        }


    //    }
    }
