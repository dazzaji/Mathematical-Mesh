﻿using System;
using System.Collections.Generic;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Cryptography;
using Goedel.Utilities;
using System.IO;
using Goedel.Protocol;
using Goedel.Test;

namespace Goedel.Cryptography.Dare.Test {
    [MT.TestClass]
    public partial class TestDare {

        /// <summary>
        /// 
        /// </summary>
        public static void TestDirect() {
            InitializeClass();

            var TestDare = new TestDare();

            //TestDare.MessageEncryptedWithData();
            //TestDare.MessagePlaintext();
            TestDare.MessageEncryptedAtomic();
            //TestDare.TestFileContainerEncrypted1();
            //TestDare.TestFileContainerEncrypted16();
            }



        [MT.AssemblyInitialize]
        public static void InitializeClass(MT.TestContext Context) => InitializeClass();
        public static void InitializeClass() => CryptographyWindows.Initialize();


        }
    }