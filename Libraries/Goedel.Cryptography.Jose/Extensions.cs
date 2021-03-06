﻿using System;
using System.Collections.Generic;
using Goedel.Cryptography;

namespace Goedel.Cryptography.Jose {

    /// <summary>Static class containing convenience functions</summary>
    public static class Extensions {

        /// <summary>
        /// Calculate the digest value of the contents of <paramref name="fileName"/> using the algorithm
        /// specified by <paramref name="algID"/>.
        /// </summary>
        /// <param name="fileName">The file containing the data to digest.</param>
        /// <param name="algID">The JOSE digest algorithm identifier.</param>
        /// <returns>The digest value.</returns>
        public static byte[] GetDigestOfFile(this string fileName, string algID) =>
             CryptoStreamFromID.GetDigestOfFile(fileName, algID.ToCryptoAlgorithmID(CryptoAlgorithmID.SHA_2_512));

        }
    }
