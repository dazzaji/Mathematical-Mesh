﻿using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.Platform;

namespace Goedel.Mesh.MeshMan {

    public partial class Shell {
        /// Create a new web application profile.
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Mail(Mail Options) {
            SetReporting(Options);
            var RegistrationPersonal = GetPersonal(Options);

            var MailProfile = new MailProfile(true);

            Register(RegistrationPersonal, MailProfile);
            }
        }
    }
