﻿using System.Numerics;
using Xunit;
using Goedel.Cryptography;

namespace Goedel.XUnit {

    public partial class GoedelCryptography {

        [Fact]
        public void TestRandom() {
            var Random1 = Platform.GetRandomBytes(10);
            var Random2 = Platform.GetRandomBigInteger(2048);
            }

        }
    }
