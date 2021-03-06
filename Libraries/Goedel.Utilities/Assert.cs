﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Goedel.Utilities {


    /// <summary>
    /// Delegate that will be thrown as an exception if a condition is met
    /// </summary>
    /// <param name="Reason">The reason for raising the exception.</param>
    /// <returns>The exception to throw</returns>
    public delegate System.Exception ThrowDelegate(object Reason = null);

    /// <summary>
    /// Convenience class for constructing an object on the fly to report exception
    /// parameters of type integer or string.
    /// </summary>
    public class ExceptionData {
        /// <summary>An integer value;</summary>
        public int Int { get; set; }

        /// <summary>A string value</summary>
        public string String { get; set; }

        /// <summary>
        /// Factory method to create and return object with specified integer
        /// and/or string values.
        /// </summary>
        /// <param name="Int">The integer value</param>
        /// <param name="String">The string value</param>
        /// <returns>The boxed exception data.</returns>
        public static ExceptionData Box(int Int = 0, string String = "") => new ExceptionData() {
            Int = Int,
            String = String
            };
        }



    /// <summary>
    /// Convenience routines to test various types of assertion and throw
    /// an exception using an exception factory method such as the ones
    /// created by Exceptional.
    /// </summary>
    public static class Assert {

        /// <summary>
        /// Cache and return a value. This is used to produce compact expression
        /// body methods for properties that are only evaluated the first time
        /// they are called.
        /// </summary>
        /// <typeparam name="T">The type of data to be cached.</typeparam>
        /// <param name="Value">The value to be stored.</param>
        /// <param name="Store">The store that the value is to be written to.</param>
        /// <returns>The stored value.</returns>
        public static T CacheValue <T> (this T Value, out T Store) where T : class {
            Store = Value;
            return Value;
            }


        /// <summary>Throw an exception if the specified condition is true. 
        ///Assert.False (test, NYIException.Throw, "test was true")
        /// </summary>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="Reason">Reason data for filling throw template</param>
        /// <param name="Int">Integer default parameter</param>
        /// <param name="String">String default parameter</param>
        public static void Fail (ThrowDelegate Throw = null,
                    object Reason = null, string String = null, int Int = -1) {

            Reason = Reason ?? new ExceptionData() {
                String = String,
                Int = Int
                };
            Throw = Throw ?? Utilities.NYI.Throw;
            throw Throw(Reason);
            }


        /// <summary>Throw a Not Yet Implemented exception.
        /// </summary>
        /// <param name="Reason">Reason data for filling throw template</param>
        /// <param name="Int">Integer default parameter</param>
        /// <param name="String">String default parameter</param>
        public static void NYI(object Reason = null, string String = null, int Int = -1) => Fail(Utilities.NYI.Throw, Reason, String, Int);

        /// <summary>Throw an exception if the specified condition is true. 
        ///Assert.False (test, NYIException.Throw, "test was true")
        /// </summary>
        /// <param name="Condition">The condition</param>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="Reason">Reason data for filling throw template</param>
        /// <param name="Int">Integer default parameter</param>
        /// <param name="String">String default parameter</param>
        public static void False(bool Condition, ThrowDelegate Throw=null, 
                    object Reason=null, string String = null, int Int = -1) {
            if (Condition) {
                Fail(Throw, Reason, String, Int);
                }
            }

        /// <summary>Throw an exception if the specified condition is true. 
        ///(test, NYIException.Throw, "test was true").AssertFalse();
        /// </summary>
        /// <param name="Condition">The condition</param>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="Reason">Reason data for filling throw template</param>
        /// <param name="Int">Integer default parameter</param>
        /// <param name="String">String default parameter</param>
        public static void AssertFalse(this bool Condition, ThrowDelegate Throw = null,
            object Reason = null, string String = null, int Int = -1) => False(
                Condition, Throw, Reason, String, Int);

        /// <summary>Throw an exception if the specified condition is false. 
        ///Assert.True (test, NYIException.Throw, "test was false")
        /// </summary>
        /// <param name="Condition">The condition</param>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="Reason">Reason data for filling throw template</param>
        /// <param name="Int">Integer default parameter</param>
        /// <param name="String">String default parameter</param>
        public static void True(bool Condition, ThrowDelegate Throw=null,
                    object Reason = null, string String = null, int Int = -1) {
            if (!Condition) {
                Fail(Throw, Reason, String, Int);
                }
            }

        /// <summary>Throw an exception if the specified condition is false. 
        /// (test, NYIException.Throw, "test was false").AssertTrue();
        /// </summary>
        /// <param name="Condition">The condition</param>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="Reason">Reason data for filling throw template</param>
        /// <param name="Int">Integer default parameter</param>
        /// <param name="String">String default parameter</param>
        public static void AssertTrue(this bool Condition, ThrowDelegate Throw = null,
            object Reason = null, string String = null, int Int = -1) => True(
                Condition, Throw, Reason, String, Int);


        /// <summary>Throw an exception if the specified object is not null. 
        /// </summary>
        /// <param name="Object">The condition</param>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="Reason">Reason data for filling throw template</param>
        /// <param name="Int">Integer default parameter</param>
        /// <param name="String">String default parameter</param>
        public static void Null(object Object, ThrowDelegate Throw = null,
                    object Reason = null, string String = null, int Int = -1) => True(Object == null, Throw, Reason, String, Int);

        /// <summary>Throw an exception if the specified object is not null. 
        /// </summary>
        /// <param name="Object">The condition</param>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="Reason">Reason data for filling throw template</param>
        /// <param name="Int">Integer default parameter</param>
        /// <param name="String">String default parameter</param>
        public static void AssertNull(this object Object, ThrowDelegate Throw = null,
                    object Reason = null, string String = null, int Int = -1) => True(Object == null, Throw, Reason, String, Int);



        /// <summary>Throw an exception if the specified object is not null. 
        /// </summary>
        /// <param name="Object">The condition</param>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="Reason">Reason data for filling throw template</param>
        /// <param name="Int">Integer default parameter</param>
        /// <param name="String">String default parameter</param>
        public static void NotNull(this object Object, ThrowDelegate Throw = null,
                    object Reason = null, string String = null, int Int = -1) => True(Object != null, Throw, Reason, String, Int);


        /// <summary>Throw an exception if the specified object is not null. 
        /// </summary>
        /// <param name="Object">The condition</param>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="Reason">Reason data for filling throw template</param>
        /// <param name="Int">Integer default parameter</param>
        /// <param name="String">String default parameter</param>
        public static void AssertNotNull(this object Object, ThrowDelegate Throw = null,
                    object Reason = null, string String = null, int Int = -1) => True(Object != null, Throw, Reason, String, Int);


        /// <summary>Test to see if two arrays are equal.
        /// </summary>
        /// <param name="Test1">First test value</param>
        /// <param name="Test2">Second test value</param>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="Reason">Reason data for filling throw template</param>
        /// <param name="Int">Integer default parameter</param>
        /// <param name="String">String default parameter</param>

        public static void AssertEqual(this byte[] Test1, byte[] Test2, ThrowDelegate Throw = null,
                    object Reason = null, string String = null, int Int = -1) => AssertTrue(
                        ArrayUtilities.IsEqualTo(Test1, Test2), Throw, Reason, String, Int);

        /// <summary>Test to see if two arrays are equal.
        /// </summary>
        /// <param name="Test1">First test value</param>
        /// <param name="Test2">Second test value</param>
        /// <param name="Throw">Delegate that creates the exception to be thrown if
        /// Condition is true</param>
        /// <param name="Reason">Reason data for filling throw template</param>
        /// <param name="Int">Integer default parameter</param>
        /// <param name="String">String default parameter</param>

        public static void AssertEqual<T>(this T Test1, T Test2, ThrowDelegate Throw = null,
                    object Reason = null, string String = null, int Int = -1) => AssertTrue(
                        Test1.Equals(Test2), Throw, Reason, String, Int);


        /// <summary>
        /// Utility routine used to flag missing code to implement missing
        /// cryptographic authentication check
        /// </summary>
        /// <param name="description"></param>
        public static void TaskValidate(this string description) { }


        /// <summary>
        /// Utility routine used to flag missing code to implement missing test for
        /// functionality not yet implemented.
        /// </summary>
        /// <param name="description"></param>
        public static void TaskTest(this string description) { }

        /// <summary>
        /// Utility routine used to flag missing code to implement missing test for
        /// functionality not yet implemented.
        /// </summary>
        /// <param name="description"></param>
        public static void TaskFunctionality(this string description) { }
        }

    }

