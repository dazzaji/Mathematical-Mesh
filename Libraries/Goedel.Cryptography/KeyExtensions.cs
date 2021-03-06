﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Cryptography.PKIX;

namespace Goedel.Cryptography {



    /// <summary>
    /// Extensions class for deriving UDF from key parameters
    /// </summary>
    public static class KeyExtensions {

        /// <summary>
        /// Calculate UDF data value for public key parameters
        /// </summary>
        /// <param name="key">The key to calculate the fingerprint of</param>
        /// <param name="bits">Precision, must be a multiple of 25 bits.</param>
        /// <returns>The binary fingerprint value</returns>
        public static byte[] UDFBytes(this IPKIXPublicKey key, int bits=0) => 
            Cryptography.UDF.FromKeyInfo(key.PublicParameters.DER(), bits);

        /// <summary>
        /// Calculate UDF fingerprint presentation for public key parameters
        /// </summary>
        /// <param name="key">The key to calculate the fingerprint of</param>
        /// <returns>The fingerprint presentation</returns>
        public static string UDF(this IPKIXPublicKey key) {
            var Bytes = key.UDFBytes();
            return Cryptography.UDF.PresentationBase32(Cryptography.UDF.FromKeyInfo(Bytes));
            }

        /// <summary>
        /// Returns true if the key is exportable, otherwise false.
        /// </summary>
        /// <param name="keyStorage">The key security specifier.</param>
        /// <returns>true if the key is exportable, otherwise false</returns>
        public static bool IsExportable(this KeySecurity keyStorage) =>
            (keyStorage & KeySecurity.Exportable) == KeySecurity.Exportable;

        /// <summary>
        /// Returns true if the key is persisted, otherwise false.
        /// </summary>
        /// <param name="keyStorage">The key security specifier.</param>
        /// <returns>true if the key is persisted, otherwise false</returns>
        public static bool IsPersisted(this KeySecurity keyStorage) =>
            (keyStorage & KeySecurity.Persisted) == KeySecurity.Persisted;


        }
    }
