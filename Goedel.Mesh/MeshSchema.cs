
//  Copyright (c) 2014 by .
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
//  //Header
// With all fields as properties

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;




using Goedel.Cryptography.Jose;


namespace Goedel.Mesh {


    /// <summary>
    /// 
    /// </summary>
	public abstract partial class MeshItem : Goedel.Protocol.JSONObject {

        /// <summary>
        /// 
        /// </summary>
		public override string Tag () {
			return "MeshItem";
			}

        /// <summary>
        /// Default constructor.
        /// </summary>
		public MeshItem () {
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded stream.
        /// </summary>
		public MeshItem (JSONReader JSONReader) {
			Deserialize (JSONReader);
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded string.
        /// </summary>
		public MeshItem (string _String) {
			Deserialize (_String);
			_Initialize () ;
			}

		/// <summary>
        /// Construct an instance from the specified tagged JSONReader stream.
        /// </summary>
        public static void Deserialize(JSONReader JSONReader, out JSONObject Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "PublicKey" : {
					var Result = new PublicKey ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "SignedData" : {
					var Result = new SignedData ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "EncryptedData" : {
					var Result = new EncryptedData ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Entry" : {
					var Result = new Entry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "SignedProfile" : {
					var Result = new SignedProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Profile" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}


				case "SignedDeviceProfile" : {
					var Result = new SignedDeviceProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "DeviceProfile" : {
					var Result = new DeviceProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "DevicePrivateProfile" : {
					var Result = new DevicePrivateProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "SignedMasterProfile" : {
					var Result = new SignedMasterProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "MasterProfile" : {
					var Result = new MasterProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "SignedPersonalProfile" : {
					var Result = new SignedPersonalProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "PersonalProfile" : {
					var Result = new PersonalProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "SignedApplicationProfile" : {
					var Result = new SignedApplicationProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "EncryptedProfile" : {
					var Result = new EncryptedProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ApplicationProfile" : {
					var Result = new ApplicationProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ApplicationProfileEntry" : {
					var Result = new ApplicationProfileEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Connection" : {
					var Result = new Connection ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "PasswordProfile" : {
					var Result = new PasswordProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "PasswordProfilePrivate" : {
					var Result = new PasswordProfilePrivate ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "PasswordEntry" : {
					var Result = new PasswordEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "MailProfile" : {
					var Result = new MailProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "MailProfilePrivate" : {
					var Result = new MailProfilePrivate ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "NetworkProfile" : {
					var Result = new NetworkProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "NetworkProfilePrivate" : {
					var Result = new NetworkProfilePrivate ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "EscrowEntry" : {
					var Result = new EscrowEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "OfflineEscrowEntry" : {
					var Result = new OfflineEscrowEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "OnlineEscrowEntry" : {
					var Result = new OnlineEscrowEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "EscrowedKeySet" : {
					var Result = new EscrowedKeySet ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ConnectionRequest" : {
					var Result = new ConnectionRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "SignedConnectionRequest" : {
					var Result = new SignedConnectionRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ConnectionResult" : {
					var Result = new ConnectionResult ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "SignedConnectionResult" : {
					var Result = new SignedConnectionResult ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}	
			JSONReader.EndObject ();
            }
		}



		// Service Dispatch Classes



		// Transaction Classes
	/// <summary>
	///
	/// Container for public key pair data
	/// </summary>
	public partial class PublicKey : MeshItem {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						UDF {
			get {return _UDF;}			
			set {_UDF = value;}
			}
		string						_UDF ;
        /// <summary>
        /// 
        /// </summary>
		public virtual byte[]						X509Certificate {
			get {return _X509Certificate;}			
			set {_X509Certificate = value;}
			}
		byte[]						_X509Certificate ;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<byte[]>				X509Chain {
			get {return _X509Chain;}			
			set {_X509Chain = value;}
			}
		List<byte[]>				_X509Chain;
        /// <summary>
        /// 
        /// </summary>
		public virtual byte[]						X509CSR {
			get {return _X509CSR;}			
			set {_X509CSR = value;}
			}
		byte[]						_X509CSR ;
        /// <summary>
        /// 
        /// </summary>
		public virtual Key						PublicParameters {
			get {return _PublicParameters;}			
			set {_PublicParameters = value;}
			}
		Key						_PublicParameters ;
        /// <summary>
        /// 
        /// </summary>
		public virtual Key						PrivateParameters {
			get {return _PrivateParameters;}			
			set {_PrivateParameters = value;}
			}
		Key						_PrivateParameters ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "PublicKey";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public PublicKey () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public PublicKey (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (UDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("UDF", 1);
					_Writer.WriteString (UDF);
				}
			if (X509Certificate != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("X509Certificate", 1);
					_Writer.WriteBinary (X509Certificate);
				}
			if (X509Chain != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("X509Chain", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in X509Chain) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteBinary (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (X509CSR != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("X509CSR", 1);
					_Writer.WriteBinary (X509CSR);
				}
			if (PublicParameters != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PublicParameters", 1);
					// expand this to a tagged structure
					//PublicParameters.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(PublicParameters.Tag(), 1);
						bool firstinner = true;
						PublicParameters.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (PrivateParameters != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PrivateParameters", 1);
					// expand this to a tagged structure
					//PrivateParameters.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(PrivateParameters.Tag(), 1);
						bool firstinner = true;
						PrivateParameters.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new PublicKey From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new PublicKey From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new PublicKey (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "PublicKey" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new PublicKey FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "PublicKey" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new PublicKey FromTagged (string _Input) {
			//PublicKey _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new PublicKey  FromTagged (JSONReader JSONReader) {
			PublicKey Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "PublicKey" : {
					var Result = new PublicKey ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "UDF" : {
					UDF = JSONReader.ReadString ();
					break;
					}
				case "X509Certificate" : {
					X509Certificate = JSONReader.ReadBinary ();
					break;
					}
				case "X509Chain" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					X509Chain = new List <byte[]> ();
					while (_Going) {
						byte[] _Item = JSONReader.ReadBinary ();
						X509Chain.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "X509CSR" : {
					X509CSR = JSONReader.ReadBinary ();
					break;
					}
				case "PublicParameters" : {
					PublicParameters = Key.FromTagged (JSONReader) ;  // A tagged structure
					break;
					}
				case "PrivateParameters" : {
					PrivateParameters = Key.FromTagged (JSONReader) ;  // A tagged structure
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Container for JOSE signed data and related attributes.
	/// </summary>
	public partial class SignedData : MeshItem {
        /// <summary>
        /// 
        /// </summary>
		public virtual byte[]						Data {
			get {return _Data;}			
			set {_Data = value;}
			}
		byte[]						_Data ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SignedData";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SignedData () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public SignedData (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Data != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Data", 1);
					_Writer.WriteBinary (Data);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignedData From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignedData From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SignedData (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "SignedData" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignedData FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "SignedData" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignedData FromTagged (string _Input) {
			//SignedData _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new SignedData  FromTagged (JSONReader JSONReader) {
			SignedData Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "SignedData" : {
					var Result = new SignedData ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Data" : {
					Data = JSONReader.ReadBinary ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Container for JOSE encrypted data and related attributes.
	/// </summary>
	public partial class EncryptedData : MeshItem {
        /// <summary>
        /// 
        /// </summary>
		public virtual byte[]						Data {
			get {return _Data;}			
			set {_Data = value;}
			}
		byte[]						_Data ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "EncryptedData";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public EncryptedData () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public EncryptedData (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Data != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Data", 1);
					_Writer.WriteBinary (Data);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new EncryptedData From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new EncryptedData From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new EncryptedData (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "EncryptedData" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new EncryptedData FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "EncryptedData" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new EncryptedData FromTagged (string _Input) {
			//EncryptedData _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new EncryptedData  FromTagged (JSONReader JSONReader) {
			EncryptedData Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "EncryptedData" : {
					var Result = new EncryptedData ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Data" : {
					Data = JSONReader.ReadBinary ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Base class for all Mesh Profile objects.
	/// </summary>
	public partial class Entry : MeshItem {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Identifier {
			get {return _Identifier;}			
			set {_Identifier = value;}
			}
		string						_Identifier ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Entry";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Entry () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Entry (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Identifier != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Identifier", 1);
					_Writer.WriteString (Identifier);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new Entry From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Entry From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Entry (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "Entry" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Entry FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "Entry" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new Entry FromTagged (string _Input) {
			//Entry _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new Entry  FromTagged (JSONReader JSONReader) {
			Entry Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "Entry" : {
					var Result = new Entry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedProfile" : {
					var Result = new SignedProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedDeviceProfile" : {
					var Result = new SignedDeviceProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedMasterProfile" : {
					var Result = new SignedMasterProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedPersonalProfile" : {
					var Result = new SignedPersonalProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedApplicationProfile" : {
					var Result = new SignedApplicationProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedConnectionRequest" : {
					var Result = new SignedConnectionRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedConnectionResult" : {
					var Result = new SignedConnectionResult ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "Profile" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "DeviceProfile" : {
					var Result = new DeviceProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "MasterProfile" : {
					var Result = new MasterProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "PersonalProfile" : {
					var Result = new PersonalProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ApplicationProfile" : {
					var Result = new ApplicationProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "PasswordProfile" : {
					var Result = new PasswordProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "MailProfile" : {
					var Result = new MailProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "NetworkProfile" : {
					var Result = new NetworkProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "EncryptedProfile" : {
					var Result = new EncryptedProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "EscrowEntry" : {
					var Result = new EscrowEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "OfflineEscrowEntry" : {
					var Result = new OfflineEscrowEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "OnlineEscrowEntry" : {
					var Result = new OnlineEscrowEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Identifier" : {
					Identifier = JSONReader.ReadString ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Contains a signed profile entry
	/// </summary>
	public partial class SignedProfile : Entry {
        /// <summary>
        /// 
        /// </summary>
		public virtual JoseWebSignature						SignedData {
			get {return _SignedData;}			
			set {_SignedData = value;}
			}
		JoseWebSignature						_SignedData ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SignedProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SignedProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public SignedProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Entry)this).SerializeX(_Writer, false, ref _first);
			if (SignedData != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SignedData", 1);
					SignedData.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignedProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignedProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SignedProfile (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "SignedProfile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignedProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "SignedProfile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignedProfile FromTagged (string _Input) {
			//SignedProfile _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new SignedProfile  FromTagged (JSONReader JSONReader) {
			SignedProfile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "SignedProfile" : {
					var Result = new SignedProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedDeviceProfile" : {
					var Result = new SignedDeviceProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedMasterProfile" : {
					var Result = new SignedMasterProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedPersonalProfile" : {
					var Result = new SignedPersonalProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedApplicationProfile" : {
					var Result = new SignedApplicationProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedConnectionRequest" : {
					var Result = new SignedConnectionRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "SignedConnectionResult" : {
					var Result = new SignedConnectionResult ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "SignedData" : {
					// An untagged structure
					SignedData = new JoseWebSignature (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Parent class from which all profile types are derived
	/// </summary>
	abstract public partial class Profile : Entry {
		/// <summary>
        /// 
        /// </summary>
		public virtual List<string>				Names {
			get {return _Names;}			
			set {_Names = value;}
			}
		List<string>				_Names;
		bool								__Updated = false;
		private DateTime						_Updated;
        /// <summary>
        /// 
        /// </summary>
		public virtual DateTime						Updated {
			get {return _Updated;}
			set {_Updated = value; __Updated = true; }
			}
        /// <summary>
        /// 
        /// </summary>
		public virtual string						NotaryToken {
			get {return _NotaryToken;}			
			set {_NotaryToken = value;}
			}
		string						_NotaryToken ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Profile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Profile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Profile (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Entry)this).SerializeX(_Writer, false, ref _first);
			if (Names != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Names", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Names) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (__Updated){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Updated", 1);
					_Writer.WriteDateTime (Updated);
				}
			if (NotaryToken != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("NotaryToken", 1);
					_Writer.WriteString (NotaryToken);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "Profile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Profile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "Profile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new Profile FromTagged (string _Input) {
			//Profile _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new Profile  FromTagged (JSONReader JSONReader) {
			Profile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "Profile" : {
					Out = null;
					throw new Exception ("Can't create abstract type");
					}

				case "DeviceProfile" : {
					var Result = new DeviceProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "MasterProfile" : {
					var Result = new MasterProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "PersonalProfile" : {
					var Result = new PersonalProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ApplicationProfile" : {
					var Result = new ApplicationProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "PasswordProfile" : {
					var Result = new PasswordProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "MailProfile" : {
					var Result = new MailProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "NetworkProfile" : {
					var Result = new NetworkProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Names" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Names = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Names.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Updated" : {
					Updated = JSONReader.ReadDateTime ();
					break;
					}
				case "NotaryToken" : {
					NotaryToken = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Contains a signed device profile
	/// </summary>
	public partial class SignedDeviceProfile : SignedProfile {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SignedDeviceProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SignedDeviceProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public SignedDeviceProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((SignedProfile)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignedDeviceProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignedDeviceProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SignedDeviceProfile (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "SignedDeviceProfile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignedDeviceProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "SignedDeviceProfile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignedDeviceProfile FromTagged (string _Input) {
			//SignedDeviceProfile _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new SignedDeviceProfile  FromTagged (JSONReader JSONReader) {
			SignedDeviceProfile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "SignedDeviceProfile" : {
					var Result = new SignedDeviceProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Describes a mesh device.
	/// </summary>
	public partial class DeviceProfile : Profile {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Description {
			get {return _Description;}			
			set {_Description = value;}
			}
		string						_Description ;
        /// <summary>
        /// 
        /// </summary>
		public virtual PublicKey						DeviceSignatureKey {
			get {return _DeviceSignatureKey;}			
			set {_DeviceSignatureKey = value;}
			}
		PublicKey						_DeviceSignatureKey ;
        /// <summary>
        /// 
        /// </summary>
		public virtual PublicKey						DeviceAuthenticationKey {
			get {return _DeviceAuthenticationKey;}			
			set {_DeviceAuthenticationKey = value;}
			}
		PublicKey						_DeviceAuthenticationKey ;
        /// <summary>
        /// 
        /// </summary>
		public virtual PublicKey						DeviceEncryptiontionKey {
			get {return _DeviceEncryptiontionKey;}			
			set {_DeviceEncryptiontionKey = value;}
			}
		PublicKey						_DeviceEncryptiontionKey ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "DeviceProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public DeviceProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public DeviceProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Profile)this).SerializeX(_Writer, false, ref _first);
			if (Description != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Description", 1);
					_Writer.WriteString (Description);
				}
			if (DeviceSignatureKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceSignatureKey", 1);
					DeviceSignatureKey.Serialize (_Writer, false);
				}
			if (DeviceAuthenticationKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceAuthenticationKey", 1);
					DeviceAuthenticationKey.Serialize (_Writer, false);
				}
			if (DeviceEncryptiontionKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceEncryptiontionKey", 1);
					DeviceEncryptiontionKey.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new DeviceProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new DeviceProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new DeviceProfile (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "DeviceProfile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new DeviceProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "DeviceProfile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new DeviceProfile FromTagged (string _Input) {
			//DeviceProfile _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new DeviceProfile  FromTagged (JSONReader JSONReader) {
			DeviceProfile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "DeviceProfile" : {
					var Result = new DeviceProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Description" : {
					Description = JSONReader.ReadString ();
					break;
					}
				case "DeviceSignatureKey" : {
					// An untagged structure
					DeviceSignatureKey = new PublicKey (JSONReader);
 
					break;
					}
				case "DeviceAuthenticationKey" : {
					// An untagged structure
					DeviceAuthenticationKey = new PublicKey (JSONReader);
 
					break;
					}
				case "DeviceEncryptiontionKey" : {
					// An untagged structure
					DeviceEncryptiontionKey = new PublicKey (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Private portion of device encryption profile. 
	/// </summary>
	public partial class DevicePrivateProfile : MeshItem {
        /// <summary>
        /// 
        /// </summary>
		public virtual Key						DeviceSignatureKey {
			get {return _DeviceSignatureKey;}			
			set {_DeviceSignatureKey = value;}
			}
		Key						_DeviceSignatureKey ;
        /// <summary>
        /// 
        /// </summary>
		public virtual Key						DeviceAuthenticationKey {
			get {return _DeviceAuthenticationKey;}			
			set {_DeviceAuthenticationKey = value;}
			}
		Key						_DeviceAuthenticationKey ;
        /// <summary>
        /// 
        /// </summary>
		public virtual Key						DeviceEncryptiontionKey {
			get {return _DeviceEncryptiontionKey;}			
			set {_DeviceEncryptiontionKey = value;}
			}
		Key						_DeviceEncryptiontionKey ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "DevicePrivateProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public DevicePrivateProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public DevicePrivateProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (DeviceSignatureKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceSignatureKey", 1);
					DeviceSignatureKey.Serialize (_Writer, false);
				}
			if (DeviceAuthenticationKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceAuthenticationKey", 1);
					DeviceAuthenticationKey.Serialize (_Writer, false);
				}
			if (DeviceEncryptiontionKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceEncryptiontionKey", 1);
					DeviceEncryptiontionKey.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new DevicePrivateProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new DevicePrivateProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new DevicePrivateProfile (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "DevicePrivateProfile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new DevicePrivateProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "DevicePrivateProfile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new DevicePrivateProfile FromTagged (string _Input) {
			//DevicePrivateProfile _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new DevicePrivateProfile  FromTagged (JSONReader JSONReader) {
			DevicePrivateProfile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "DevicePrivateProfile" : {
					var Result = new DevicePrivateProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "DeviceSignatureKey" : {
					// An untagged structure
					DeviceSignatureKey = new Key (JSONReader);
 
					break;
					}
				case "DeviceAuthenticationKey" : {
					// An untagged structure
					DeviceAuthenticationKey = new Key (JSONReader);
 
					break;
					}
				case "DeviceEncryptiontionKey" : {
					// An untagged structure
					DeviceEncryptiontionKey = new Key (JSONReader);
 
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Contains a signed Personal master profile
	/// </summary>
	public partial class SignedMasterProfile : SignedProfile {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SignedMasterProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SignedMasterProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public SignedMasterProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((SignedProfile)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignedMasterProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignedMasterProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SignedMasterProfile (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "SignedMasterProfile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignedMasterProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "SignedMasterProfile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignedMasterProfile FromTagged (string _Input) {
			//SignedMasterProfile _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new SignedMasterProfile  FromTagged (JSONReader JSONReader) {
			SignedMasterProfile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "SignedMasterProfile" : {
					var Result = new SignedMasterProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Describes the long term parameters associated with a personal profile.
	/// </summary>
	public partial class MasterProfile : Profile {
        /// <summary>
        /// 
        /// </summary>
		public virtual PublicKey						MasterSignatureKey {
			get {return _MasterSignatureKey;}			
			set {_MasterSignatureKey = value;}
			}
		PublicKey						_MasterSignatureKey ;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<PublicKey>				MasterEscrowKeys {
			get {return _MasterEscrowKeys;}			
			set {_MasterEscrowKeys = value;}
			}
		List<PublicKey>				_MasterEscrowKeys;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<PublicKey>				OnlineSignatureKeys {
			get {return _OnlineSignatureKeys;}			
			set {_OnlineSignatureKeys = value;}
			}
		List<PublicKey>				_OnlineSignatureKeys;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "MasterProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public MasterProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public MasterProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Profile)this).SerializeX(_Writer, false, ref _first);
			if (MasterSignatureKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MasterSignatureKey", 1);
					MasterSignatureKey.Serialize (_Writer, false);
				}
			if (MasterEscrowKeys != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MasterEscrowKeys", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in MasterEscrowKeys) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (OnlineSignatureKeys != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("OnlineSignatureKeys", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in OnlineSignatureKeys) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new MasterProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new MasterProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new MasterProfile (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "MasterProfile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new MasterProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "MasterProfile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new MasterProfile FromTagged (string _Input) {
			//MasterProfile _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new MasterProfile  FromTagged (JSONReader JSONReader) {
			MasterProfile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "MasterProfile" : {
					var Result = new MasterProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "MasterSignatureKey" : {
					// An untagged structure
					MasterSignatureKey = new PublicKey (JSONReader);
 
					break;
					}
				case "MasterEscrowKeys" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					MasterEscrowKeys = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new PublicKey (JSONReader);
						MasterEscrowKeys.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "OnlineSignatureKeys" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					OnlineSignatureKeys = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new PublicKey (JSONReader);
						OnlineSignatureKeys.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Contains a signed Personal current profile
	/// </summary>
	public partial class SignedPersonalProfile : SignedProfile {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SignedPersonalProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SignedPersonalProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public SignedPersonalProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((SignedProfile)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignedPersonalProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignedPersonalProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SignedPersonalProfile (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "SignedPersonalProfile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignedPersonalProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "SignedPersonalProfile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignedPersonalProfile FromTagged (string _Input) {
			//SignedPersonalProfile _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new SignedPersonalProfile  FromTagged (JSONReader JSONReader) {
			SignedPersonalProfile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "SignedPersonalProfile" : {
					var Result = new SignedPersonalProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Describes the current applications and devices connected to a 
	/// personal master profile.
	/// </summary>
	public partial class PersonalProfile : Profile {
        /// <summary>
        /// 
        /// </summary>
		public virtual SignedMasterProfile						SignedMasterProfile {
			get {return _SignedMasterProfile;}			
			set {_SignedMasterProfile = value;}
			}
		SignedMasterProfile						_SignedMasterProfile ;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<SignedDeviceProfile>				Devices {
			get {return _Devices;}			
			set {_Devices = value;}
			}
		List<SignedDeviceProfile>				_Devices;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<ApplicationProfileEntry>				Applications {
			get {return _Applications;}			
			set {_Applications = value;}
			}
		List<ApplicationProfileEntry>				_Applications;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "PersonalProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public PersonalProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public PersonalProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Profile)this).SerializeX(_Writer, false, ref _first);
			if (SignedMasterProfile != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SignedMasterProfile", 1);
					SignedMasterProfile.Serialize (_Writer, false);
				}
			if (Devices != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Devices", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Devices) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (Applications != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Applications", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Applications) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new PersonalProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new PersonalProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new PersonalProfile (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "PersonalProfile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new PersonalProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "PersonalProfile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new PersonalProfile FromTagged (string _Input) {
			//PersonalProfile _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new PersonalProfile  FromTagged (JSONReader JSONReader) {
			PersonalProfile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "PersonalProfile" : {
					var Result = new PersonalProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "SignedMasterProfile" : {
					// An untagged structure
					SignedMasterProfile = new SignedMasterProfile (JSONReader);
 
					break;
					}
				case "Devices" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Devices = new List <SignedDeviceProfile> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new SignedDeviceProfile (JSONReader);
						Devices.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Applications" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Applications = new List <ApplicationProfileEntry> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new ApplicationProfileEntry (JSONReader);
						Applications.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Contains a signed device profile
	/// </summary>
	public partial class SignedApplicationProfile : SignedProfile {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SignedApplicationProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SignedApplicationProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public SignedApplicationProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((SignedProfile)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignedApplicationProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignedApplicationProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SignedApplicationProfile (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "SignedApplicationProfile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignedApplicationProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "SignedApplicationProfile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignedApplicationProfile FromTagged (string _Input) {
			//SignedApplicationProfile _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new SignedApplicationProfile  FromTagged (JSONReader JSONReader) {
			SignedApplicationProfile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "SignedApplicationProfile" : {
					var Result = new SignedApplicationProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Contains an encrypted profile entry
	/// </summary>
	public partial class EncryptedProfile : Entry {
        /// <summary>
        /// 
        /// </summary>
		public virtual JoseWebEncryption						EncryptedData {
			get {return _EncryptedData;}			
			set {_EncryptedData = value;}
			}
		JoseWebEncryption						_EncryptedData ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "EncryptedProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public EncryptedProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public EncryptedProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Entry)this).SerializeX(_Writer, false, ref _first);
			if (EncryptedData != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EncryptedData", 1);
					EncryptedData.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new EncryptedProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new EncryptedProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new EncryptedProfile (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "EncryptedProfile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new EncryptedProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "EncryptedProfile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new EncryptedProfile FromTagged (string _Input) {
			//EncryptedProfile _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new EncryptedProfile  FromTagged (JSONReader JSONReader) {
			EncryptedProfile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "EncryptedProfile" : {
					var Result = new EncryptedProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "EncryptedData" : {
					// An untagged structure
					EncryptedData = new JoseWebEncryption (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Parent class from which all application profiles inherit.
	/// </summary>
	public partial class ApplicationProfile : Profile {
        /// <summary>
        /// 
        /// </summary>
		public virtual JoseWebEncryption						EncryptedData {
			get {return _EncryptedData;}			
			set {_EncryptedData = value;}
			}
		JoseWebEncryption						_EncryptedData ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ApplicationProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ApplicationProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public ApplicationProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Profile)this).SerializeX(_Writer, false, ref _first);
			if (EncryptedData != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EncryptedData", 1);
					EncryptedData.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new ApplicationProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ApplicationProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ApplicationProfile (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "ApplicationProfile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ApplicationProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "ApplicationProfile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new ApplicationProfile FromTagged (string _Input) {
			//ApplicationProfile _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new ApplicationProfile  FromTagged (JSONReader JSONReader) {
			ApplicationProfile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "ApplicationProfile" : {
					var Result = new ApplicationProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "PasswordProfile" : {
					var Result = new PasswordProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "MailProfile" : {
					var Result = new MailProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "NetworkProfile" : {
					var Result = new NetworkProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "EncryptedData" : {
					// An untagged structure
					EncryptedData = new JoseWebEncryption (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class ApplicationProfileEntry : MeshItem {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Identifier {
			get {return _Identifier;}			
			set {_Identifier = value;}
			}
		string						_Identifier ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Type {
			get {return _Type;}			
			set {_Type = value;}
			}
		string						_Type ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Friendly {
			get {return _Friendly;}			
			set {_Friendly = value;}
			}
		string						_Friendly ;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<string>				SignID {
			get {return _SignID;}			
			set {_SignID = value;}
			}
		List<string>				_SignID;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<string>				DecryptID {
			get {return _DecryptID;}			
			set {_DecryptID = value;}
			}
		List<string>				_DecryptID;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ApplicationProfileEntry";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ApplicationProfileEntry () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public ApplicationProfileEntry (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Identifier != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Identifier", 1);
					_Writer.WriteString (Identifier);
				}
			if (Type != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Type", 1);
					_Writer.WriteString (Type);
				}
			if (Friendly != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Friendly", 1);
					_Writer.WriteString (Friendly);
				}
			if (SignID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SignID", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in SignID) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (DecryptID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DecryptID", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in DecryptID) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new ApplicationProfileEntry From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ApplicationProfileEntry From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ApplicationProfileEntry (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "ApplicationProfileEntry" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ApplicationProfileEntry FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "ApplicationProfileEntry" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new ApplicationProfileEntry FromTagged (string _Input) {
			//ApplicationProfileEntry _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new ApplicationProfileEntry  FromTagged (JSONReader JSONReader) {
			ApplicationProfileEntry Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "ApplicationProfileEntry" : {
					var Result = new ApplicationProfileEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Identifier" : {
					Identifier = JSONReader.ReadString ();
					break;
					}
				case "Type" : {
					Type = JSONReader.ReadString ();
					break;
					}
				case "Friendly" : {
					Friendly = JSONReader.ReadString ();
					break;
					}
				case "SignID" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					SignID = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						SignID.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "DecryptID" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					DecryptID = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						DecryptID.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Describes network connection parameters for an application
	/// </summary>
	public partial class Connection : MeshItem {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						ServiceName {
			get {return _ServiceName;}			
			set {_ServiceName = value;}
			}
		string						_ServiceName ;
		bool								__Port = false;
		private int						_Port;
        /// <summary>
        /// 
        /// </summary>
		public virtual int						Port {
			get {return _Port;}
			set {_Port = value; __Port = true; }
			}
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Prefix {
			get {return _Prefix;}			
			set {_Prefix = value;}
			}
		string						_Prefix ;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<string>				Security {
			get {return _Security;}			
			set {_Security = value;}
			}
		List<string>				_Security;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						UserName {
			get {return _UserName;}			
			set {_UserName = value;}
			}
		string						_UserName ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Password {
			get {return _Password;}			
			set {_Password = value;}
			}
		string						_Password ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						URI {
			get {return _URI;}			
			set {_URI = value;}
			}
		string						_URI ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Authentication {
			get {return _Authentication;}			
			set {_Authentication = value;}
			}
		string						_Authentication ;
		bool								__TimeOut = false;
		private int						_TimeOut;
        /// <summary>
        /// 
        /// </summary>
		public virtual int						TimeOut {
			get {return _TimeOut;}
			set {_TimeOut = value; __TimeOut = true; }
			}
		bool								__Polling = false;
		private bool						_Polling;
        /// <summary>
        /// 
        /// </summary>
		public virtual bool						Polling {
			get {return _Polling;}
			set {_Polling = value; __Polling = true; }
			}

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Connection";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Connection () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Connection (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (ServiceName != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ServiceName", 1);
					_Writer.WriteString (ServiceName);
				}
			if (__Port){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Port", 1);
					_Writer.WriteInteger32 (Port);
				}
			if (Prefix != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Prefix", 1);
					_Writer.WriteString (Prefix);
				}
			if (Security != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Security", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Security) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (UserName != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("UserName", 1);
					_Writer.WriteString (UserName);
				}
			if (Password != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Password", 1);
					_Writer.WriteString (Password);
				}
			if (URI != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("URI", 1);
					_Writer.WriteString (URI);
				}
			if (Authentication != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Authentication", 1);
					_Writer.WriteString (Authentication);
				}
			if (__TimeOut){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("TimeOut", 1);
					_Writer.WriteInteger32 (TimeOut);
				}
			if (__Polling){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Polling", 1);
					_Writer.WriteBoolean (Polling);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new Connection From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Connection From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Connection (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "Connection" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Connection FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "Connection" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new Connection FromTagged (string _Input) {
			//Connection _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new Connection  FromTagged (JSONReader JSONReader) {
			Connection Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "Connection" : {
					var Result = new Connection ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "ServiceName" : {
					ServiceName = JSONReader.ReadString ();
					break;
					}
				case "Port" : {
					Port = JSONReader.ReadInteger32 ();
					break;
					}
				case "Prefix" : {
					Prefix = JSONReader.ReadString ();
					break;
					}
				case "Security" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Security = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Security.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "UserName" : {
					UserName = JSONReader.ReadString ();
					break;
					}
				case "Password" : {
					Password = JSONReader.ReadString ();
					break;
					}
				case "URI" : {
					URI = JSONReader.ReadString ();
					break;
					}
				case "Authentication" : {
					Authentication = JSONReader.ReadString ();
					break;
					}
				case "TimeOut" : {
					TimeOut = JSONReader.ReadInteger32 ();
					break;
					}
				case "Polling" : {
					Polling = JSONReader.ReadBoolean ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Stores usernames and passwords
	/// </summary>
	public partial class PasswordProfile : ApplicationProfile {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "PasswordProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public PasswordProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public PasswordProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ApplicationProfile)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new PasswordProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new PasswordProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new PasswordProfile (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "PasswordProfile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new PasswordProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "PasswordProfile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new PasswordProfile FromTagged (string _Input) {
			//PasswordProfile _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new PasswordProfile  FromTagged (JSONReader JSONReader) {
			PasswordProfile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "PasswordProfile" : {
					var Result = new PasswordProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class PasswordProfilePrivate : MeshItem {
		/// <summary>
        /// 
        /// </summary>
		public virtual List<PasswordEntry>				Entries {
			get {return _Entries;}			
			set {_Entries = value;}
			}
		List<PasswordEntry>				_Entries;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "PasswordProfilePrivate";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public PasswordProfilePrivate () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public PasswordProfilePrivate (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Entries != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Entries", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Entries) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new PasswordProfilePrivate From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new PasswordProfilePrivate From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new PasswordProfilePrivate (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "PasswordProfilePrivate" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new PasswordProfilePrivate FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "PasswordProfilePrivate" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new PasswordProfilePrivate FromTagged (string _Input) {
			//PasswordProfilePrivate _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new PasswordProfilePrivate  FromTagged (JSONReader JSONReader) {
			PasswordProfilePrivate Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "PasswordProfilePrivate" : {
					var Result = new PasswordProfilePrivate ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Entries" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Entries = new List <PasswordEntry> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new PasswordEntry (JSONReader);
						Entries.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Username password entry for a single site
	/// </summary>
	public partial class PasswordEntry : MeshItem {
		/// <summary>
        /// 
        /// </summary>
		public virtual List<string>				Sites {
			get {return _Sites;}			
			set {_Sites = value;}
			}
		List<string>				_Sites;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Username {
			get {return _Username;}			
			set {_Username = value;}
			}
		string						_Username ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Password {
			get {return _Password;}			
			set {_Password = value;}
			}
		string						_Password ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "PasswordEntry";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public PasswordEntry () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public PasswordEntry (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Sites != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Sites", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Sites) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (Username != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Username", 1);
					_Writer.WriteString (Username);
				}
			if (Password != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Password", 1);
					_Writer.WriteString (Password);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new PasswordEntry From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new PasswordEntry From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new PasswordEntry (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "PasswordEntry" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new PasswordEntry FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "PasswordEntry" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new PasswordEntry FromTagged (string _Input) {
			//PasswordEntry _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new PasswordEntry  FromTagged (JSONReader JSONReader) {
			PasswordEntry Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "PasswordEntry" : {
					var Result = new PasswordEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Sites" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Sites = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Sites.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Username" : {
					Username = JSONReader.ReadString ();
					break;
					}
				case "Password" : {
					Password = JSONReader.ReadString ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Public profile describes mail receipt policy. Private describes
	/// Sending policy
	/// </summary>
	public partial class MailProfile : ApplicationProfile {
        /// <summary>
        /// 
        /// </summary>
		public virtual PublicKey						EncryptionPGP {
			get {return _EncryptionPGP;}			
			set {_EncryptionPGP = value;}
			}
		PublicKey						_EncryptionPGP ;
        /// <summary>
        /// 
        /// </summary>
		public virtual PublicKey						EncryptionSMIME {
			get {return _EncryptionSMIME;}			
			set {_EncryptionSMIME = value;}
			}
		PublicKey						_EncryptionSMIME ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "MailProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public MailProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public MailProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ApplicationProfile)this).SerializeX(_Writer, false, ref _first);
			if (EncryptionPGP != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EncryptionPGP", 1);
					EncryptionPGP.Serialize (_Writer, false);
				}
			if (EncryptionSMIME != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EncryptionSMIME", 1);
					EncryptionSMIME.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new MailProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new MailProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new MailProfile (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "MailProfile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new MailProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "MailProfile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new MailProfile FromTagged (string _Input) {
			//MailProfile _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new MailProfile  FromTagged (JSONReader JSONReader) {
			MailProfile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "MailProfile" : {
					var Result = new MailProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "EncryptionPGP" : {
					// An untagged structure
					EncryptionPGP = new PublicKey (JSONReader);
 
					break;
					}
				case "EncryptionSMIME" : {
					// An untagged structure
					EncryptionSMIME = new PublicKey (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Describes a mail account configuration
	/// Private profile contains connection settings for the inbound and
	/// outbound mail server(s) and cryptographic private keys. Public
	/// profile may contain security policy information for the sender.
	/// </summary>
	public partial class MailProfilePrivate : MeshItem {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						EmailAddress {
			get {return _EmailAddress;}			
			set {_EmailAddress = value;}
			}
		string						_EmailAddress ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						ReplyToAddress {
			get {return _ReplyToAddress;}			
			set {_ReplyToAddress = value;}
			}
		string						_ReplyToAddress ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						DisplayName {
			get {return _DisplayName;}			
			set {_DisplayName = value;}
			}
		string						_DisplayName ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						AccountName {
			get {return _AccountName;}			
			set {_AccountName = value;}
			}
		string						_AccountName ;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<Connection>				Inbound {
			get {return _Inbound;}			
			set {_Inbound = value;}
			}
		List<Connection>				_Inbound;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<Connection>				Outbound {
			get {return _Outbound;}			
			set {_Outbound = value;}
			}
		List<Connection>				_Outbound;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<PublicKey>				Sign {
			get {return _Sign;}			
			set {_Sign = value;}
			}
		List<PublicKey>				_Sign;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<PublicKey>				Encrypt {
			get {return _Encrypt;}			
			set {_Encrypt = value;}
			}
		List<PublicKey>				_Encrypt;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "MailProfilePrivate";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public MailProfilePrivate () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public MailProfilePrivate (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (EmailAddress != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EmailAddress", 1);
					_Writer.WriteString (EmailAddress);
				}
			if (ReplyToAddress != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ReplyToAddress", 1);
					_Writer.WriteString (ReplyToAddress);
				}
			if (DisplayName != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DisplayName", 1);
					_Writer.WriteString (DisplayName);
				}
			if (AccountName != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AccountName", 1);
					_Writer.WriteString (AccountName);
				}
			if (Inbound != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Inbound", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Inbound) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (Outbound != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Outbound", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Outbound) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (Sign != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Sign", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Sign) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (Encrypt != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Encrypt", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Encrypt) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new MailProfilePrivate From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new MailProfilePrivate From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new MailProfilePrivate (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "MailProfilePrivate" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new MailProfilePrivate FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "MailProfilePrivate" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new MailProfilePrivate FromTagged (string _Input) {
			//MailProfilePrivate _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new MailProfilePrivate  FromTagged (JSONReader JSONReader) {
			MailProfilePrivate Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "MailProfilePrivate" : {
					var Result = new MailProfilePrivate ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "EmailAddress" : {
					EmailAddress = JSONReader.ReadString ();
					break;
					}
				case "ReplyToAddress" : {
					ReplyToAddress = JSONReader.ReadString ();
					break;
					}
				case "DisplayName" : {
					DisplayName = JSONReader.ReadString ();
					break;
					}
				case "AccountName" : {
					AccountName = JSONReader.ReadString ();
					break;
					}
				case "Inbound" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Inbound = new List <Connection> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new Connection (JSONReader);
						Inbound.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Outbound" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Outbound = new List <Connection> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new Connection (JSONReader);
						Outbound.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Sign" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Sign = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new PublicKey (JSONReader);
						Sign.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Encrypt" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Encrypt = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new PublicKey (JSONReader);
						Encrypt.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Describes the network profile to follow
	/// </summary>
	public partial class NetworkProfile : ApplicationProfile {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "NetworkProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public NetworkProfile () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public NetworkProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ApplicationProfile)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new NetworkProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new NetworkProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new NetworkProfile (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "NetworkProfile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new NetworkProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "NetworkProfile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new NetworkProfile FromTagged (string _Input) {
			//NetworkProfile _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new NetworkProfile  FromTagged (JSONReader JSONReader) {
			NetworkProfile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "NetworkProfile" : {
					var Result = new NetworkProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Describes the network profile to follow
	/// </summary>
	public partial class NetworkProfilePrivate : MeshItem {
		/// <summary>
        /// 
        /// </summary>
		public virtual List<string>				Sites {
			get {return _Sites;}			
			set {_Sites = value;}
			}
		List<string>				_Sites;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<Connection>				DNS {
			get {return _DNS;}			
			set {_DNS = value;}
			}
		List<Connection>				_DNS;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<string>				Prefix {
			get {return _Prefix;}			
			set {_Prefix = value;}
			}
		List<string>				_Prefix;
        /// <summary>
        /// 
        /// </summary>
		public virtual byte[]						CTL {
			get {return _CTL;}			
			set {_CTL = value;}
			}
		byte[]						_CTL ;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<string>				WebPKI {
			get {return _WebPKI;}			
			set {_WebPKI = value;}
			}
		List<string>				_WebPKI;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "NetworkProfilePrivate";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public NetworkProfilePrivate () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public NetworkProfilePrivate (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Sites != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Sites", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Sites) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (DNS != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DNS", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in DNS) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (Prefix != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Prefix", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Prefix) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (CTL != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("CTL", 1);
					_Writer.WriteBinary (CTL);
				}
			if (WebPKI != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("WebPKI", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in WebPKI) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new NetworkProfilePrivate From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new NetworkProfilePrivate From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new NetworkProfilePrivate (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "NetworkProfilePrivate" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new NetworkProfilePrivate FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "NetworkProfilePrivate" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new NetworkProfilePrivate FromTagged (string _Input) {
			//NetworkProfilePrivate _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new NetworkProfilePrivate  FromTagged (JSONReader JSONReader) {
			NetworkProfilePrivate Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "NetworkProfilePrivate" : {
					var Result = new NetworkProfilePrivate ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Sites" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Sites = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Sites.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "DNS" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					DNS = new List <Connection> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new Connection (JSONReader);
						DNS.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Prefix" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Prefix = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Prefix.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "CTL" : {
					CTL = JSONReader.ReadBinary ();
					break;
					}
				case "WebPKI" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					WebPKI = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						WebPKI.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Contains escrowed data
	/// </summary>
	public partial class EscrowEntry : Entry {
        /// <summary>
        /// 
        /// </summary>
		public virtual JoseWebEncryption						EncryptedData {
			get {return _EncryptedData;}			
			set {_EncryptedData = value;}
			}
		JoseWebEncryption						_EncryptedData ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "EscrowEntry";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public EscrowEntry () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public EscrowEntry (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Entry)this).SerializeX(_Writer, false, ref _first);
			if (EncryptedData != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EncryptedData", 1);
					EncryptedData.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new EscrowEntry From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new EscrowEntry From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new EscrowEntry (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "EscrowEntry" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new EscrowEntry FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "EscrowEntry" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new EscrowEntry FromTagged (string _Input) {
			//EscrowEntry _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new EscrowEntry  FromTagged (JSONReader JSONReader) {
			EscrowEntry Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "EscrowEntry" : {
					var Result = new EscrowEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "OfflineEscrowEntry" : {
					var Result = new OfflineEscrowEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "OnlineEscrowEntry" : {
					var Result = new OnlineEscrowEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "EncryptedData" : {
					// An untagged structure
					EncryptedData = new JoseWebEncryption (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Contains data escrowed using the offline escrow mechanism.
	/// </summary>
	public partial class OfflineEscrowEntry : EscrowEntry {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "OfflineEscrowEntry";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public OfflineEscrowEntry () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public OfflineEscrowEntry (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((EscrowEntry)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new OfflineEscrowEntry From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new OfflineEscrowEntry From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new OfflineEscrowEntry (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "OfflineEscrowEntry" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new OfflineEscrowEntry FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "OfflineEscrowEntry" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new OfflineEscrowEntry FromTagged (string _Input) {
			//OfflineEscrowEntry _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new OfflineEscrowEntry  FromTagged (JSONReader JSONReader) {
			OfflineEscrowEntry Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "OfflineEscrowEntry" : {
					var Result = new OfflineEscrowEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Contains data escrowed using the online escrow mechanism.
	/// </summary>
	public partial class OnlineEscrowEntry : EscrowEntry {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "OnlineEscrowEntry";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public OnlineEscrowEntry () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public OnlineEscrowEntry (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((EscrowEntry)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new OnlineEscrowEntry From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new OnlineEscrowEntry From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new OnlineEscrowEntry (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "OnlineEscrowEntry" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new OnlineEscrowEntry FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "OnlineEscrowEntry" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new OnlineEscrowEntry FromTagged (string _Input) {
			//OnlineEscrowEntry _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new OnlineEscrowEntry  FromTagged (JSONReader JSONReader) {
			OnlineEscrowEntry Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "OnlineEscrowEntry" : {
					var Result = new OnlineEscrowEntry ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// A set of escrowed keys.
	/// </summary>
	public partial class EscrowedKeySet : MeshItem {
		/// <summary>
        /// 
        /// </summary>
		public virtual List<Key>				PrivateKeys {
			get {return _PrivateKeys;}			
			set {_PrivateKeys = value;}
			}
		List<Key>				_PrivateKeys;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "EscrowedKeySet";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public EscrowedKeySet () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public EscrowedKeySet (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (PrivateKeys != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PrivateKeys", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in PrivateKeys) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new EscrowedKeySet From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new EscrowedKeySet From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new EscrowedKeySet (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "EscrowedKeySet" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new EscrowedKeySet FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "EscrowedKeySet" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new EscrowedKeySet FromTagged (string _Input) {
			//EscrowedKeySet _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new EscrowedKeySet  FromTagged (JSONReader JSONReader) {
			EscrowedKeySet Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "EscrowedKeySet" : {
					var Result = new EscrowedKeySet ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "PrivateKeys" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					PrivateKeys = new List <Key> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new Key (JSONReader);
						PrivateKeys.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Describes a connection request.
	/// </summary>
	public partial class ConnectionRequest : MeshItem {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						ParentUDF {
			get {return _ParentUDF;}			
			set {_ParentUDF = value;}
			}
		string						_ParentUDF ;
        /// <summary>
        /// 
        /// </summary>
		public virtual SignedDeviceProfile						Device {
			get {return _Device;}			
			set {_Device = value;}
			}
		SignedDeviceProfile						_Device ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ConnectionRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ConnectionRequest () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public ConnectionRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (ParentUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ParentUDF", 1);
					_Writer.WriteString (ParentUDF);
				}
			if (Device != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Device", 1);
					Device.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new ConnectionRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ConnectionRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ConnectionRequest (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "ConnectionRequest" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ConnectionRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "ConnectionRequest" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new ConnectionRequest FromTagged (string _Input) {
			//ConnectionRequest _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new ConnectionRequest  FromTagged (JSONReader JSONReader) {
			ConnectionRequest Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "ConnectionRequest" : {
					var Result = new ConnectionRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ConnectionResult" : {
					var Result = new ConnectionResult ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "ParentUDF" : {
					ParentUDF = JSONReader.ReadString ();
					break;
					}
				case "Device" : {
					// An untagged structure
					Device = new SignedDeviceProfile (JSONReader);
 
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Contains a ConnectionRequest signed by the 
	/// corresponding device signature key.
	/// </summary>
	public partial class SignedConnectionRequest : SignedProfile {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SignedConnectionRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SignedConnectionRequest () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public SignedConnectionRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((SignedProfile)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignedConnectionRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignedConnectionRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SignedConnectionRequest (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "SignedConnectionRequest" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignedConnectionRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "SignedConnectionRequest" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignedConnectionRequest FromTagged (string _Input) {
			//SignedConnectionRequest _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new SignedConnectionRequest  FromTagged (JSONReader JSONReader) {
			SignedConnectionRequest Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "SignedConnectionRequest" : {
					var Result = new SignedConnectionRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Describes the result of a connection request.
	/// </summary>
	public partial class ConnectionResult : ConnectionRequest {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Result {
			get {return _Result;}			
			set {_Result = value;}
			}
		string						_Result ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ConnectionResult";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ConnectionResult () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public ConnectionResult (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ConnectionRequest)this).SerializeX(_Writer, false, ref _first);
			if (Result != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Result", 1);
					_Writer.WriteString (Result);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new ConnectionResult From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ConnectionResult From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ConnectionResult (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "ConnectionResult" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new ConnectionResult FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "ConnectionResult" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new ConnectionResult FromTagged (string _Input) {
			//ConnectionResult _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new ConnectionResult  FromTagged (JSONReader JSONReader) {
			ConnectionResult Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "ConnectionResult" : {
					var Result = new ConnectionResult ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Result" : {
					Result = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Contains a signed connection result
	/// </summary>
	public partial class SignedConnectionResult : SignedProfile {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "SignedConnectionResult";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public SignedConnectionResult () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public SignedConnectionResult (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((SignedProfile)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignedConnectionResult From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignedConnectionResult From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new SignedConnectionResult (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "SignedConnectionResult" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new SignedConnectionResult FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "SignedConnectionResult" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new SignedConnectionResult FromTagged (string _Input) {
			//SignedConnectionResult _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new SignedConnectionResult  FromTagged (JSONReader JSONReader) {
			SignedConnectionResult Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "SignedConnectionResult" : {
					var Result = new SignedConnectionResult ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
			}


        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	}
