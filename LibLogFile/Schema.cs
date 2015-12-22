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
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;






namespace Goedel.Persistence {


    /// <summary>
    /// 
    /// </summary>
	public abstract partial class LogEntry : Goedel.Protocol.JSONObject {

        /// <summary>
        /// 
        /// </summary>
		public override string Tag () {
			return "LogEntry";
			}

        /// <summary>
        /// Default constructor.
        /// </summary>
		public LogEntry () {
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded stream.
        /// </summary>
		public LogEntry (JSONReader JSONReader) {
			Deserialize (JSONReader);
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded string.
        /// </summary>
		public LogEntry (string _String) {
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

				case "DataItem" : {
					var Result = new DataItem ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Header" : {
					var Result = new Header ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Delta" : {
					var Result = new Delta ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "IndexTerm" : {
					var Result = new IndexTerm ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Final" : {
					var Result = new Final ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Terminal" : {
					var Result = new Terminal ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "IndexIndex" : {
					var Result = new IndexIndex ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Index" : {
					var Result = new Index ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "IndexEntry" : {
					var Result = new IndexEntry ();
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
	/// </summary>
	public partial class DataItem : LogEntry {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						TransactionID {
			get {return _TransactionID;}			
			set {_TransactionID = value;}
			}
		string						_TransactionID ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						PrimaryKey {
			get {return _PrimaryKey;}			
			set {_PrimaryKey = value;}
			}
		string						_PrimaryKey ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						PriorTransactionID {
			get {return _PriorTransactionID;}			
			set {_PriorTransactionID = value;}
			}
		string						_PriorTransactionID ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Action {
			get {return _Action;}			
			set {_Action = value;}
			}
		string						_Action ;
		bool								__Added = false;
		private DateTime						_Added;
        /// <summary>
        /// 
        /// </summary>
		public virtual DateTime						Added {
			get {return _Added;}
			set {_Added = value; __Added = true; }
			}
		/// <summary>
        /// 
        /// </summary>
		public virtual List<IndexTerm>				Keys {
			get {return _Keys;}			
			set {_Keys = value;}
			}
		List<IndexTerm>				_Keys;
        /// <summary>
        /// 
        /// </summary>
		public virtual byte[]						Data {
			get {return _Data;}			
			set {_Data = value;}
			}
		byte[]						_Data ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Text {
			get {return _Text;}			
			set {_Text = value;}
			}
		string						_Text ;
		bool								__Pending = false;
		private bool						_Pending;
        /// <summary>
        /// 
        /// </summary>
		public virtual bool						Pending {
			get {return _Pending;}
			set {_Pending = value; __Pending = true; }
			}
		bool								__Commit = false;
		private bool						_Commit;
        /// <summary>
        /// 
        /// </summary>
		public virtual bool						Commit {
			get {return _Commit;}
			set {_Commit = value; __Commit = true; }
			}
		bool								__Rollback = false;
		private bool						_Rollback;
        /// <summary>
        /// 
        /// </summary>
		public virtual bool						Rollback {
			get {return _Rollback;}
			set {_Rollback = value; __Rollback = true; }
			}

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "DataItem";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public DataItem () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public DataItem (JSONReader JSONReader) {
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
			if (TransactionID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("TransactionID", 1);
					_Writer.WriteString (TransactionID);
				}
			if (PrimaryKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PrimaryKey", 1);
					_Writer.WriteString (PrimaryKey);
				}
			if (PriorTransactionID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PriorTransactionID", 1);
					_Writer.WriteString (PriorTransactionID);
				}
			if (Action != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Action", 1);
					_Writer.WriteString (Action);
				}
			if (__Added){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Added", 1);
					_Writer.WriteDateTime (Added);
				}
			if (Keys != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Keys", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Keys) {
					_Writer.WriteArraySeparator (ref _firstarray);
                    _Writer.WriteObjectStart();
                    _Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    _Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (Data != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Data", 1);
					_Writer.WriteBinary (Data);
				}
			if (Text != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Text", 1);
					_Writer.WriteString (Text);
				}
			if (__Pending){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Pending", 1);
					_Writer.WriteBoolean (Pending);
				}
			if (__Commit){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Commit", 1);
					_Writer.WriteBoolean (Commit);
				}
			if (__Rollback){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Rollback", 1);
					_Writer.WriteBoolean (Rollback);
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
		public static new DataItem From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new DataItem From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new DataItem (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "DataItem" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new DataItem FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "DataItem" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new DataItem FromTagged (string _Input) {
			//DataItem _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new DataItem  FromTagged (JSONReader JSONReader) {
			DataItem Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "DataItem" : {
					var Result = new DataItem ();
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
				case "TransactionID" : {
					TransactionID = JSONReader.ReadString ();
					break;
					}
				case "PrimaryKey" : {
					PrimaryKey = JSONReader.ReadString ();
					break;
					}
				case "PriorTransactionID" : {
					PriorTransactionID = JSONReader.ReadString ();
					break;
					}
				case "Action" : {
					Action = JSONReader.ReadString ();
					break;
					}
				case "Added" : {
					Added = JSONReader.ReadDateTime ();
					break;
					}
				case "Keys" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Keys = new List <IndexTerm> ();
					while (_Going) {
						var _Item = IndexTerm.FromTagged (JSONReader); // a tagged structure
						Keys.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Data" : {
					Data = JSONReader.ReadBinary ();
					break;
					}
				case "Text" : {
					Text = JSONReader.ReadString ();
					break;
					}
				case "Pending" : {
					Pending = JSONReader.ReadBoolean ();
					break;
					}
				case "Commit" : {
					Commit = JSONReader.ReadBoolean ();
					break;
					}
				case "Rollback" : {
					Rollback = JSONReader.ReadBoolean ();
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
	/// </summary>
	public partial class Header : LogEntry {
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
		public virtual string						Content {
			get {return _Content;}			
			set {_Content = value;}
			}
		string						_Content ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Comment {
			get {return _Comment;}			
			set {_Comment = value;}
			}
		string						_Comment ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Digest {
			get {return _Digest;}			
			set {_Digest = value;}
			}
		string						_Digest ;
        /// <summary>
        /// 
        /// </summary>
		public virtual byte[]						LastDigest {
			get {return _LastDigest;}			
			set {_LastDigest = value;}
			}
		byte[]						_LastDigest ;
        /// <summary>
        /// 
        /// </summary>
		public virtual Delta						Delta {
			get {return _Delta;}			
			set {_Delta = value;}
			}
		Delta						_Delta ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Header";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Header () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Header (JSONReader JSONReader) {
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
			if (Type != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Type", 1);
					_Writer.WriteString (Type);
				}
			if (Content != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Content", 1);
					_Writer.WriteString (Content);
				}
			if (Comment != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Comment", 1);
					_Writer.WriteString (Comment);
				}
			if (Digest != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Digest", 1);
					_Writer.WriteString (Digest);
				}
			if (LastDigest != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("LastDigest", 1);
					_Writer.WriteBinary (LastDigest);
				}
			if (Delta != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Delta", 1);
					Delta.Serialize (_Writer, false);
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
		public static new Header From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Header From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Header (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "Header" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Header FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "Header" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new Header FromTagged (string _Input) {
			//Header _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new Header  FromTagged (JSONReader JSONReader) {
			Header Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "Header" : {
					var Result = new Header ();
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
				case "Type" : {
					Type = JSONReader.ReadString ();
					break;
					}
				case "Content" : {
					Content = JSONReader.ReadString ();
					break;
					}
				case "Comment" : {
					Comment = JSONReader.ReadString ();
					break;
					}
				case "Digest" : {
					Digest = JSONReader.ReadString ();
					break;
					}
				case "LastDigest" : {
					LastDigest = JSONReader.ReadBinary ();
					break;
					}
				case "Delta" : {
					// An untagged structure
					Delta = new Delta (JSONReader);
 
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
	/// </summary>
	public partial class Delta : LogEntry {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Parent {
			get {return _Parent;}			
			set {_Parent = value;}
			}
		string						_Parent ;
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Previous {
			get {return _Previous;}			
			set {_Previous = value;}
			}
		string						_Previous ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Delta";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Delta () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Delta (JSONReader JSONReader) {
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
			if (Parent != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Parent", 1);
					_Writer.WriteString (Parent);
				}
			if (Previous != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Previous", 1);
					_Writer.WriteString (Previous);
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
		public static new Delta From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Delta From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Delta (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "Delta" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Delta FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "Delta" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new Delta FromTagged (string _Input) {
			//Delta _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new Delta  FromTagged (JSONReader JSONReader) {
			Delta Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "Delta" : {
					var Result = new Delta ();
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
				case "Parent" : {
					Parent = JSONReader.ReadString ();
					break;
					}
				case "Previous" : {
					Previous = JSONReader.ReadString ();
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
	/// </summary>
	public partial class IndexTerm : LogEntry {
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
		public virtual string						Term {
			get {return _Term;}			
			set {_Term = value;}
			}
		string						_Term ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "IndexTerm";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public IndexTerm () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public IndexTerm (JSONReader JSONReader) {
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
			if (Type != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Type", 1);
					_Writer.WriteString (Type);
				}
			if (Term != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Term", 1);
					_Writer.WriteString (Term);
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
		public static new IndexTerm From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new IndexTerm From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new IndexTerm (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "IndexTerm" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new IndexTerm FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "IndexTerm" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new IndexTerm FromTagged (string _Input) {
			//IndexTerm _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new IndexTerm  FromTagged (JSONReader JSONReader) {
			IndexTerm Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "IndexTerm" : {
					var Result = new IndexTerm ();
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
				case "Type" : {
					Type = JSONReader.ReadString ();
					break;
					}
				case "Term" : {
					Term = JSONReader.ReadString ();
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
	/// </summary>
	public partial class Final : LogEntry {
        /// <summary>
        /// 
        /// </summary>
		public virtual byte[]						Digest {
			get {return _Digest;}			
			set {_Digest = value;}
			}
		byte[]						_Digest ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Final";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Final () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Final (JSONReader JSONReader) {
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
			if (Digest != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Digest", 1);
					_Writer.WriteBinary (Digest);
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
		public static new Final From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Final From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Final (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "Final" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Final FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "Final" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new Final FromTagged (string _Input) {
			//Final _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new Final  FromTagged (JSONReader JSONReader) {
			Final Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "Final" : {
					var Result = new Final ();
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
				case "Digest" : {
					Digest = JSONReader.ReadBinary ();
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
	/// </summary>
	public partial class Terminal : LogEntry {
		/// <summary>
        /// 
        /// </summary>
		public virtual List<IndexIndex>				Indexes {
			get {return _Indexes;}			
			set {_Indexes = value;}
			}
		List<IndexIndex>				_Indexes;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Terminal";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Terminal () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Terminal (JSONReader JSONReader) {
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
			if (Indexes != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Indexes", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Indexes) {
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
		public static new Terminal From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Terminal From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Terminal (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "Terminal" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Terminal FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "Terminal" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new Terminal FromTagged (string _Input) {
			//Terminal _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new Terminal  FromTagged (JSONReader JSONReader) {
			Terminal Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "Terminal" : {
					var Result = new Terminal ();
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
				case "Indexes" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Indexes = new List <IndexIndex> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new IndexIndex (JSONReader);
						Indexes.Add (_Item);
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
	/// </summary>
	public partial class IndexIndex : LogEntry {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Key {
			get {return _Key;}			
			set {_Key = value;}
			}
		string						_Key ;
		bool								__Offset = false;
		private int						_Offset;
        /// <summary>
        /// 
        /// </summary>
		public virtual int						Offset {
			get {return _Offset;}
			set {_Offset = value; __Offset = true; }
			}

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "IndexIndex";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public IndexIndex () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public IndexIndex (JSONReader JSONReader) {
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
			if (Key != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Key", 1);
					_Writer.WriteString (Key);
				}
			if (__Offset){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Offset", 1);
					_Writer.WriteInteger32 (Offset);
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
		public static new IndexIndex From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new IndexIndex From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new IndexIndex (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "IndexIndex" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new IndexIndex FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "IndexIndex" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new IndexIndex FromTagged (string _Input) {
			//IndexIndex _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new IndexIndex  FromTagged (JSONReader JSONReader) {
			IndexIndex Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "IndexIndex" : {
					var Result = new IndexIndex ();
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
				case "Key" : {
					Key = JSONReader.ReadString ();
					break;
					}
				case "Offset" : {
					Offset = JSONReader.ReadInteger32 ();
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
	/// </summary>
	public partial class Index : LogEntry {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Key {
			get {return _Key;}			
			set {_Key = value;}
			}
		string						_Key ;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<IndexEntry>				Entries {
			get {return _Entries;}			
			set {_Entries = value;}
			}
		List<IndexEntry>				_Entries;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Index";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Index () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Index (JSONReader JSONReader) {
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
			if (Key != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Key", 1);
					_Writer.WriteString (Key);
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
		public static new Index From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Index From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Index (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "Index" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new Index FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "Index" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new Index FromTagged (string _Input) {
			//Index _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new Index  FromTagged (JSONReader JSONReader) {
			Index Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "Index" : {
					var Result = new Index ();
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
				case "Key" : {
					Key = JSONReader.ReadString ();
					break;
					}
				case "Entries" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Entries = new List <IndexEntry> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new IndexEntry (JSONReader);
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
	/// </summary>
	public partial class IndexEntry : LogEntry {
        /// <summary>
        /// 
        /// </summary>
		public virtual string						Data {
			get {return _Data;}			
			set {_Data = value;}
			}
		string						_Data ;
		/// <summary>
        /// 
        /// </summary>
		public virtual List<int>				Offset {
			get {return _Offset;}			
			set {_Offset = value;}
			}
		List<int>				_Offset;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "IndexEntry";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public IndexEntry () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public IndexEntry (JSONReader JSONReader) {
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
					_Writer.WriteString (Data);
				}
			if (Offset != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Offset", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Offset) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteInteger32 (_index);
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
		public static new IndexEntry From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new IndexEntry From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new IndexEntry (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "IndexEntry" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new IndexEntry FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "IndexEntry" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new IndexEntry FromTagged (string _Input) {
			//IndexEntry _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader"></param>
        public static new IndexEntry  FromTagged (JSONReader JSONReader) {
			IndexEntry Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "IndexEntry" : {
					var Result = new IndexEntry ();
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
					Data = JSONReader.ReadString ();
					break;
					}
				case "Offset" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Offset = new List <int> ();
					while (_Going) {
						int _Item = JSONReader.ReadInteger32 ();
						Offset.Add (_Item);
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

	}

