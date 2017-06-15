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
using Goedel.Utilities;
using System;
using System.Collections.Generic;
using Goedel.Mesh.Server;

namespace Goedel.Mesh.Platform {
    public class RegistrationMachineCached : RegistrationMachine {

        /// <summary>
        /// Return a new machine registration.
        /// </summary>
        public override void Reload () {
            }

        /// <summary>The abstract machine a profile registration is attached to</summary>
        public override RegistrationMachine RegistrationMachine { get; set; }

        /// <summary>
        /// The registered signed profile. This is always null for a machine registration
        /// as it reflects a collection of profiles rather than a single profile.
        /// </summary>
        public override SignedProfile SignedProfile { get => null; }

        /// <summary>
        /// The a dictionary of personal profiles indexed by fingerprint.
        /// </summary>
        public override Dictionary<string, RegistrationPersonal> PersonalProfilesUDF { get; } =
            new Dictionary<string, RegistrationPersonal>();

        /// <summary>
        /// The a dictionary of personal profiles indexed by portal account.
        /// </summary>
        public override Dictionary<string, RegistrationPersonal> PersonalProfilesPortal { get; } =
            new Dictionary<string, RegistrationPersonal>();

        /// <summary>
        /// A dictionary of application profiles indexed by fingerprint.
        /// </summary>
        public override Dictionary<string, RegistrationApplication> ApplicationProfiles { get; } =
            new Dictionary<string, RegistrationApplication>();

        /// <summary>
        /// A dictionary of default application profiles indexed by application identifier;
        /// </summary>
        public override Dictionary<string, string> ApplicationProfilesDefault { get; } =
            new Dictionary<string, string>();

        /// <summary>
        /// A dictionary of device profiles indexed by fingerprint.
        /// </summary>
        public override Dictionary<string, RegistrationDevice> DeviceProfiles { get; } =
            new Dictionary<string, RegistrationDevice>();

        /// <summary>The default personal profile</summary>
        public override RegistrationPersonal Personal {
            get { return _Personal; }
            set {
                if (value != _Personal) {
                    _Personal = value;
                    value.MakeDefault();
                    }
                }
            }
        private RegistrationPersonal _Personal;

        /// <summary>
        /// Set the default personal profile registration.
        /// </summary>
        /// <param name="Registration">The registration to set as default</param>
        /// <param name="DefaultTime">If non-null, the registration is only set to be default</param>
        public void SetDefaultPersonal (RegistrationPersonal Registration,
                            DateTime? DefaultTime = null) {
            if ((_Personal == null) || (DefaultTime == null) || 
                        (DefaultTime > PersonalDefaultTime)) {
                _Personal = Registration;
                }
            }
        DateTime PersonalDefaultTime = DateTime.MinValue;

        /// <summary>The default device profile</summary>
        public override RegistrationDevice Device {
            get { return _Device; }
            set {
                if (value != _Device) {
                    _Device = value;
                    value.MakeDefault();
                    }
                }
            }
        private RegistrationDevice _Device;

        /// <summary>
        /// Set the default device profile registration.
        /// </summary>
        /// <param name="Registration">The registration to set as default</param>
        /// <param name="DefaultTime">If non-null, the registration is only set to be default</param>
        public void SetDefaultDevice (RegistrationDevice Registration,
                            DateTime? DefaultTime = null) {
            if ((DefaultTime == null) || (DefaultTime > PersonalDeviceTime)) {
                _Device = Registration;
                }
            }
        DateTime PersonalDeviceTime = DateTime.MinValue;


        /// <summary>
        /// Make this the default personal profile for future operations.
        /// </summary>
        /// <param name="Force"></param>
        public override void MakeDefault () {
            }

        // Interaction with the static machine store.

        /// <summary>
        /// Write out the configuration to the current machine.
        /// </summary>
        public override void Write(bool Default = true) {
            // Do nothing as this is cached only
            }

        /// <summary>
        /// Write out the configuration to the current machine.
        /// </summary>
        public override void Read() {
            // Do nothing as this is cached only
            }

        /// <summary>Erase the profile and associated keys.</summary>
        public override void Erase() {
            PersonalProfilesUDF.Clear();
            PersonalProfilesPortal.Clear();
            ApplicationProfiles.Clear();
            ApplicationProfilesDefault.Clear();
            DeviceProfiles.Clear();
            }

        // Add profiles

        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public override RegistrationDevice Add(SignedDeviceProfile SignedProfile) {
            var Registration = new RegistrationDeviceCached(SignedProfile, this);
            Register(Registration);
            return Registration;
            }

        protected void Register (RegistrationDevice Registration) {
            DeviceProfiles.AddSafe(Registration.UDF, Registration); // NYI check if present
            }


        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public override RegistrationPersonal Add(SignedPersonalProfile SignedProfile) {
            var Registration = new RegistrationPersonalCached(SignedProfile, this);
            Register(Registration);
            return Registration;
            }

        protected void Register(RegistrationPersonal Profile) {
            PersonalProfilesUDF.AddSafe(Profile.UDF, Profile); // NYI check if already entered
            if (Profile.Portals != null) {
                foreach (var Name in Profile.Portals) {
                    PersonalProfilesPortal.AddSafe(Name, Profile);  //NYI check if already entered
                    }
                }
            }


        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="ApplicationProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public override RegistrationApplication Add(ApplicationProfile ApplicationProfile) {
            var Registration = new RegistrationApplicationCached(ApplicationProfile, this);
            Register(Registration);
            return Registration;
            }


        protected void Register (RegistrationApplication Registration) {
            var ApplicationProfile = Registration.ApplicationProfile;
            ApplicationProfiles.AddSafe(ApplicationProfile.Identifier, Registration); // NYI check if present
            ApplicationProfilesDefault.AddSafe(ApplicationProfile.Tag(), ApplicationProfile.Identifier);
            }



        /// <summary>
        /// Locate a device profile by identifier
        /// </summary>
        /// <param name="RegistrationDevice">The returned profile.</param>
        /// <param name="ID">UDF fingerprint of the profile or short form ID</param>
        /// <returns>True if the profile is found, otherwise false.</returns>
        public override bool Find(string ID, out RegistrationDevice RegistrationDevice) {
            return DeviceProfiles.TryGetValue(ID, out RegistrationDevice);
            }

        /// <summary>
        /// Locate a device profile by identifier
        /// </summary>
        /// <param name="RegistrationDevice">The returned profile.</param>
        /// <param name="ID">UDF fingerprint of the profile or short form ID</param>
        /// <returns>True if the profile is found, otherwise false.</returns>
        public override bool Find(string ID, out RegistrationApplication RegistrationApplication) {
            return ApplicationProfiles.TryGetValue(ID, out RegistrationApplication);
            }

        /// <summary>
        /// Locate a device profile by identifier
        /// </summary>
        /// <param name="RegistrationDevice">The returned profile.</param>
        /// <param name="ID">UDF fingerprint of the profile or short form ID</param>
        /// <returns>True if the profile is found, otherwise false.</returns>
        public override bool Find(string ID, out RegistrationPersonal RegistrationPersonal) {
            return PersonalProfilesUDF.TryGetValue(ID, out RegistrationPersonal);
            }



        }

    /// <summary>
    /// Describes the registration of a device profile on a machine.
    /// </summary>
    public class RegistrationDeviceCached : RegistrationDevice {
        /// <summary>The abstract machine a profile registration is attached to</summary>
        public override RegistrationMachine RegistrationMachine { get; set; }


        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedDeviceProfile">The device profile</param>
        public RegistrationDeviceCached(SignedDeviceProfile SignedDeviceProfile,
                    RegistrationMachine RegistrationMachine) {
            base.SignedDeviceProfile = SignedDeviceProfile;
            this.RegistrationMachine = RegistrationMachine;
            }

        /// <summary>
        /// Make this the default personal profile for future operations.
        /// </summary>
        /// <param name="Force"></param>
        public override void MakeDefault () {
            }

        }


    /// <summary>
    /// Describes the registration of a device profile on a machine.
    /// </summary>
    public class RegistrationPersonalCached : RegistrationPersonal {

        /// <summary>
        /// Profiles associated with this account in chronological order.
        /// </summary>
        public override SortedList<DateTime, SignedProfile> Profiles { get; set; }

        /// <summary>
        /// List of the accounts through which the profile is registered.
        /// </summary>
        public override PortalCollection Portals { get; }

        /// <summary>The abstract machine a profile registration is attached to</summary>
        public override RegistrationMachine RegistrationMachine { get; set; }

        /// <summary>
        /// Register a personal profile in the Windows registry
        /// </summary>
        /// <param name="Profile">The personal profile</param>
        /// <param name="Portals">The list of portals.</param>
        public RegistrationPersonalCached(SignedPersonalProfile Profile, 
                        RegistrationMachine Machine,
                        IEnumerable<string> Portals = null)  {
            RegistrationMachine = RegistrationMachine;
            SignedPersonalProfile = Profile;
            this.Portals = new PortalCollection(Portals);
            }

        public override void AddPortal(string AccountID, MeshClient MeshClient = null, bool Create = false) {
            MeshClient = MeshClient ?? new MeshClient(AccountID);
            this.MeshClient = MeshClient;

            Assert.NotNull(MeshClient, PortalConnectFail.Throw);

            var PortalRegister = MeshClient.CreatePortalAccount(AccountID, PersonalProfile.SignedPersonalProfile);

            Portals.Add(AccountID);
            }


        /// <summary>
        /// Make this the default personal profile for future operations.
        /// </summary>
        /// <param name="Force"></param>
        public override void MakeDefault () {
            }
        }


    /// <summary>
    /// Describes the registration of a device profile on a machine.
    /// </summary>
    public class RegistrationApplicationCached : RegistrationApplication {

        /// <summary>The abstract machine a profile registration is attached to</summary>
        public override RegistrationMachine RegistrationMachine { get; set; }

        /// <summary>
        /// Register request to register an application.
        /// </summary>
        /// <param name="ApplicationProfile">The application profile</param>
        public RegistrationApplicationCached (ApplicationProfile ApplicationProfile,
                        RegistrationMachine Machine) {
            RegistrationMachine = Machine;
            this.SignedApplicationProfile = ApplicationProfile.SignedApplicationProfile;
            }


        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public override void GetFromPortal () { }


        /// <summary>
        /// Update the associated profile in the registry
        /// </summary>
        public override void WriteToPortal () { }

        /// <summary>
        /// Make this the default personal profile for future operations.

        public override void MakeDefault () {
            }
        }
    }
