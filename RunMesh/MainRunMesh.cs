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
using System.IO;
using System.Linq;

using Goedel.Mesh.Platform;
using Goedel.Mesh.Platform.Windows;
using Goedel.Cryptography;
using Goedel.Cryptography.Windows;
using Goedel.Cryptography.KeyFile;
using Test.Common;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Persistence;
using Goedel.Mesh.MeshMan;

using Goedel.Mesh.Server;


namespace Goedel.Mesh {


    public static class ExtensionCLI {
        public static void MainMethod (this CommandLineInterpreter CommandLineInterpreter, string Command) {
            Console.WriteLine("**** {0}", Command);

            var Args = Command.Split((char [])null, StringSplitOptions.RemoveEmptyEntries);
            CommandLineInterpreter.MainMethod(Args);
            return;
            }

        }


    class Program {
        static TestConstant TestConstant;
        static MeshCatalog MeshCatalog = null;

        static void Main (string[] args) {
            Goedel.IO.Debug.Initialize();
            TestConstant = new TestConstant();
            MeshWindows.Initialize(true);

            // Connect to a direct, in process portal.

            File.Delete(TestConstant.LogMesh);
            File.Delete(TestConstant.LogPortal);

            var Portal = new MeshPortalDirect(TestConstant.NameService, 
                TestConstant.LogMesh, TestConstant.LogPortal);
            MeshPortal.Default = Portal;

            MeshCatalog = new MeshCatalog();
            MeshCatalog.EraseTest(); // remove previous test data

            //// Connect to a direct, in process portal.
            //var Portal = new MeshPortalDirect(TestConstant.NameService, TestConstant.LogMesh, TestConstant.LogPortal);
            //MeshPortal.Default = Portal;

            var Program = new Program();
            Program.TestShell();


            }

        CommandLineInterpreter CommandLineInterpreter = new CommandLineInterpreter ();

        Shell Shell1 = new Shell() {
            MeshCatalog = new MeshCatalog()
            };
        public void Device1 (string Command) {
            var Args = Command.Split();
            Console.WriteLine("**** 1: {0}", Command);
            CommandLineInterpreter.MainMethod(Shell1, Args);
            }

        Shell Shell2 = new Shell() {
            MeshCatalog = new MeshCatalog(new RegistrationMachineCached())
            };
        public void Device2 (string Command) {
            var Args = Command.Split();
            Console.WriteLine("**** 2: {0}", Command);
            CommandLineInterpreter.MainMethod(Shell2, Args);
            }

        Shell Shell3 = new Shell() {
            MeshCatalog = new MeshCatalog(new RegistrationMachineCached())
            };
        public void Device3 (string Command) {
            var Args = Command.Split();
            Console.WriteLine("**** 3: {0}", Command);
            CommandLineInterpreter.MainMethod(Shell3, Args);
            }


        public void TestShell () {

            // Create the first device and personal profile
            Device1("verify test@prismproof.org");
            Device1("personal create test@prismproof.org");
            //Device1("/list");

            //// Test reload of persistence store (only works for device 1 as only that is persisted)
            //Shell1.MeshCatalog.Reload();

            //Device1("/list");
            //Device1("/dump");
            //Device1("personal export myprofile.json");

            // Connect the second device
            Device2("connect start test@prismproof.org");
            Device1("connect pending");

            Device1("connect accept " + Shell2.Authenticator);
            Device2("connect Complete");
            // Hack: The caching onlyu machine does not do portal lookup as it should

            // create application profiles
            Device1("ssh create");
            //Device1("password create");
            //Device1("confirm create alice@prismproof.org ");
            //Device1("recrypt create alice@prismproof.org ");
            //Device1("mail create alice#example.com ");

            //// create the third device
            //Device3("connect start test@prismproof.org");
            //Device1("connect pending");
            //Device1("connect accept " + Shell3.Authenticator);
            //Device3("connect Complete");

            //// Create an escrow record
            //Device1("personal escrow /quorum 2 /shares 3");
            //Device1("personal escrow /quorum 2 /shares 3 /file escrow.json");
            //Device1("/list");
            //MeshCatalog.Reload();

            // Test SSH operations
            Device1("ssh auth");
            Device1("ssh known");
            Device1("ssh public ");
            Device1("ssh private");

            // Test Password operations
            Device1("password create");
            Device1("password add example.com alice password1");
            Device1("password dump");
            Device1("password add example.com alice password2");
            Device1("password add example.net alice password3");
            Device1("password dump");
            Device1("password delete example.com");
            Device1("password dump");

            // Test Recrypt operations


            // Test Confirm operations


            Device1("dump");
            }
        }

    }
