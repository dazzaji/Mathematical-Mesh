﻿using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Protocol;
using Goedel.IO;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;

namespace Goedel.Cryptography.Dare {



    /// <summary>
    /// Simple container that supports the append and index functions but does not 
    /// provide for linked cryptographic integrity.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public class ContainerSimple : Container {

        /// <summary>
        /// The label for the container type for use in header declarations
        /// </summary>
        public const string Label = "List";

        /// <summary>
        /// The label for the container type for use in header declarations
        /// </summary>
        public const string LabelDigest = "Digest";

        /// <summary>
        /// The digest provider used to calculate the tree value. [OBSOLETE, to be removed]
        /// </summary>
        public CryptoProviderDigest DigestProvider { get; set; } = null;



        /// <summary>
        /// Create a new container file of the specified type and write the initial
        /// data record
        /// </summary>
        /// <param name="JBCDStream">The underlying JBCDStream stream. This MUST be opened
        /// in a read access mode and should have exclusive read access. All existing
        /// content in the file will be overwritten.</param>
        /// <param name="ContainerType">The container type. This determines whether
        /// a tree index is to be created or not and if so, whether </param>
        /// <param name="DigestAlgorithm">The digest algorithm to be used to calculate the PayloadDigest</param>
        /// <returns>The newly constructed container.</returns>

        public static new Container MakeNewContainer(
                        JBCDStream JBCDStream,
                        CryptoParameters CryptoParameters,
                        ContainerType ContainerType = ContainerType.Chain,
                        CryptoAlgorithmID DigestAlgorithm = CryptoAlgorithmID.Default) {

            var ContainerHeader = new ContainerHeaderFirst() {
                Index = 0
                };

            CryptoProviderDigest DigestProvider = null;
            switch (ContainerType) {
                case ContainerType.List: {
                    ContainerHeader.ContainerType = Label;
                    break;
                    }
                case ContainerType.Digest: {
                    ContainerHeader.ContainerType = LabelDigest;
                    CryptoParameters.DigestID = 
                        CryptoParameters.DigestID == CryptoAlgorithmID.NULL?
                        CryptoAlgorithmID.Default : CryptoParameters.DigestID;



                    DigestProvider = CryptoCatalog.Default.GetDigest(DigestAlgorithm);
                    break;
                    }
                default: {
                    throw new InvalidContainerTypeException();
                    }
                }

            var Container = new ContainerSimple() {
                JBCDStream = JBCDStream,
                DigestProvider = DigestProvider,
                ContainerHeaderFirst = ContainerHeader,
                CryptoParameters= CryptoParameters
                };

            // initialize the Frame index dictionary

            return Container;


            }

        // The high and low boundaries of the unknown region.
        long FrameLowUnknown = 0;
        long FrameHighUnknown = 0;

        /// <summary>
        /// Initialize the dictionaries used to manage the tree by registering the set
        /// of values leading up to the apex value.
        /// </summary>
        /// <param name="Header">Final frame header</param>
        /// <param name="FirstPosition">Position of frame 1</param>
        /// <param name="PositionLast">Position of the last frame</param>
        protected override void FillDictionary(ContainerHeader Header, long FirstPosition, long PositionLast) {

            FrameIndexToPositionDictionary.Add(0, 0);
            if (Header.Index == 0) {
                FrameLowUnknown = 0;
                FrameHighUnknown = 0;
                return;
                }

            FrameIndexToPositionDictionary.Add(1, FirstPosition);
            FrameLowUnknown = 1;

            if (Header.Index == 1) {
                FrameHighUnknown = 1;
                return;
                }

            FrameHighUnknown = Header.Index;
            RegisterFrame(Header, PositionLast);
            }


        /// <summary>
        /// The digest encoder for digesting the payload content.
        /// </summary>
        protected CryptoDataEncoder DigestEncoder;

        /// <summary>
        /// Begin appending a data frame.
        /// </summary>
        /// <remarks>This call is not thread safe. It is the responsibility of the caller
        /// to ensure that only one process writes to the container at once and that no other
        /// process has access.</remarks>
        /// <param name="ContentLength">The plaintext payload data length. the final payload
        /// length may be longer as a result of padding.</param>
        /// <param name="ContainerHeader">Pre-populated container header.</param>
        /// <param name="CryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="ContentType">The payload content type.</param>
        /// <param name="Cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="DataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>

        public override void AppendBegin(
                        long ContentLength,
                        CryptoParameters CryptoParameters,
                        ContainerHeader ContainerHeader = null,
                         string ContentType = null,
                        byte[] Cloaked = null,
                        List<byte[]> DataSequences = null) {

            DigestEncoder = DigestProvider?.MakeEncoder();
            base.AppendBegin(ContentLength, CryptoParameters, ContainerHeader, 
                ContentType, Cloaked, DataSequences);
            }

        /// <summary>
        /// Preprocess record data. This method may be called any number
        /// of times but the total count of the number of items must match
        /// the Content Length specified in the original call.
        /// </summary>
        /// <param name="Data">The data to preprocees</param>
        /// <param name="Offset">Index of first byte to process.</param>
        /// <param name="Count">Number of bytes to process.</param>
        public override void AppendPreprocess(byte[] Data, int Offset, int Count) => DigestEncoder?.Write(Data, Offset, Count);

        /// <summary>
        /// Append the header to the frame. This is called after the payload data
        /// has been passed using AppendPreprocess.
        /// </summary>
        public override void AppendHeader() {
            FrameIndexToPositionDictionary.Add(AppendContainerHeader.Index,
                    JBCDStream.PositionWrite);
            if (DigestEncoder != null & AppendContainerHeader.PayloadDigest ==null) {
                DigestEncoder.Complete();
                AppendContainerHeader.PayloadDigest = DigestEncoder.Integrity;
                }
            base.AppendHeader();
            }



        /// <summary>
        /// The number of bytes to be reserved for the trailer.
        /// </summary>
        /// <returns>The number of bytes to reserve</returns>
        public override int GetTrailerLength() {
            if (CryptoParameters==null) {
                return -1; // no trailer if no crypto!
                }
            return CryptoParameters.GetTrailerLength();
            }

        /// <summary>
        /// The dummy trailer to add to the end of the frame.
        /// </summary>
        /// <returns></returns>
        public override void MakeTrailer(ref DARETrailer Trailer) {
            if (CryptoParameters == null) {
                return; // no trailer if no crypto!
                }
            }


        /// <summary>If positive, specifies the file position of the next frame.
        /// This is used to store an index to be applied to the file pointer before 
        /// a Next or Previous method operates on the stream.</summary>
        long FrameReadStartPosition = -1;

        /// <summary>
        /// Get or set the read position in the stream.
        /// </summary>
        protected long PositionRead {
            get => JBCDStream.PositionRead;
            set {
                FrameReadStartPosition = -1;
                JBCDStream.PositionRead = value;
                }
            }

        void PositionStream() {
            if (FrameReadStartPosition >=0) {
                JBCDStream.PositionRead = FrameReadStartPosition;
                FrameReadStartPosition = -1;
                }
            }

        long FrameRemaining;
        long PayloadData;


        /// <summary>
        /// Read the frame data and return as an array.
        /// </summary>
        /// <returns>The data that was read</returns>
        public override byte[] ReadFrameData() {

            using ( var FrameReader = new JBCDRecordDataReader(JBCDStream, ref FrameRemaining)) {

                using (var Buffer = new MemoryStream()) {
                    var Decoder = ContainerHeader.GetDecoder(
                            FrameReader, out var Reader,
                            KeyCollection: KeyCollection);
                    Reader.CopyTo(Buffer);
                    Decoder.Close();
                    return Buffer.ToArray();
                    }
                }
            }

        ///// <summary>
        ///// Obtain a reader stream for the current frame data.
        ///// </summary>
        ///// <returns>The reader stream created.</returns>
        //public override ContainerDataReader GetFrameDataReader() =>
        //    new ContainerDataReader(JBCDStream, ref FrameRemaining,
        //        ContainerHeader, KeyCollection);

        /// <summary>
        /// Obtain a reader stream for the current frame data.
        /// </summary>
        /// <returns>The reader stream created.</returns>
        public override ContainerFramerReader GetFrameDataReader(
                long Index = -1, long Position = -1) {

            if (Position < 0 & Index >= 0) {
                MoveToIndex(Index);
                Position = PositionRead;
                }

            return new ContainerFramerReader(JBCDStream, KeyCollection, Position);
            }

        /// <summary>
        /// Read the next frame in the file.
        /// </summary>
        /// <returns>True if a next frame exists, otherwise false</returns>
        public override bool NextFrame() => JBCDStream.FramerNext();

        /// <summary>
        /// Read the next frame in the file.
        /// </summary>
        /// <returns>True if a next frame exists, otherwise false</returns>
        public override bool PreviousFrame() => JBCDStream.FramerPrevious();

        /// <summary>
        /// Begin reading record data. This method is called before ReadData
        /// to move the read pointer to the start of the payload data.
        /// </summary>
        /// <returns></returns>
        public override long ReadDataBegin() {
            PayloadData = JBCDStream.ReadRecordBegin(ref FrameRemaining);
            return PayloadData;
            }


        /// <summary>
        /// Read the next frame in the file.
        /// </summary>
        /// <returns>True if a next frame exists, otherwise false</returns>
        protected override bool Next () {
            PositionStream();

            var RecordStart = PositionRead;

            //_FrameData = null;
            FrameRemaining = JBCDStream.ReadFrame(out var FrameHeader);
            FrameReadStartPosition = PositionRead;

            this.FrameHeader = FrameHeader;


            if (FrameHeader != null) {
                var Index = ContainerHeader.Index;
                if (!FrameIndexToPositionDictionary.TryGetValue(Index, out _)) {
                    FrameIndexToPositionDictionary.Add(Index, RecordStart);
                    }
                }


            return FrameRemaining >= 0;
            }

        /// <summary>
        /// Read the previous frame in the file and leave the read pointer positioned at the start
        /// of the frame just read.
        /// </summary>
        /// <returns>True if a previous frame exists, otherwise false</returns>
        public override bool Previous () {
            PositionStream();

            FrameRemaining = JBCDStream.ReadFrameReverse(out var FrameHeader);
            FrameReadStartPosition = PositionRead;

            this.FrameHeader = FrameHeader;
            if (FrameHeader != null) {
                var Index = ContainerHeader.Index;
                if (!FrameIndexToPositionDictionary.TryGetValue(Index, out _)) {
                    FrameIndexToPositionDictionary.Add(Index, FrameReadStartPosition);
                    }
                }

            return FrameRemaining >= 0;
            }

        /// <summary>
        /// Move to the frame with index Position in the file. 
        /// <para>Since the file format only supports sequential access, this is slow.</para>
        /// </summary>
        /// <param name="Index">The frame index to move to</param>
        /// <returns>If success, the frame index.</returns>
        public override bool MoveToIndex (long Index) {

            if (FrameIndexToPositionDictionary.TryGetValue(Index, out var Position)) {
                PositionRead = Position;
                }
            else {
                Assert.True(Index > FrameLowUnknown & Index < FrameHighUnknown);

                if (Index - FrameLowUnknown <= FrameHighUnknown - Index) {
                    Assert.True(FrameIndexToPositionDictionary.TryGetValue(FrameLowUnknown, out Position));
                    PositionRead = Position;
                    var Last = PositionRead;
                    Next();
                    while (ContainerHeader!= null && ContainerHeader.Index < Index) {
                        Last = PositionRead;
                        Next();
                        }
                    PositionRead = Last;
                    FrameLowUnknown = ContainerHeader.Index;
                    return ContainerHeader.Index == Index;
                    }

                else {
                    Assert.True(FrameIndexToPositionDictionary.TryGetValue(FrameHighUnknown, out Position));
                    PositionRead = Position;

                    Previous();
                    while (ContainerHeader != null && (ContainerHeader.Index > Index)) {
                        Previous();
                        }

                    FrameHighUnknown = ContainerHeader.Index;
                    return ContainerHeader.Index == Index;
                    }
                }
            return true;
            //return Next();

            }

        /// <summary>
        /// Combine digests to produce the digest for a node.
        /// </summary>
        /// <param name="First">The left hand digest.</param>
        /// <param name="Second">The right hand digest.</param>
        /// <returns>The digest value.</returns>
        public byte[] CombineDigest (byte[] First, byte[] Second) {
            var Length = DigestProvider.Size / 8;

            var Buffer = new byte[Length*2];
            if (First != null) {
                Assert.True(Length == First.Length);
                Array.Copy(First, Buffer, Length);
                }
            if (Second != null) {
                Assert.True(Length == Second.Length);
                Array.Copy(Second, 0, Buffer, Length, Length);
                }
            

            return DigestProvider.ProcessData(Buffer); ;
            }


        /// <summary>
        /// Perform sanity checking on a list of container headers.
        /// </summary>
        /// <param name="Headers">List of headers to check</param>
        public override void CheckContainer (List<ContainerHeader> Headers) {
            int Index = 1;
            foreach (var Header in Headers) {
                Assert.True(Header.Index == Index);

                if (ContainerHeaderFirst.ContainerType == Label) {
                    Assert.Null(Header.PayloadDigest);
                    }
                else {
                    Assert.NotNull(Header.PayloadDigest);
                    }
                Index++;
                }
            }
        }
    }
