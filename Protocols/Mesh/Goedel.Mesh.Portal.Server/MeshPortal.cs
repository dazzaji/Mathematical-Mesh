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
using Goedel.Protocol;
using Goedel.Mesh;
using Goedel.Mesh.Portal;

namespace Goedel.Mesh.Portal.Server {

    /// <summary>
    /// Abstract interface to a local service provider.
    /// </summary>
    public abstract class MeshLocalPortal : MeshPortal{
        /// <summary>
        /// File name for local access to the mesh store.
        /// </summary>
        protected string MeshStore = "mesh.jlog";

        /// <summary>
        /// File name for local access to the portal store.
        /// </summary>
        protected string PortalStore = "portal.jlog";

        /// <summary>
        /// The service name (default to mesh.prismproof.org)
        /// </summary>
        protected string ServiceName = "mesh.prismproof.org";

        /// <summary>
        /// The local PublicMeshServiceHost.
        /// </summary>
        public PublicMeshServiceProvider MeshServiceHost;
        }


    /// <summary>
    /// Direct connection to service provider via API calls. 
    /// </summary>
    public class MeshPortalDirect: MeshLocalPortal {

        /// <summary>
        /// Create new portal using the default stores.
        /// </summary>
        public MeshPortalDirect() => Init(ServiceName, MeshStore, PortalStore);

        /// <summary>
        /// Create a new portal using the specified stores.
        /// </summary>
        /// <param name="ServiceName">DNS service name</param>
        /// <param name="MeshStore">File name for the Mesh Store.</param>
        /// <param name="PortalStore">File name for the Portal Store.</param>
        public MeshPortalDirect(string ServiceName, string MeshStore, string PortalStore) => Init(ServiceName, MeshStore, PortalStore);

        /// <summary>
        /// Create a new portal using the specified stores.
        /// </summary>
        /// <param name="MeshStore">File name for the Mesh Store.</param>
        /// <param name="PortalStore">File name for the Portal Store.</param>
        public MeshPortalDirect(string MeshStore, string PortalStore) => Init(ServiceName, MeshStore, PortalStore);

        /// <summary>
        /// Initialize the portal
        /// </summary>
        /// <param name="ServiceName">DNS service name</param>
        /// <param name="MeshStore">File name for the Mesh Store.</param>
        /// <param name="PortalStore">File name for the Portal Store.</param>
        protected void Init (string ServiceName, string MeshStore, string PortalStore) {
            this.ServiceName = ServiceName;
            this.MeshStore = MeshStore;
            this.PortalStore = PortalStore;
            MeshServiceHost = new PublicMeshServiceProvider(ServiceName, MeshStore, PortalStore);
            }

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Account">The account to get.</param>
        /// <param name="Portal">The portal to get the service from.</param>
        /// <returns>The service instance</returns> 
        public override MeshService GetService(string Portal, string Account) {
            var Session = new DirectSession(null);
            MeshServiceClient = new PublicMeshService(MeshServiceHost, Session);
            return MeshServiceClient;
            }

        }






    /// <summary>
    /// Direct connection to service provider via JSON encoding, decoding and dispatch.
    /// Useful for producing documentation and for testing.
    /// </summary>
    public class MeshPortalLocal : MeshLocalPortal {

        /// <summary>
        /// Create new portal using the default stores.
        /// </summary>
        public MeshPortalLocal() => MeshServiceHost = new PublicMeshServiceProvider(ServiceName, MeshStore, PortalStore);

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Account">The account to get.</param>
        /// <param name="Service">The service to get the service from.</param> 
        /// <returns>The service instance</returns>
        public override MeshService GetService(string Service, string Account) {
            var Session = new LocalRemoteSession(MeshServiceHost, ServiceName, Account);
            MeshServiceClient = new MeshServiceClient(Session);
            return MeshServiceClient;
            }

        }

    }
