﻿//   Copyright © 2015 by Comodo Group Inc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
//  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Goedel.Cryptography;
using GCP=Goedel.Cryptography.PKIX;

namespace Goedel.Platform {

    /// <summary>
    /// Interface to the Windows certificate store. Channel all platform 
    /// dependent code through this.
    /// </summary>
    public partial class WindowsCertificateStore : CertificateStore {


        /// <summary>
        /// Initialization for certificate store interface class.
        /// </summary>
        public static void Initialize() {
            PlatformRegister = Register;
            PlatformRegisterTrustedRoot = RegisterTrustedRoot;
            PlatformRegisterTrustedRootByte = RegisterTrustedRoot;
            PlatformGet = Get;
            PlatformClean = Clean;
            }

        const string TestStore = "TestStore";

        /// <summary>
        /// Convert the specified Cryptography Certificate to a .Net X509Certificate2 object
        /// </summary>
        /// <param name="Certificate">The certificate to convert.</param>
        /// <returns>The .Net X509Certificate2 object</returns>
        static X509Certificate2 X509Certificate2(GCP.Certificate Certificate) {
            return new X509Certificate2(Certificate.DER());
            }

        /// <summary>
        /// Convert the specified Cryptography Certificate to a .Net X509Certificate2 object
        /// with the corresponding private key structure.
        /// </summary>
        /// <param name="Certificate">The certificate to convert.</param>
        /// <returns>The .Net X509Certificate2 object</returns>
        static X509Certificate2 X509CertificateAndKey(GCP.Certificate Certificate) {
            var X509 = new X509Certificate2(Certificate.Data);
            CryptoProviderAsymmetric Provider;
            if (Certificate.CryptoProviderSignature != null) {
                Provider = Certificate.CryptoProviderSignature;
                }
            else {
                Provider = Certificate.CryptoProviderExchange;
                }
            var KeyPair = Provider.KeyPair;


            X509.PrivateKey = Provider.KeyPair.AsymmetricAlgorithm;
            return X509;
            }

        /// <summary>
        /// Register a certificate in the default Windows store and location
        /// for that type of certificate.
        /// </summary>
        /// <param name="Certificate">Certificate to register.</param>
        public static new void Register(GCP.Certificate Certificate) {
            Register(Certificate, StoreName.My, StoreLocation.CurrentUser);
            }

        /// <summary>
        /// Register a certificate in the default Windows store and location
        /// for that type of certificate.
        /// </summary>
        /// <param name="Certificate">Certificate to register.</param>
        public static new void RegisterTrustedRoot(GCP.Certificate Certificate) {
            Register(Certificate, StoreName.Root, StoreLocation.LocalMachine);
            }


        /// <summary>
        /// Register a certificate in the default Windows store and location
        /// for that type of certificate.
        /// </summary>
        /// <param name="Data">Certificate to register.</param>
        public static new void RegisterTrustedRoot(byte [] Data) {
            var X509 = new X509Certificate2(Data);
            Register(X509, StoreName.Root, StoreLocation.LocalMachine);
            }

        /// <summary>
        /// Register a certificate in the specified Windows store *and location.
        /// </summary>
        /// <param name="Certificate">Certificate to register.</param>
        /// <param name="StoreName">The certificate store to register the certificate to</param>
        /// <param name="StoreLocation">The type of certificate store.</param>
        public static void Register(GCP.Certificate Certificate,
                    StoreName StoreName, StoreLocation StoreLocation) {
            var X509 = X509CertificateAndKey(Certificate);
            Register(X509, StoreName, StoreLocation);
            }

        /// <summary>
        /// Register a certificate in the specified Windows store and location.
        /// </summary>
        /// <param name="X509">Certificate to register.</param>
        /// <param name="StoreName">The certificate store to register the certificate to</param>
        /// <param name="StoreLocation">The type of certificate store.</param>
        public static void Register(X509Certificate2 X509,
                    StoreName StoreName, StoreLocation StoreLocation) {
            var Store = TestMode ? new X509Store(TestStore, StoreLocation) :
                  new X509Store(StoreName, StoreLocation);
            Store.Open(OpenFlags.ReadWrite);

            var Collection = Store.Certificates;
            if (!Collection.Contains(X509)) {
                Store.Add(X509);
                }
            Store.Close();
            }



        /// <summary>
        /// Find the certificate with a specified fingerprint.
        /// </summary>
        /// <param name="Fingerprint">UDF fingerprint of the corresponding key.</param>
        /// <returns>The located certificate</returns>
        public static new GCP.Certificate Get(string Fingerprint) {
            // search through each store in turn here
            var Store = new X509Store(TestStore, StoreLocation.CurrentUser);
            return Get(Fingerprint, Store);
            }

        /// <summary>
        /// Find the certificate with a specified fingerprint in the specified store.
        /// </summary>
        /// <param name="Fingerprint">UDF fingerprint of the corresponding key.</param>
        /// <param name="Store">Certificate store to get certificate from</param>
        /// <returns>The located certificate</returns>
        public static GCP.Certificate Get(string Fingerprint, X509Store Store) {
            Store.Open(OpenFlags.ReadOnly);
            var Certificates = Store.Certificates;

            foreach (var Certificate in Certificates) {
                Console.WriteLine("Got Cert {0}", Certificate.Subject);

                }
            Store.Close();

            return null;
            }


        /// <summary>
        /// Clean all certificate stores to remove test certificates
        /// </summary>
        public static new void Clean() {
            }

        /// <summary>
        /// Clean a certificate store to remove test certificates
        /// </summary>
        /// <param name="Store">The store to clean</param>
        public static void Clean (X509Store Store) {
            Store.Open(OpenFlags.ReadOnly);
            var Certificates = Store.Certificates;

            foreach (var Certificate in Certificates) {
                Console.WriteLine("Got Cert {0}", Certificate.Subject);

                }
            Store.Close();
            }

        }
    }