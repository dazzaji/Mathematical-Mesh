using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Protocol;
using  Goedel.Mesh.Protocol.Server;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class ExampleGenerator : global::Goedel.Registry.Script {

		

		//
		// ExamplesPortal
		//
		public static void ExamplesPortal (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesPortal.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("#Mesh Portal Service\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh Portal Service is the subset of Mesh Service operations that manage Mesh \n{0}", _Indent);
				_Output.Write ("profiles. A Mesh Service MUST support the Mesh Portal Service but is not required\n{0}", _Indent);
				_Output.Write ("to support any other service.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Creating a Mesh Service Account\n{0}", _Indent);
				 Example.Traces.Level = 0;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Having created a personal profile, Alice requests creation of an account at a\n{0}", _Indent);
				_Output.Write ("Mesh Service. The first step in this process is choosing a Mesh Service account \n{0}", _Indent);
				_Output.Write ("address 'Mesh address'\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A Mesh address has the format user@domain where domain is the DNS name of the Mesh\n{0}", _Indent);
				_Output.Write ("service and user is the name of their account at that service.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Services MAY support the use of any unicode character sequence permitted for use\n{0}", _Indent);
				_Output.Write ("as an SMTP email address by RFC6530. Matching of Mesh addresses is case \n{0}", _Indent);
				_Output.Write ("insensitive for latin characters (a-z, A-Z) but no similar mappings are supported\n{0}", _Indent);
				_Output.Write ("for other character sets.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice selects the Mesh Service 'example.com' and the name 'alice'. Her Mesh \n{0}", _Indent);
				_Output.Write ("client first checks to see if the name is available:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Request {{Verify alice@example.com}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh service responds stating that the address is available.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The ValidateRequest message contains the requested account identifier\n{0}", _Indent);
				_Output.Write ("and an optional language parameter to allow the service to provide\n{0}", _Indent);
				_Output.Write ("informative error messages in a language the user understands. The\n{0}", _Indent);
				_Output.Write ("Language field contains a list of ISO language identifier codes \n{0}", _Indent);
				_Output.Write ("in order of preference, most preferred first.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Response {{Verify alice@example.com}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The ValidateResponse message returns the result of the validation\n{0}", _Indent);
				_Output.Write ("request in the Valid field. Note that even if the value true is returned,\n{0}", _Indent);
				_Output.Write ("a subsequent account creation request MAY still fail.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[Note that for the sake of concise presentation, the HTTP binding\n{0}", _Indent);
				_Output.Write ("information is omitted from future examples.]\n{0}", _Indent);
				 Example.Traces.Level = 3;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh client requests that the account be created and bound to the (provided)\n{0}", _Indent);
				_Output.Write ("personal profile:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Request {{Account Create alice@example.com}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh service responds stating that the address is available:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Response {{Account Create  alice@example.com}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Using Recovery Records\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Before using her newly created profile, Alice makes sure that she can recover it\n{0}", _Indent);
				_Output.Write ("in the case of a catastrophe. She also wants to make sure that her master profile \n{0}", _Indent);
				_Output.Write ("won't be compromised if the machine she created it on is compromised by deleting the \n{0}", _Indent);
				_Output.Write ("key information from the machine. To do this, she creates a Recovery Record.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A recovery record contains the private keys associated with her master profile encrypted\n{0}", _Indent);
				_Output.Write ("using a strong symmetric cipher (AES 256 in this case). Recovery records are indexed by\n{0}", _Indent);
				_Output.Write ("means of the UDF fingerprint derrived from the decryption key. Thus, knowledge of the decryption\n{0}", _Indent);
				_Output.Write ("key is sufficient to locate the recovery record in a collection of recovery records and\n{0}", _Indent);
				_Output.Write ("knowledge of the index is evidence that a requestor knows the decryption key.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Creating a Recovery Record\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The plaintext of the recovery record specifies the private keys associated with\n{0}", _Indent);
				_Output.Write ("the Master Signature Key and Master Escrow Key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{Recovery RecordPlaintext}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A Master Recovery Key is created. In this case, Alice is using a Master Recovery Key of 128 \n{0}", _Indent);
				_Output.Write ("bits so that the recovery key shares are as compact as possible.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{MasterRecoveryKey}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The HKDF function is used to derrive the Encryption Key for the Recovery Record and the \n{0}", _Indent);
				_Output.Write ("Recovery index:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{RecoveryEncryptionKey}}\n{0}", _Indent);
				_Output.Write ("{{RecoveryIndex}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Recovery record is encrypted using the DARE Message Format\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{Recovery RecordDARE}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh client then creates an authenticated request to post the recovery record to the \n{0}", _Indent);
				_Output.Write ("profile:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{AuthenticatedRecoveryRequest}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh Service returns its response:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{AuthenticatedRecoveryResponse}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[Note that for the sake of concise presentation, the request and response authentication\n{0}", _Indent);
				_Output.Write ("information is omitted from future examples.]\n{0}", _Indent);
				 Example.Traces.Level = 5;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Having successfully posted the recovery data to the service, the client presents Alice \n{0}", _Indent);
				_Output.Write ("with a list of recovery shares that can be used to recover the data. The calculation\n{0}", _Indent);
				_Output.Write ("of the recovery shares is described in part III.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{Recovery shares 2 of 3}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Recovering a Profile.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To test her ability to recover her master profile, Alice deletes her master profile\n{0}", _Indent);
				_Output.Write ("from her administration device=.\n{0}", _Indent);
				_Output.Write ("To recover her profile, Alice reconstructs the recovery secret from two of \n{0}", _Indent);
				_Output.Write ("her shares and uses this information to request recovery:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{RecoveryRecordRequest}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Note that this request is not authenticated.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh Service locates the requested data and responds:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{RecoveryRecordResponse}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The client recovers the Master profile information and verifies it, then uses the data\n{0}", _Indent);
				_Output.Write ("to reactivate the \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Connecting a Device to a Portal Account\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Connecting a device to a profile requires the client on the new\n{0}", _Indent);
				_Output.Write ("device to interact with a client on a device that has administration capabilities,\n{0}", _Indent);
				_Output.Write ("i.e. it has access to an Online Signing Key. Since clients cannot \n{0}", _Indent);
				_Output.Write ("interact directly with other clients, a service is required to \n{0}", _Indent);
				_Output.Write ("mediate the connection. This service is provided by a Mesh portal\n{0}", _Indent);
				_Output.Write ("provider.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("All service transactions are initiated by the clients. First the \n{0}", _Indent);
				_Output.Write ("connecting device posts ConnectStart, after which it may poll for the\n{0}", _Indent);
				_Output.Write ("outcome of the connection request using ConnectStatus.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Periodically, the Administration Device polls for a list of pending\n{0}", _Indent);
				_Output.Write ("connection requests using ConnectPending. After posting a request,\n{0}", _Indent);
				_Output.Write ("the administration device posts the result using ConnectComplete:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Connecting                  Mesh                 Administration\n{0}", _Indent);
				_Output.Write ("  Device                   Service                   Device\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("	|                         |                         |\n{0}", _Indent);
				_Output.Write ("	|      ConnectStart       |                         |\n{0}", _Indent);
				_Output.Write ("	| ----------------------> |                         |\n{0}", _Indent);
				_Output.Write ("	|                         |      ConnectPending     |\n{0}", _Indent);
				_Output.Write ("	|                         | <---------------------- |\n{0}", _Indent);
				_Output.Write ("	|                         |                         |\n{0}", _Indent);
				_Output.Write ("	|                         |      ConnectComplete    |\n{0}", _Indent);
				_Output.Write ("	|                         | <---------------------- |\n{0}", _Indent);
				_Output.Write ("	|      ConnectStatus      |                         |\n{0}", _Indent);
				_Output.Write ("	| ----------------------> |                         |\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Device connection flow is actually an example of the Messaging flow \n{0}", _Indent);
				_Output.Write ("in that it is initiated by an untrusted device making a connection request \n{0}", _Indent);
				_Output.Write ("to the Mesh Service which the user's administration device collects\n{0}", _Indent);
				_Output.Write ("and responds to in the same fashion as any other messaging flow.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The process is initiated by a request from the device to post a connection request.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Request {{ConnectStart alice@example.com}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request is accepted. Note that if abuse is a concern, we may have required the\n{0}", _Indent);
				_Output.Write ("use of a one time passcode to validate the request. The service responds with\n{0}", _Indent);
				_Output.Write ("the personal profile bound to the account.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Response {{ConnectStart alice@example.com}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The fingerprint of the device profile and the fingerprint of the personal \n{0}", _Indent);
				_Output.Write ("profile are combined to create a request verification code. This is \n{0}", _Indent);
				_Output.Write ("displayed on Alice's device\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{Verification code.}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To authorize the request, the administration device begins by synchronizing \n{0}", _Indent);
				_Output.Write ("the connect message spool:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Request {{SyncPending Connect alice@example.com}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The service responds with a list of pending requests optionally filtered according\n{0}", _Indent);
				_Output.Write ("to criteria provided by Alice:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Response {{SyncPending Connect alice@example.com}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice Accepts the request. Her administration device creates and signs a Device \n{0}", _Indent);
				_Output.Write ("Authorization and posts it to the Mesh Service where it is added to the Device\n{0}", _Indent);
				_Output.Write ("Catalog:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Request {{ConnectPost alice@example.com}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request is successful:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Response {{ConnectPost alice@example.com}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Finally, the device polls the service and recieves notice that the request has \n{0}", _Indent);
				_Output.Write ("been accepted:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Request {{ConnectStatus alice@example.com}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The acceptance includes a copy of the Device Authorization(s).\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Response {{ConnectStatus alice@example.com}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Deleting a Portal Account\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Should she ever decide to stop using the Mesh Service, Alice can request that\n{0}", _Indent);
				_Output.Write ("her account be deleted. Note that this only affects her account on the service\n{0}", _Indent);
				_Output.Write ("and not on her local machine.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{DeleteRequest}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh Service returns its response:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{DeleteResponse}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Once a Mesh address has been deleted, reuse of the address by a new profile is entirely a \n{0}", _Indent);
				_Output.Write ("matter for site policy. A Mesh Service MAY refuse to allow any request to create an account \n{0}", _Indent);
				_Output.Write ("with a previously used address under any circumstances or MAY allow any party to reuse the \n{0}", _Indent);
				_Output.Write ("address.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Mesh addresses are inherently transient. If a permanent and immutable address is required \n{0}", _Indent);
				_Output.Write ("for some purpose, the Strong Internet Name of the Mesh Address SHOULD be used instead. \n{0}", _Indent);
				_Output.Write ("This name binds the Mesh profile fingerprint to the Mesh Address, thus creating a name\n{0}", _Indent);
				_Output.Write ("that can be regarded as unambiguously identifying the profile owner and means of contact.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
