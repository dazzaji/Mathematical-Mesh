﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using Goedel.ASN;
using Goedel.Utilities;
using Goedel.Cryptography.PKIX;
using Goedel.Cryptography;

namespace Goedel.Cryptography.Algorithms {

    /// <summary>
    /// Extension class.
    /// </summary>
    public static class Extension {

        /// <summary>
        /// If <paramref name="buffer"/> is not null, present the entire contents to
        /// the digest function <paramref name="hashAlgorithm"/>.
        /// </summary>
        /// <param name="hashAlgorithm">The digest function to use.</param>
        /// <param name="buffer">The data to be digested.</param>
        public static void Digest(this HashAlgorithm hashAlgorithm, byte[] buffer) {
            if (buffer != null) {
                hashAlgorithm.TransformBlock(buffer, 0, buffer.Length, buffer, 0);
                }
            }
        }

    /// <summary>
    /// Edwards Curve [x^2 = (y^2 - 1) / (d y^2 + 1) (mod p)] for 2^255-19
    /// </summary>
    public class CurveEdwards25519 : CurveEdwards {

        /// <summary>
        /// Additional parameter used in affine projection
        /// </summary>
        public BigInteger T { get; set; }

        ///// <summary>The domain parameters</summary>
        //public override DomainParameters Domain { get; } = DomainParameters.Curve25519;

        ///<summary>The modulus, q = 2^255 - 19</summary>
        readonly static BigInteger P = BigInteger.Pow(2, 255) - 19;

        ///<summary>The modulus, q = 2^255 - 19</summary>
        public override BigInteger Prime => P;


        ///<summary>The Curve Constant d</summary>
        public override BigInteger CurveConstrantD => D;

        ///<summary>The Curve Constant d</summary>
        public static readonly BigInteger D =
            (-121665 * (121666.ModularInverse(P))).Mod(P);

        ///<summary>The square root of -1.</summary>
        public override BigInteger SqrtMinus1 => _SqrtMinus1;
        readonly static BigInteger _SqrtMinus1 = P.SqrtMinus1();

        ///<summary>The small order subgroup q</summary>
        public static readonly BigInteger Q =
            BigInteger.Pow(2, 252) + "27742317777372353535851937790883648493".DecimalToBigInteger();

        /// <summary>The base point for the subgroup</summary>
        static readonly CurveEdwards25519 _Base =
            new CurveEdwards25519(DomainParameters.Curve25519.By, false);

        /// <summary>The base point for the subgroup</summary>
        public static CurveEdwards25519 Base => _Base.Copy();

        /// <summary>The point P such that P + Q = Q for all Q</summary>
        static readonly CurveEdwards25519 _Neutral =
            new CurveEdwards25519() { X = 0, Y = 1, Z = 1, T = 0 };

        /// <summary>The point P such that P + Q = Q for all Q</summary>
        public static CurveEdwards25519 Neutral => _Neutral.Copy();

        /// <summary>The number of bits to multiply</summary>
        public const int Bits = 255;

        /// <summary>Default constructor</summary>
        protected CurveEdwards25519() {
            }

        /// <summary>
        /// Construct a point from a Y coordinate and sign.
        /// </summary>
        /// <param name="Y">The Y coordinate</param>
        /// <param name="X0">The sign of X</param>
        public CurveEdwards25519(BigInteger Y, bool X0) {
            this.Y = Y;
            this.Z = 1;
            X = RecoverX(X0);
            T = (X * Y) % P;
            }

        /// <summary>
        /// Crete a new point with the same parameters as this.
        /// </summary>
        /// <returns>The new point</returns>
        public CurveEdwards25519 Copy() => new CurveEdwards25519() { X = X, Y = Y, Z = Z, T = T };

        /// <summary>
        /// Multiply this point by a scalar
        /// </summary>
        /// <param name="S">Scalar factor</param>
        /// <param name="Neutral">The neutral point on the curve.</param>
        /// <returns>The result of the multiplication</returns>
        CurveEdwards25519 Multiply(BigInteger S, CurveEdwards25519 Neutral) {
            var Q = Neutral.Copy();
            Assert.NotNull(Q, InvalidOperation.Throw);
            var BitIndex = new BitIndex(S, Bits, Up: true);

            var P = Copy();
            while (BitIndex.GoingUp) {
                if (BitIndex.Up()) {
                    Q.Accumulate(P);
                    }
                P.Double();
                }

            return Q;
            }


        /// <summary>
        /// Multiply this point by a scalar
        /// </summary>
        /// <param name="S">Scalar factor</param>
        /// <returns>The result of the multiplication</returns>
        public CurveEdwards25519 Multiply(BigInteger S) => Multiply(S, Neutral);

        /// <summary>
        /// Replace the current point value with the current value added to itself
        /// (used to implement multiply)
        /// </summary>
        public override void Double() => Accumulate(this);  // Limit, doing this the inefficient way for testing.


        //var A = (X * X).Mod(Domain.p);
        //var B = (Y * Y).Mod(Domain.p);
        //var C = (2 * Z * Z).Mod(Domain.p);
        //var H = (A + B).Mod(Domain.p);
        //var S = (X + Y);
        //var E = (H - S * S).Mod(Domain.p);
        //var G = (A - B).Mod(Domain.p);
        //var F = (C + G).Mod(Domain.p);

        //X = (E * F).Mod (Domain.p);
        //Y = (G * H).Mod(Domain.p);
        //T = (E * H).Mod(Domain.p);
        //Z = (F * G).Mod(Domain.p);



        /// <summary>
        /// Add two points
        /// </summary>
        /// <param name="P1">First point</param>
        /// <param name="P2">Second point</param>
        /// <param name="X3"></param>
        /// <param name="Y3"></param>
        /// <param name="Z3"></param>
        /// <param name="T3"></param>
        /// <returns>The result of the addition.</returns>
        static void Add(CurveEdwards25519 P1, CurveEdwards25519 P2,
                    out BigInteger X3, out BigInteger Y3, out BigInteger Z3, out BigInteger T3) {
            Assert.NotNull(P1, NYI.Throw);
            Assert.NotNull(P2, NYI.Throw);

            var A = ((P1.Y - P1.X) * (P2.Y - P2.X)).Mod(P);
            var B = ((P1.Y + P1.X) * (P2.Y + P2.X)).Mod(P);
            var C = (P1.T * 2 * CurveEdwards25519.D * P2.T).Mod(P);
            var D = (P1.Z * 2 * P2.Z).Mod(P);
            var E = B - A;
            var F = D - C;
            var G = D + C;
            var H = B + A;
            X3 = (E * F);
            Y3 = (G * H);
            T3 = (E * H);
            Z3 = (F * G);
            }

        /// <summary>
        /// Add two points
        /// </summary>
        /// <param name="Point">Second point</param>
        /// <returns>The result of the addition.</returns>
        public override CurveEdwards Add(CurveEdwards Point) {
            Add(this, Point as CurveEdwards25519, out var X3, out var Y3, out var Z3, out var T3);
            return new CurveEdwards25519() { X = X3, Y = Y3, Z = Z3, T = T3 };
            }

        /// <summary>
        /// Add two points
        /// </summary>
        /// <param name="Point">Second point</param>
        /// <returns>The result of the addition.</returns>
        public override void Accumulate(CurveEdwards Point) {
            Add(this, Point as CurveEdwards25519, out var X3, out var Y3, out var Z3, out var T3);
            X = X3;
            Y = Y3;
            Z = Z3;
            T = T3;
            }





        /// <summary>
        /// Generate the public parameter (a point on the curve)
        /// </summary>
        /// <param name="Private">The extended private key</param>
        /// <returns>The public key corresponding to Private (s.B)</returns>
        public static CurveEdwards25519 GetPublic(BigInteger Private) => (CurveEdwards25519)Base.Multiply(Private);

        /// <summary>
        /// Encode this point in the compressed buffer representation
        /// </summary>
        /// <returns>The point encoded in the compressed buffer representation.</returns>
        public byte[] Encode() {

            Translate(out var X0, out var Y0);

            byte[] Buffer = new byte[32];
            var YBuf = Y0.ToByteArray();
            Array.Copy(YBuf, Buffer, YBuf.Length);
            if (!X0.IsEven) {        // Encode the sign bit
                Buffer[31] = (byte)(Buffer[31] | 0x80);
                }
            return Buffer;
            }


        /// <summary>
        /// Construct a point on the curve from a buffer.
        /// </summary>
        /// <param name="Data">The encoded data</param>
        /// <returns>The point created</returns>
        public static CurveEdwards25519 Decode(byte[] Data) {
            if ((Data[31] & 0x80) == 0) {
                var Y0 = Data.BigIntegerLittleEndian();
                return new CurveEdwards25519(Y0, false);
                }
            var Copy = Data.Duplicate();
            Copy[31] = (byte)(Copy[31] & 0x7f);
            var Y1 = Copy.BigIntegerLittleEndian();
            return new CurveEdwards25519(Y1, true);
            }

        readonly static byte[] ZeroByteArray = new byte[0] { };
        /// <summary>
        /// Calculate the SHA-2-512 hash of the inputs, convert to an integer and reduce
        /// modulo the subgroup.
        /// </summary>
        /// <param name="A0">First data input, ignored if null</param>
        /// <param name="A1">Second data input, ignored if null</param>
        /// <param name="A2">Third data input, ignored if null</param>
        /// <param name="A3">Fourth data input, ignored if null</param>
        /// <returns>The SHA-2-512 hash of the inputs as a big integer reduced modulo the sub group</returns>
        public static BigInteger HashModQ(byte[] A0, byte[] A1, byte[] A2, byte[] A3 = null) {

            var Sha512 = SHA512.Create();

            if (A0 != null) {
                Sha512.Digest(A0);
                }
            if (A1 != null) {
                Sha512.Digest(A1);
                }
            if (A2 != null) {
                Sha512.Digest(A2);
                }
            if (A3 != null) {
                Sha512.Digest(A3);
                }
            Sha512.TransformFinalBlock(ZeroByteArray, 0, 0);
            var Digest = Sha512.Hash;
            var Result = Digest.BigIntegerLittleEndian();

            Result = Result % Q;

            return Result;
            }


        /// <summary>
        /// Verify a signature on a message according to RFC8032.
        /// </summary>
        /// <remarks>This method does not prehash the message data since if
        /// prehashing is desired, it is because the data needs to be hashed
        /// before being presented.</remarks>
        /// <param name="Public">The public key</param>
        /// <param name="Message">The message data.</param>
        /// <param name="Signature">The encoded signature data.</param>
        /// <param name="Context">Context value, if used.</param>
        /// <returns>True if signature verification succeeded, otherwise false.</returns>
        public bool VerifySignature(byte[] Public, byte[] Message, byte[] Signature, byte[] Context = null) {

            // 1. To verify a signature on a message M using public key A, with F
            //    being 0 for Ed25519ctx, 1 for Ed25519ph, and if Ed25519ctx or
            //    Ed25519ph is being used, C being the context, first split the
            //    signature into two 32-octet halves.Decode the first half as a
            //    point R, and the second half as an integer S, in the range
            //    0 <= s<L.Decode the public key A as point A'.  If any of the
            //    decodings fail(including S being out of range), the signature is
            //    invalid.

            // 2. Compute SHA512(dom2(F, C) || R || A || PH(M)), and interpret the
            //    64-octet digest as a little-endian integer k.

            // 3. Check the group equation[8][S] B = [8] R + [8] [k] A'.  It's
            //    sufficient, but not required, to instead check[S]B = R + [k] A'.

            Assert.True(Signature.Length == 64, InvalidOperation.Throw);

            var Rs = Signature.Duplicate(0, 32);
            var R = Decode(Rs);

            var Bs = Signature.Duplicate(32, 32);
            var s = Bs.BigIntegerLittleEndian();

            if (s > Q) {
                return false;
                }

            var h = HashModQ(Context, Rs, Public, Message);

            var sB = Base.Multiply(s);
            var hA = Multiply(h);
            var Rha = hA.Add(R);

            var Result = sB.Equal(Rha);

            return Result;
            }


        }

    /// <summary>
    /// Manages the public key
    /// </summary>
    public class CurveEdwards25519Public : IKeyAdvancedPublic {

        /// <summary>The public key, i.e. a point on the curve</summary>
        public virtual CurveEdwards25519 Public { get; }

        /// <summary>Encoded form of the public key.</summary>
        public virtual byte[] Encoding { get; }

        /// <summary>
        /// Construct provider from public key parameters.
        /// </summary>
        /// <param name="public">The public key values.</param>
        public CurveEdwards25519Public(CurveEdwards25519 @public) {
            this.Public = @public;
            this.Encoding = @public.Encode();
            }

        /// <summary>
        /// Construct provider from public key data.
        /// </summary>
        /// <param name="encoding">The encoded public key value.</param>
        public CurveEdwards25519Public (byte[] encoding) {
            this.Public = CurveEdwards25519.Decode(encoding);
            this.Encoding = encoding;
            }


        /// <summary>
        /// Create a new ephemeral private key and use it to perform a key
        /// agreement.
        /// </summary>
        /// <returns>The key agreement parameters, the public key value and the
        /// key agreement.</returns>
        public CurveEdwards25519Result Agreement() {
            var Private = new CurveEdwards25519Private();

            return new CurveEdwards25519Result() {
                EphemeralPublicValue = Private.PublicKey,
                Agreement = Private.Agreement(this)
                };
            }


        /// <summary>
        /// Check that the Diffie Hellman parameters presented match those of this Key.
        /// </summary>
        /// <param name="Key">The key to verify.</param>
        public void Verify(CurveEdwards25519Public Key) => throw new NYI(); // NYI:


        /// <summary>
        /// Perform final stage in a Diffie Hellman Agreement to reduce an 
        /// array of carry returns to a single agreement result.
        /// </summary>
        /// <param name="Carry">The partial recryption results.</param>
        /// <returns>The key agreement value ZZ</returns>
        public CurveEdwards25519 Agreement(CurveEdwards25519[] Carry) {
            Assert.True(Carry.Length >= 1, InsufficientResults.Throw);

            var Total = CurveEdwards25519.Neutral;
            foreach (var Part in Carry) {
                Total.Accumulate(Part);
                }

            return Total;
            }


        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public CurveEdwards25519Public Combine(CurveEdwards25519Public contribution) {
            var NewPublic = Public .Add( contribution.Public) ;
            return new CurveEdwards25519Public((CurveEdwards25519)NewPublic);
            }


        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="Contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public IKeyAdvancedPublic Combine(IKeyAdvancedPublic Contribution) =>
            Combine(Contribution as CurveEdwards25519Public);

        /// <summary>
        /// Verify a signature on a message according to RFC8032.
        /// </summary>
        /// <remarks>This method does not prehash the message data since if
        /// prehashing is desired, it is because the data needs to be hashed
        /// before being presented.</remarks>
        /// <param name="Public">The public key</param>
        /// <param name="Message">The message data.</param>
        /// <param name="Signature">The encoded signature data.</param>
        /// <param name="Context">Context value, if used.</param>
        /// <returns>True if signature verification succeeded, otherwise false.</returns>
        public static bool Verify(byte[] Public, byte[] Message, byte[] Signature, byte[] Context = null) {
            Assert.True(Public.Length == 32, InvalidOperation.Throw);
            Assert.True(Signature.Length == 64, InvalidOperation.Throw);

            var A = CurveEdwards25519.Decode(Public);

            return A.VerifySignature(Public, Message, Signature, Context);
            }


        /// <summary>
        /// Verify a signature on a message according to RFC8032.
        /// </summary>
        /// <remarks>This method does not prehash the message data since if
        /// prehashing is desired, it is because the data needs to be hashed
        /// before being presented.</remarks>
        /// <param name="Message">The message data.</param>
        /// <param name="Signature">The encoded signature data.</param>
        /// <param name="Context">Context value, if used.</param>
        /// <returns>True if signature verification succeeded, otherwise false.</returns>
        public bool Verify(byte[] Message, byte[] Signature, byte[] Context = null) => Public.VerifySignature(Encoding, Message, Signature, Context);




        }


    /// <summary>
    /// Manages the private key.
    /// </summary>
    public class CurveEdwards25519Private : IKeyAdvancedPrivate {


        /// <summary>The random secret used to generate the private key</summary>
        byte[] Secret { get; }

        /// <summary>The private key, i.e. a scalar</summary>
        public BigInteger Private { get; }

        /// <summary>Hash of the secret value bytes [0:31]</summary>
        byte[] PreSecret { get; }

        /// <summary>Hash of the secret value bytes [31:63]</summary>
        byte[] HashPrefix { get; }

        /// <summary>The corresponding public key</summary>
        public CurveEdwards25519Public PublicKey { get; }

        /// <summary>If true, this is a recryption key.</summary>
        public bool IsRecryption { get; set; } = false;


        /// <summary>
        /// Generate a new private key
        /// </summary>
        public CurveEdwards25519Private() :
                this(Platform.GetRandomBytes(32)) => Secret = Platform.GetRandomBytes(32);

        /// <summary>
        /// Construct a private key from the specified binary representation.
        /// </summary>
        /// <param name="Secret">The byte array used to generate the secret key</param>
        public CurveEdwards25519Private(byte[] Secret) {

            this.Secret = Secret;

            var Buffer = Platform.SHA2_512.Process(Secret);
            PreSecret = Buffer.Duplicate(0, 32);
            HashPrefix = Buffer.Duplicate(32, 32);

            Private = ExtractPrivate(PreSecret);

            var PublicPoint = CurveEdwards25519.GetPublic(Private);
            PublicKey = new CurveEdwards25519Public(PublicPoint);
            }

        /// <summary>
        /// Construct a private key from the specified input buffer.
        /// </summary>
        /// <param name="Private">The private key</param>
        public CurveEdwards25519Private(BigInteger Private) {
            this.Private = Private;
            this.Secret = Private.ToByteArray();

            var PublicPoint = CurveEdwards25519.GetPublic(Private);
            PublicKey = new CurveEdwards25519Public(PublicPoint);
            }

        /// <summary>
        /// Generate a new private key using the specified Nonce value to generate
        /// a Witness value for the private key.
        /// </summary>
        /// <param name="Blind">The blinding value n.</param>
        /// <param name="Witness">The point [s-SHA512(n)]B where s is the secret key.</param>
        public CurveEdwards25519Private(
                    byte[] Blind, out CurveEdwards25519 Witness) {

            var SecretLocal = ExtractPrivate(Platform.GetRandomBytes(32));
            var SecretBlind = ExtractPrivate(Blind);

            var SecretValue = (SecretLocal + SecretBlind).Mod(DomainParameters.Curve25519.P);
            var Secret = ValidatePrivateBytes(SecretValue.ToByteArray());
            PreSecret = Secret;

            // Calculate the Prefix
            var Buffer = Platform.SHA2_512.Process(Secret);
            HashPrefix = Buffer.Duplicate(32, 32);

            // Calculate the public point
            var PublicPoint = CurveEdwards25519.GetPublic(Private);
            PublicKey = new CurveEdwards25519Public(PublicPoint);

            // Calculate the witness value
            Witness = CurveEdwards25519.GetPublic(SecretLocal);
            }

        /// <summary>
        /// Verify that a witness value was used to construct a public key.
        /// </summary>
        /// <param name="Blind">The blinding value.</param>
        /// <param name="Witness">The witness value.</param>
        /// <param name="Public">The resulting private key.</param>
        /// <returns>True if the value was correctly constructed using the specified witness, otherwise false.</returns>
        public bool VerifyWitness (byte[] Blind, CurveEdwards25519 Witness, CurveEdwards25519 Public) {
            var SecretBlind = ExtractPrivate(Blind);
            var PublicBlind = CurveEdwards25519.GetPublic(SecretBlind);

            var TestPublic = Witness.Add(PublicBlind);
            return TestPublic.Equal(Public);
            }


        /// <summary>
        /// Create the extended private key. The Private key is extended using the
        /// hash value.
        /// </summary>
        /// <param name="Hash">The hash value</param>
        /// <returns>The private key.</returns>
        public BigInteger ExtractPrivate(byte[] Hash) => ValidatePrivateBytes(Hash).BigIntegerLittleEndian();


        /// <summary>
        /// Create the extended private key. The Private key is extended using the
        /// hash value.
        /// </summary>
        /// <param name="Hash">The hash value</param>
        /// <returns>The private key.</returns>
        public byte[] ValidatePrivateBytes (byte[] Hash) {
            var Copy = new byte[32];
            Array.Copy(Hash, Copy, 32); // bytes 0-31

            Copy[0] = (byte)(Copy[0] & 0xf8);
            Copy[31] = (byte)((Copy[31] &0x7f) | 0x40);
            return Copy;
            }



        /// <summary>
        /// Sign a message using the public key according to RFC8032
        /// </summary>
        /// <remarks>This method does not prehash the message data since if
        /// prehashing is desired, it is because the data needs to be hashed
        /// before being presented.</remarks>
        /// <param name="Message">The message</param>
        /// <param name="Context">Context value, if used.</param>
        /// <returns>The encoded signature data</returns>
        public byte[] Sign(byte[] Message, byte[] Context = null) {

            // 1.Hash the private key, 32 octets, using SHA-512.  Let h denote the
            // resulting digest. Construct the secret scalar s from the first
            // half of the digest, and the corresponding public key A, as
            // described in the previous section.Let prefix denote the second
            // half of the hash digest, h[32],..., h[63].

            // 2.  Compute SHA-512(dom2(F, C) || prefix || PH(M)), where M is the
            // message to be signed.Interpret the 64-octet digest as a little-
            // endian integer r.

            // 3.  Compute the point[r]B. For efficiency, do this by first
            // reducing r modulo L, the group order of B.Let the string R be
            // the encoding of this point.

            // 4.  Compute SHA512(dom2(F, C) || R || A || PH(M)), and interpret the
            // 64-octet digest as a little-endian integer k.

            // 5.  Compute S = (r + k * s) mod L.For efficiency, again reduce k
            // modulo L first.

            // 6.  Form the signature of the concatenation of R (32 octets) and the
            // little-endian encoding of S(32 octets; the three most
            // significant bits of the final octet are always zero).


            var r = CurveEdwards25519.HashModQ(Context, HashPrefix, Message);
            var R = CurveEdwards25519.Base.Multiply(r);
            var Rs = R.Encode();

            var k = CurveEdwards25519.HashModQ(Context, Rs, PublicKey.Encoding, Message);
            var S = (r + k * Private) % CurveEdwards25519.Q;

            var Bs = S.ToByteArrayLittleEndian();

            var Result = new byte[64];
            Array.Copy(Rs, Result, Rs.Length);
            Array.Copy(Bs, 0, Result, 32, Bs.Length);

            return Result;
            }

        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a public key
        /// </summary>
        /// <param name="Public">Public key parameters</param>
        /// <returns>The key agreement value ZZ</returns>
        public CurveEdwards25519 Agreement(CurveEdwards25519Public Public) => (CurveEdwards25519)Public.Public.Multiply(Private);


        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a private key
        /// </summary>
        /// <param name="Public">Public key parameters</param>
        /// <param name="Carry">Recryption carry over value, to be combined with the
        /// result of this key agreement.</param>
        /// <returns>The key agreement value ZZ</returns>
        public CurveEdwards25519 Agreement(CurveEdwards25519Public Public, CurveEdwards25519 Carry) {
            var Result = Public.Public.Multiply(Private);
            Result.Accumulate(Carry);

            return Result;
            }

        #region // Advanced functions

        /// <summary>
        /// Split the private key into a number of recryption keys.
        /// <para>
        /// Since the
        /// typical use case for recryption requires both parts of the generated machine
        /// to be used on a machine that is not the machine on which they are created, the
        /// key security level is always to permit export.</para>
        /// </summary>
        /// <param name="shares">The number of keys to create.</param>
        /// <returns>The created keys</returns>
        public IKeyAdvancedPrivate[] MakeRecryptionKeySet(int shares) {
            BigInteger Accumulator = 0;
            var Result = new IKeyAdvancedPrivate[shares];

            for (var i = 1; i < shares; i++) {
                var NewPrivate = Platform.GetRandomBigInteger(CurveEdwards25519.Q);
                Result[i] = new CurveEdwards25519Private(NewPrivate) { IsRecryption = true };
                Accumulator = (Accumulator + NewPrivate).Mod(CurveEdwards25519.Q);
                }

            //Assert.True(Accumulator > 0 & Accumulator < Private, CryptographicException.Throw);

            Result[0] = new CurveEdwards25519Private(
                (CurveEdwards25519.Q + Private - Accumulator).Mod(CurveEdwards25519.Q)) {
                IsRecryption = true
                };
            return Result;

            }

        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="Contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public CurveEdwards25519Private Combine(CurveEdwards25519Private Contribution) {
            var NewPrivate = (Private + Contribution.Private).Mod(CurveEdwards25519.Q);
            return new CurveEdwards25519Private(NewPrivate);
            }


        /// <summary>
        /// Combine the two public keys to create a composite public key.
        /// </summary>
        /// <param name="Contribution">The key contribution.</param>
        /// <returns>The composite key</returns>
        public IKeyAdvancedPrivate Combine(IKeyAdvancedPrivate Contribution) =>
            Combine(Contribution as DiffeHellmanPrivate);
        #endregion
        }


    /// <summary>
    /// Represent the result of a Diffie Hellman Key exchange.
    /// </summary>
    public class CurveEdwards25519Result : ResultECDH {

        /// <summary>The key agreement result</summary>
        public CurveEdwards25519 Agreement;

        /// <summary>The agreement as ASN.1 DER encoding</summary>
        /// <returns>The DER encoded value.</returns>
        public override byte[] DER() => Agreement.Encode();


        /// <summary>The key agreement result as a byte array</summary>
        public override byte[] IKM => Agreement.Encode();

        /// <summary>
        /// The Ephemeral public key
        /// </summary>
        public override KeyPair EphemeralKeyPair => new KeyPairEd25519(EphemeralPublicValue as CurveEdwards25519Public);


        /// <summary>Carry from proxy recryption efforts</summary>
        public CurveEdwards25519 Carry;

        /// <summary>Public key generated by ephemeral key generation.</summary>
        public CurveEdwards25519Public Public => EphemeralPublicValue as CurveEdwards25519Public;



        }



    }
