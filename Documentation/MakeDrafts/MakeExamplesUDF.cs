using  System.Text;
using  Goedel.Mesh;
using  Goedel.Protocol;
using  Goedel.Utilities;
using  Goedel.Cryptography;
using  Goedel.Cryptography.Dare;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class ExampleGenerator : global::Goedel.Registry.Script {

		

		//
		// MeshExamplesUDF
		//
		public static void MeshExamplesUDF (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesUDF.md")) {
				var _Indent = ""; 
				 var ContentType = "text/plain";
				 var ContentTypeString = ContentType.ToUTF8().ToStringBase16FormatHex();
				 var DataString = "UDF Data Value";
				 var DataBytes = DataString.ToUTF8();
				 var DataBytesString = DataBytes.ToStringBase16FormatHex();
				 var Sha2Data = Goedel.Cryptography.Platform.SHA2_512.Process(DataBytes);
				 var Sha3Data = Goedel.Cryptography.Platform.SHA3_512.Process(DataBytes);
				 var HashData = Sha2Data.ToStringBase16FormatHex();
				 var HashData3 = Sha3Data.ToStringBase16FormatHex();
				 var UDFDataBuffer = UDF.UDFBuffer(Sha2Data, ContentType);
				 var UDFDataBuffer3 = UDF.UDFBuffer(Sha3Data, ContentType);
				 var UDFDataBufferString = UDFDataBuffer.ToStringBase16FormatHex();
				 var UDFDataBufferString3 = UDFDataBuffer3.ToStringBase16FormatHex();
				 var UDFData = Goedel.Cryptography.Platform.SHA2_512.Process(UDFDataBuffer).ToStringBase16FormatHex();
				 var UDFData3 = Goedel.Cryptography.Platform.SHA3_512.Process(UDFDataBuffer).ToStringBase16FormatHex();
				_Output.Write ("In the following examples, &<Content-ID> is the UTF8 encoding of the string \n{0}", _Indent);
				_Output.Write ("\"{1}\" and &<Data> is the UTF8 encoding of the string \"{2}\"\n{0}", _Indent, ContentType, DataString);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Data = {1}\n{0}", _Indent, DataBytesString);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("ContentType = {1}\n{0}", _Indent, ContentTypeString);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Using SHA-2-512 Digest\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("H(&<Data> ) = \n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, HashData);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("H (&<Content-ID> + ‘:’ + H(&<Data>))= \n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, UDFDataBufferString);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("H ( &<Content-ID> + ‘:’ + H(&<Data>))= \n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, UDFData);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dl>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dt>Text Presentation (100 bit)\n{0}", _Indent);
				_Output.Write ("<dd>{1}\n{0}", _Indent, UDF.DataToFormat (DataBytes, ContentType, 100));
				_Output.Write ("<dt>Text Presentation (125 bit)\n{0}", _Indent);
				_Output.Write ("<dd>{1}\n{0}", _Indent, UDF.DataToFormat (DataBytes, ContentType, 125));
				_Output.Write ("<dt>Text Presentation (150 bit)\n{0}", _Indent);
				_Output.Write ("<dd>{1}\n{0}", _Indent, UDF.DataToFormat (DataBytes, ContentType, 150));
				_Output.Write ("<dt>Text Presentation (250 bit)\n{0}", _Indent);
				_Output.Write ("<dd>{1}\n{0}", _Indent, UDF.DataToFormat (DataBytes, ContentType, 250));
				_Output.Write ("</dl>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Using SHA-3-512 Digest\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("H(&<Data> ) = \n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, HashData3);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("H (&<Content-ID> + ‘:’ + H(&<Data>))= \n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, UDFDataBufferString3);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("H ( &<Content-ID> + ‘:’ + H(&<Data>))= \n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, UDFData3);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dl>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dt>Text Presentation (100 bit)\n{0}", _Indent);
				_Output.Write ("<dd>{1}\n{0}", _Indent, UDF.DataToFormat (DataBytes, ContentType, 100, CryptoAlgorithmID.SHA_3_512));
				_Output.Write ("<dt>Text Presentation (125 bit)\n{0}", _Indent);
				_Output.Write ("<dd>{1}\n{0}", _Indent, UDF.DataToFormat (DataBytes, ContentType, 125, CryptoAlgorithmID.SHA_3_512));
				_Output.Write ("<dt>Text Presentation (150 bit)\n{0}", _Indent);
				_Output.Write ("<dd>{1}\n{0}", _Indent, UDF.DataToFormat (DataBytes, ContentType, 150, CryptoAlgorithmID.SHA_3_512));
				_Output.Write ("<dt>Text Presentation (250 bit)\n{0}", _Indent);
				_Output.Write ("<dd>{1}\n{0}", _Indent, UDF.DataToFormat (DataBytes, ContentType, 250, CryptoAlgorithmID.SHA_3_512));
				_Output.Write ("</dl>\n{0}", _Indent);
				}
			}
		

		//
		// MeshExamplesUDFCompressed
		//
		public static void MeshExamplesUDFCompressed (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesUDFCompressed.md")) {
				var _Indent = ""; 
				 var ContentType = "text/plain";
				 var ContentTypeString = ContentType.ToUTF8().ToStringBase16FormatHex();
				 var DataString = "290668103";
				 var DataBytes = DataString.ToUTF8();
				 var DataBytesString = DataBytes.ToStringBase16FormatHex();
				 var HashData = Goedel.Cryptography.Platform.SHA2_512.Process(DataBytes).ToStringBase16FormatHex();
				 var UDFDataBuffer = UDF.UDFBuffer(DataBytes, ContentType);
				 var UDFDataBufferString = UDFDataBuffer.ToStringBase16FormatHex();
				 var UDFData = Goedel.Cryptography.Platform.SHA2_512.Process(UDFDataBuffer).ToStringBase16FormatHex();
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Example\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The string \"290668103\" has a SHA-2-512 UDF fingerprint with 29 leading zero bits. The inputs\n{0}", _Indent);
				_Output.Write ("to the fingerprint are:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Data = {1}\n{0}", _Indent, DataBytesString);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("ContentType = {1}\n{0}", _Indent, ContentTypeString);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The 100 bit UDF fingerprint is:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dt>Text Presentation (100 bit)\n{0}", _Indent);
				_Output.Write ("<dd>MF3VV-FOFE2-CLRW (Maybe)\n{0}", _Indent);
				_Output.Write ("</dl>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<B>NB: The above is not generated from code and might well be incorrect.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// MeshExamplesSIN
		//
		public static void MeshExamplesSIN (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesSIN.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A SIN is an Internet Identifier that contains a fingerprint of a root of trust that may be used to verify the interpretation of the identifier. This section describes the manner in which SINs are used. The following section describes their construction using Uniform Data Fingerprints [I-D.hallambaker-udf]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For example, Example Inc holds the domain name example.com and has deployed a private CA whose root of trust is a PKIX certificate with the UDF fingerprint MB2GK-6DUF5-YGYYL-JNY5E-RWSHZ.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice is an employee of Example Inc., she uses three email addresses:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("alice@example.com\n{0}", _Indent);
				_Output.Write ("A regular email address (not a SIN).\n{0}", _Indent);
				_Output.Write ("alice@mm--mb2gk-6duf5-ygyyl-jny5e-rwshz.example.com\n{0}", _Indent);
				_Output.Write ("A strong email address that is backwards compatible.\n{0}", _Indent);
				_Output.Write ("alice@example.com.mm--mb2gk-6duf5-ygyyl-jny5e-rwshz\n{0}", _Indent);
				_Output.Write ("A strong email address that is backwards incompatible.\n{0}", _Indent);
				_Output.Write ("All three forms of the address are valid RFC822 addresses and may be used in a legacy email client, stored in an address book application, etc. But the ability of a legacy client to make use of the address differs. Addresses of the first type may always be used. Addresses of the second type may only be used if an appropriate MX record is provisioned. Addresses of the third type will always fail unless the resolver understands that it is a SIN requiring special processing.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("When specified as the destination address in a Mail User Application (MUA), these addresses have the following interpretations:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("alice@example.com\n{0}", _Indent);
				_Output.Write ("Send mail to Alice without requiring security enhancements.\n{0}", _Indent);
				_Output.Write ("alice@mm--mb2gk-6duf5-ygyyl-jny5e-rwshz.example.com\n{0}", _Indent);
				_Output.Write ("Send mail to Alice. If the MUA is SIN-Aware, it MUST resolve the security policy specified by the fingerprint and apply security enhancements as mandated by that policy.\n{0}", _Indent);
				_Output.Write ("alice@example.com.mm--mb2gk-6duf5-ygyyl-jny5e-rwshz\n{0}", _Indent);
				_Output.Write ("Only send mail to Alice if the MUA is SIN-Aware, it MUST resolve the security policy specified by the fingerprint and apply security enhancements as mandated by that policy.\n{0}", _Indent);
				_Output.Write ("These rules allow Bob to send email to Alice with either ‘best effort’ security or mandatory security as the circumstances demand\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// MeshExamplesSIN2
		//
		public static void MeshExamplesSIN2 (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesSIN2.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A security policy may be implicit or explicit depending on the root of trust referenced and the context in which it is used.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since many Internet applications are already designed to make use of a PKIX based trust infrastructure, the fingerprint of a PKIX root of trust provides sufficient information to deduce an appropriate security policy in many instances. For example:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("https://mb2gk-6duf5-ygyyl-jny5e-rwshz.example.com/\n{0}", _Indent);
				_Output.Write ("Connect to example.com using a TLS connection with a certificate that is valid in a chain of trust that contains a certificate with the fingerprint mb2gk.\n{0}", _Indent);
				_Output.Write ("IMAP Server: mb2gk-6duf5-ygyyl-jny5e-rwshz.example.com\n{0}", _Indent);
				_Output.Write ("Connect to the IMAP server example.com over a TLS connection with a certificate that is valid in a chain of trust that contains a certificate with the fingerprint mb2gk.\n{0}", _Indent);
				_Output.Write ("mailto:alice@example.com.mm--mb2gk-6duf5-ygyyl-jny5e-rwshz\n{0}", _Indent);
				_Output.Write ("Encrypt mail messages using S/MIME using an S/MIME certificate that is valid in a chain of trust that contains a certificate with the fingerprint mb2gk.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
