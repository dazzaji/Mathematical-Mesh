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
    /// provide for cryptographic integrity.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public class ContainerMerkleTree : ContainerTree {

        /// <summary>
        /// The label for the container type for use in header declarations
        /// </summary>
        public new const string Label = "Merkle";


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
                ContainerType = Label,
                Index = 0
                };

            CryptoProviderDigest DigestProvider = CryptoCatalog.Default.GetDigest(DigestAlgorithm);

            Assert.True(ContainerType == ContainerType.MerkleTree, InvalidContainerTypeException.Throw);

            var Container = new ContainerMerkleTree() {
                JBCDStream = JBCDStream,
                DigestProvider = DigestProvider,
                ContainerHeaderFirst = ContainerHeader
                };


            return Container;
            }

        readonly static byte[] EmptyBytes = new byte[0];

        /// <summary>
        /// Register a frame in the container access dictionaries.
        /// </summary>
        /// <param name="Header">Frame header</param>
        /// <param name="Position">Position of the frame</param>
        protected override void RegisterFrame (ContainerHeader Header, long Position) {
            var Index = Header.Index;
            FrameIndexToPositionDictionary.Add(Index, Position);
            FrameDigestDictionary.Add(Index, Header.TreeDigest);
            }

        /// <summary>
        /// Dictionary mapping the frame index to the corresponding digest value.
        /// </summary>
        public Dictionary<long, byte[]> FrameDigestDictionary = new Dictionary<long, byte[]>();

        /// <summary>
        /// Append the header to the frame. This is called after the payload data
        /// has been passed using AppendPreprocess.
        /// </summary>
        public override void AppendHeader() {
            if (DigestEncoder != null & AppendContainerHeader.PayloadDigest == null) {
                DigestEncoder.Complete();
                var PayloadDigest = DigestEncoder.Integrity;
                AppendContainerHeader.PayloadDigest = PayloadDigest;
                if (FrameCount > 0) {
                    AppendContainerHeader.TreeDigest = GetTreeDigest(FrameCount, PayloadDigest);
                    }
                else {
                    AppendContainerHeader.TreeDigest = CombineDigest(null, PayloadDigest);
                    }
                }
            base.AppendHeader();
            }



        /// <summary>
        /// Calculate the digest of the specified tree node
        /// </summary>
        /// <param name="Frame">The frame number</param>
        /// <param name="ContentDigest">The content digest</param>
        /// <returns>The calculated digest</returns>
        public virtual byte[] GetTreeDigest (long Frame, byte[] ContentDigest) {
            long x2 = Frame + 1;
            long d = 1;

            while (x2 > 0) {
                if ((x2 & 1) == 1) {
                    return DigestFrame (x2 == 1 ? (d / 2) - 1 : Frame - d, ContentDigest);
                    }
                else {
                    ContentDigest = DigestFrame(Frame - d, ContentDigest);
                    }
                d = d * 2;
                x2 = x2 / 2;
                }
            return CombineDigest(null, ContentDigest);
            }

        /// <summary>
        /// Obtain the digest value for a frame.
        /// </summary>
        /// <param name="Frame">The frame index.</param>
        /// <param name="Right">The digest of the rightmost component.</param>
        /// <returns>The calculated digest.</returns>
        public byte[] DigestFrame (long Frame, byte[] Right) {
            var Left = GetFrameDigest(Frame);
            return CombineDigest(Left, Right);
            }


        /// <summary>
        /// Get the digest value of the specified frame.
        /// </summary>
        /// <param name="Frame">The frame index.</param>
        /// <returns>The digest value.</returns>
        public virtual byte[] GetFrameDigest (long Frame) {
            var Found = FrameDigestDictionary.TryGetValue(Frame, out var Digest);
            return Digest;
            }


        /// <summary>
        /// Perform sanity checking on a list of container headers.
        /// </summary>
        /// <param name="Headers">List of headers to check</param>
        public override void CheckContainer (List<ContainerHeader> Headers) {
            int Index = 1;
            foreach (var Header in Headers) {
                Assert.True(Header.Index == Index);
                Assert.NotNull(Header.PayloadDigest);

                Index++;
                }
            }


        }

    }
