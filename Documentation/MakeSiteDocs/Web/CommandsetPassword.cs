using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Shell;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace MakeSiteDocs {
	public partial class MakeSiteDocs : global::Goedel.Registry.Script {

		

		//
		// WebPassword
		//
		public static void WebPassword (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Guide/password.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// PasswordReference
		//
		public static void PasswordReference (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Reference/password.md")) {
				var _Indent = ""; 
				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Password;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _PasswordAdd._DescribeCommand);
				 Describe(_Output, CommandSet, _PasswordGet._DescribeCommand);
				 Describe(_Output, CommandSet, _PasswordDelete._DescribeCommand);
				 Describe(_Output, CommandSet, _PasswordDump._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
