﻿using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.Platform;

namespace Goedel.Mesh.MeshMan {

    public partial class Shell {
        /// Create a new web application profile.
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void MailCreate(MailCreate Options) {
            SetReporting(Options);
            var RegistrationPersonal = GetPersonal(Options);

            var MailProfile = new MailProfile();

            Register(RegistrationPersonal, MailProfile);

            LastResult = new ResultApplicationCreate() {
                ApplicationProfile = MailProfile
                };
            ReportWrite(LastResult.ToString());
            }
        }
    }
