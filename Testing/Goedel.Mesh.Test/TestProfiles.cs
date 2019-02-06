using System;
using System.Collections.Generic;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Mesh.Protocol.Client;
using Goedel.Utilities;
using Goedel.Test.Core;
using Goedel.Protocol;

namespace Goedel.Mesh.Test {

    public partial class TestProfiles {

        static string Service = "example.com";
        static string NextAccountAlice(string Test) => $"alice{Test}@{Service}";
        static string NextAccountBob(string Test) => $"bob{Test}@{Service}";

        public static TestProfiles Test => new TestProfiles();
        public TestProfiles() => TestEnvironmentCommon.Initialize();

        public  void EscrowRecover() {
            var machineEnvironment = new TestEnvironmentMachine( "EscrowRecover");

            var MachineAliceAdmin = new MeshMachineTest(machineEnvironment, name: "Alice Admin");
            var MachineAliceRecover = new MeshMachineTest(machineEnvironment, name: "Alice Admin Recovered");

            var DeviceAdmin = ContextDevice.Generate(MachineAliceAdmin);
            var MasterAdmin = DeviceAdmin.GenerateMaster();

            var (Escrow, Shares) = MasterAdmin.Escrow(3, 2);
            var RecoverShares = new KeyShare[] { Shares[0], Shares[2] };

            var DeviceAdminRecovered = DeviceAdmin.Recover(Escrow, RecoverShares);

            }

        public void CatalogCredentials() {
            var machineEnvironment = new TestEnvironmentMachine("ProtocolHello");

            var MachineAliceAdmin = new MeshMachineTest(machineEnvironment, name: "Alice");
            var DeviceAdmin = ContextDevice.Generate(MachineAliceAdmin);
            var MasterAdmin = DeviceAdmin.GenerateMaster();


            using (var catalog = MasterAdmin.GetCatalogCredential()) {

                var Entry1 = new CatalogEntryCredential() {
                    Service = "example.com",
                    Username = "alice",
                    Password = "password"
                    };
                var Entry2 = new CatalogEntryCredential() {
                    Service = "example.net",
                    Username = "alice",
                    Password = "samepassword"
                    };
                var Entry3 = new CatalogEntryCredential() {
                    Service = "www.cnn.com",
                    Username = "alice1977",
                    Password = "EasyToGuess"
                    };
                var Entry4 = new CatalogEntryCredential() {
                    Service = "www.bank.test",
                    Username = "alice1977",
                    Password = "EasyToGuess"
                    };
                var Entry5 = new CatalogEntryCredential() {
                    Service = "example.net",
                    Username = "alice",
                    Password = "samepassword2"
                    };


                CheckCatalog(catalog, new List<CatalogEntry> { });

                catalog.Add(Entry1);
                CheckCatalog(catalog, new List<CatalogEntry> { Entry1 });

                catalog.Add(Entry2);
                CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry2 });

                catalog.Add(Entry3);
                CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry2, Entry3 });

                catalog.Add(Entry4);
                CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry2, Entry3, Entry4 });

                catalog.Update(Entry5);
                CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry3, Entry4, Entry5 });

                catalog.Delete(Entry4);
                CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry3, Entry5 });

                CheckCatalogEntry(Entry1, catalog.LocateByService(Entry1.Service));
                CheckCatalogEntry(Entry3, catalog.LocateByService(Entry3.Service));
                CheckCatalogEntry(null, catalog.LocateByService(Entry4.Service));
                CheckCatalogEntry(Entry5, catalog.LocateByService(Entry5.Service));


                CheckCatalogEntry(Entry1, catalog.Locate(Entry1._PrimaryKey));
                }
            }

        /// <summary>
        /// Test direct addition/removal of devices without going through the services or inbound spool
        /// </summary>
        public void CatalogDevices() {
            var machineEnvironment = new TestEnvironmentMachine( "ProtocolHello");

            var MachineAliceAdmin = new MeshMachineTest(machineEnvironment, name: "Alice");
            var MachineAliceLaptop = new MeshMachineTest(machineEnvironment, name: "Alice Laptop");
            var MachineAlicePhone = new MeshMachineTest(machineEnvironment, name: "Alice Phone");
            var DeviceAdmin = ContextDevice.Generate(MachineAliceAdmin);
            var MasterAdmin = DeviceAdmin.GenerateMaster();

            var catalog = MasterAdmin.CatalogDevice;

            var keySign = MachineAliceAdmin.KeyCollection.LocatePrivate(DeviceAdmin.ProfileDevice.DeviceSignatureKey.UDF);
            var Entry1 = MakeCatalogEntryDevice(DeviceAdmin.ProfileDevice, keySign);

            var Device2 = ContextDevice.Generate(MachineAliceLaptop);
            var Entry2 = MakeCatalogEntryDevice(Device2.ProfileDevice, keySign);
            var Device3 = ContextDevice.Generate(MachineAlicePhone);
            var Entry3 = MakeCatalogEntryDevice(Device3.ProfileDevice, keySign);

            catalog.Add(Entry1);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1 });
            catalog.Add(Entry2);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry2 });

            catalog.Add(Entry3);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry2, Entry3 });
            }

        protected DareMessage Sign(JSONObject data, KeyPair keySign) =>
                    DareMessage.Encode(data.GetBytes(tag: true),
                        signingKey: keySign, contentType: "application/mmm");

        public CatalogEntryDevice MakeCatalogEntryDevice(ProfileDevice profileDevice, KeyPair keySign) {

            var profileMeshDevicePublic = new ProfileMeshDevicePublic() {
                DeviceProfile = profileDevice.ProfileDeviceSigned
                };

            var ProfileMeshDevicePrivate = new ProfileMeshDevicePrivate() {
                };

            var catalogEntryDevice = new CatalogEntryDevice() {
                UDF = profileDevice.UDF,
                ProfileMeshDevicePublicSigned = Sign(profileMeshDevicePublic, keySign),
                ProfileMeshDevicePrivateEncrypted = Sign(ProfileMeshDevicePrivate, keySign)
                };


            return catalogEntryDevice;
            }


        /// <summary>
        /// Test addition/deletion of contacts
        /// </summary>
        public void CatalogContacts() {
            var machineEnvironment = new TestEnvironmentMachine( "ProtocolHello");

            var MachineAliceAdmin = new MeshMachineTest(machineEnvironment, name: "Alice");
            var DeviceAdmin = ContextDevice.Generate(MachineAliceAdmin);
            var MasterAdmin = DeviceAdmin.GenerateMaster();


            var catalog = MasterAdmin.CatalogContact;

            var Contact1 = new Contact() {
                FullName = "Alice Example",
                First = "Alice",
                Last = "Example"
                };
            var Entry1 = new CatalogEntryContact(Contact1);

            var Contact2 = new Contact() {
                FullName = "Bob Example",
                First = "Bob",
                Last = "Example"
                };
            var Entry2 = new CatalogEntryContact(Contact2);

            var Contact3 = new Contact() {
                FullName = "Carol Example",
                First = "Carol",
                Last = "Example"
                };
            var Entry3 = new CatalogEntryContact(Contact3);

            var Contact4 = new Contact() {
                FullName = "Mallet Example",
                First = "Mallet",
                Last = "Example"
                };
            var Entry4 = new CatalogEntryContact(Contact4);

            catalog.Add(Entry1);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1 });

            catalog.Add(Entry2);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry2 });

            catalog.Add(Entry3);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry2, Entry3 });

            catalog.Add(Entry4);
            CheckCatalog(catalog, new List<CatalogEntry> { Entry1, Entry2, Entry3, Entry4 });
            }




        void CheckCatalog(Catalog catalog, List<CatalogEntry> entries) {

            var sorted = new SortedDictionary<string, CatalogEntry>();
            foreach (var entry in entries) {
                sorted.Add(entry._PrimaryKey, entry);
                }
            foreach (var entry in catalog) {
                sorted.TryGetValue(entry._PrimaryKey, out var test).AssertTrue();
                CheckCatalogEntry(entry, test);
                sorted.Remove(entry._PrimaryKey).AssertTrue();
                }
            sorted.Count.AssertEqual(0);

            }


        void CheckCatalogEntry(CatalogEntry Test1, CatalogEntry Test2) {
            if (Test1 == null) {
                Test2.AssertNull();
                }
            else {
                Test1.ToString().AssertEqual(Test2.ToString());
                }
            }



        }
    }
