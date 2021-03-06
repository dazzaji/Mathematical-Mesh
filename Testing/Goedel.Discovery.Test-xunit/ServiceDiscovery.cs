﻿using Goedel.Discovery;

using Xunit;

namespace Goedel.XUnit {

    public partial class ServiceDiscovery {


        [Fact]
        public void TestDNS() {
            var Service1 = DNSClient.ResolveService("prismproof.org");

            var Service2 = DNSClient.ResolveService("prismproof.org", "mmm");

            var Service3 = DNSClient.ResolveService("prismproof.org", "www", 80);


            }
        }
    }
