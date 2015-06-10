using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

namespace MathLinq
{
    /// <summary>
    /// Provides a set of extension methods that wraps built-in mathematical methods 
    /// so they can be used by the MathEnumerable&lt;T&gt; class.
    /// </summary>
    public static class MathExtensions
    {

        #region MathEnumerable wrappers

        #region System.Math wrappers


        /// <summary>
        /// Returns the absolute value of each element of a sequence of System.Double numbers.
        /// </summary>
        /// <param name="source">A sequence of double numbers. </param>
        /// <returns>The sequence of numbers such that each number >= 0.</returns>
        public static MathEnumerable<double> Abs(this MathEnumerable<double> source)
        {
            return source.Select(d => Math.Abs(d));
        }

        /// <summary>
        /// Returns the absolute value of each element of a sequence of System.Decimal numbers.
        /// </summary>
        /// <param name="source">A sequence of decimal numbers. </param>
        /// <returns>The sequence of numbers such that each number >= 0.</returns>
        public static MathEnumerable<decimal> Abs(this MathEnumerable<decimal> source)
        {
            return source.Select(d => Math.Abs(d));
        }

        /// <summary>
        /// Returns the absolute value of each element of a sequence of single-precision numbers.
        /// </summary>
        /// <param name="source">A sequence of single-precision numbers </param>
        /// <returns>The sequence of numbers such that each number >= 0.</returns>
        public static MathEnumerable<float> Abs(this MathEnumerable<float> source)
        {
            return source.Select(d => Math.Abs(d));
        }

        /// <summary>
        /// Returns the absolute value of each element of a sequence of 32-bit signed integers.
        /// </summary>
        /// <param name="source">A sequence of 32-bit signed integers. </param>
        /// <returns>The sequence of numbers such that each number >= 0.</returns>
        public static MathEnumerable<int> Abs(this MathEnumerable<int> source)
        {
            return source.Select(d => Math.Abs(d));
        }

        /// <summary>
        /// Returns the arccosine of each element of a sequence of double-precision numbers.
        /// </summary>
        /// <param name="source">A sequence of double-precision numbers representing the cosine. </param>
        /// <returns>The sequence of angles in radians.</returns>
        public static MathEnumerable<double> Acos(this MathEnumerable<double> source)
        {
            return source.Select(d => Math.Acos(d));
        }

        /// <summary>
        /// Returns the arcsine of each element of a sequence of double-precision numbers.
        /// </summary>
        /// <param name="source">A sequence of double-precision numbers representing the sine. </param>
        /// <returns>The sequence of angles in radians.</returns>
        public static MathEnumerable<double> Asin(this MathEnumerable<double> source)
        {
            return source.Select(d => Math.Asin(d));
        }

        /// <summary>
        /// Returns the arctangent of each element of a sequence of double-precision numbers.
        /// </summary>
        /// <param name="source">A sequence of double-precision numbers representing the sine. </param>
        /// <returns>The sequence of angles in radians.</returns>
        public static MathEnumerable<double> Atan(this MathEnumerable<double> source)
        {
            return source.Select(d => Math.Atan(d));
        }

        /// <summary>
        /// Returns the four quadrant arctangent of each element of a sequence of double-precision numbers.
        /// </summary>
        /// <param name="y">y</param>
        /// <param name="x">x</param>
        /// <returns>The sequoence of four quadrant elements.</returns>
        public static MathEnumerable<double> Atan2(this MathEnumerable<double> y, MathEnumerable<double> x)
        {
            return y.Zip(x, (yd, xd) => Math.Atan2(yd, xd));
        }

        /// <summary>
        /// Produces the full product of two 32-bit sequences.
        /// </summary>
        /// <param name="a">The first System.Int32 sequence to multiply.</param>
        /// <param name="b">The second System.Int32 sequence to multiply.</param>
        /// <returns>The System.Int64 sequence containing the product of the specified sequences.</returns>
        public static MathEnumerable<long> BigMul(this MathEnumerable<int> a, MathEnumerable<int> b)
        {
            return a.Zip(b, (ai, bi) => Math.BigMul(ai, bi));
        }

        /// <summary>
        /// Produces the full product of a 32-bit sequence and a 32-bit number.
        /// </summary>
        /// <param name="a">The System.Int32 sequence to multiply.</param>
        /// <param name="b">The second System.Int32 number to multiply.</param>
        /// <returns>The System.Int64 sequence containing the product of the specified parameters.</returns>
        public static MathEnumerable<long> BigMul(this MathEnumerable<int> a, int b)
        {
            return a.Select(ai => Math.BigMul(ai, b));
        }

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the
        /// specified decimal sequence.
        /// </summary>
        /// <param name="source">A decimal sequence.</param>
        /// <returns>The smallest integral value that is greater than or equal to source. Note that
        /// this method returns System.Decimal instead of an integral type.</returns>
        public static MathEnumerable<decimal> Ceiling(this MathEnumerable<decimal> source)
        {
            return source.Select(d => Math.Ceiling(d));
        }

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the
        /// specified double-precision floating-point sequence.
        /// </summary>
        /// <param name="source">A double sequence.</param>
        /// <returns>The smallest integral value that is greater than or equal to the elements of source. If source elements are equal
        /// to System.Double.NaN, System.Double.NegativeInfinity, or System.Double.PositiveInfinity,
        /// that value is returned. Note that this method returns a System.Double instead
        /// of an integral type.</returns>
        public static MathEnumerable<double> Ceiling(this MathEnumerable<double> source)
        {
            return source.Select(a => Math.Ceiling(a));
        }

        /// <summary>
        /// Returns the cosine of the specified sequence of angles.
        /// </summary>
        /// <param name="source">A sequence of angles, measured in radians.</param>
        /// <returns>The cosine of source. If source is equal to System.Double.NaN, System.Double.NegativeInfinity,
        /// or System.Double.PositiveInfinity, this method returns System.Double.NaN.</returns>
        public static MathEnumerable<double> Cos(this MathEnumerable<double> source)
        {
            return source.Select(d => Math.Cos(d));
        }

        /// <summary>
        /// Returns the hyperbolic cosine of the specified sequence of angles.
        /// </summary>
        /// <param name="source">A sequence of angles, measured in radians.</param>
        /// <returns>The hyperbolic cosine of value. If a value is equal to System.Double.NegativeInfinity
        /// or System.Double.PositiveInfinity, System.Double.PositiveInfinity is returned.
        /// If a value is equal to System.Double.NaN, System.Double.NaN is returned.</returns>
        public static MathEnumerable<double> Cosh(this MathEnumerable<double> source)
        {
            return source.Select(d => Math.Cosh(d));
        }

        //public static MathEnumerable<int> DivRem(this MathEnumerable<int> a, MathEnumerable<int> b, out MathEnumerable<int> result)
        //{
        //    return source.Select(d => Math.Cosh(d));
        //}

        /// <summary>
        /// Returns e raised to the specified powers.
        /// </summary>
        /// <param name="source">A sequence of numbers specifying the power.</param>
        /// <returns>The number e raised to the power source. If elements of source equals System.Double.NaN or System.Double.PositiveInfinity,
        /// that value is returned. If elements of source equals System.Double.NegativeInfinity, 0 is
        /// returned.</returns>
        public static MathEnumerable<double> Exp(this MathEnumerable<double> source)
        {
            return source.Select(d => Math.Exp(d));
        }

        /// <summary>
        /// Returns the sequence of largest integers less than or equal to the specified decimal numbers.
        /// </summary>
        /// <param name="source">A sequence of decimal number.</param>
        /// <returns>The sequence of largest integers less than or equal to source.</returns>
        public static MathEnumerable<decimal> Floor(this MathEnumerable<decimal> source)
        {
            return source.Select(d => Math.Floor(d));
        }

        /// <summary>
        /// Returns the sequence of largest integers less than or equal to the specified double-precision numbers.
        /// </summary>
        /// <param name="source">A sequence of double-precision numbers.</param>
        /// <returns>The sequence of largest integers less than or equal to source. If source is equal to System.Double.NaN,
        /// System.Double.NegativeInfinity, or System.Double.PositiveInfinity, that value
        /// is returned.</returns>
        public static MathEnumerable<double> Floor(this MathEnumerable<double> source)
        {
            return source.Select(d => Math.Floor(d));
        }

        /// <summary>
        /// Returns the sequence of remainders resulting from the division of a specified sequence by
        /// another specified sequence.
        /// </summary>
        /// <param name="x">A sequence of dividends.</param>
        /// <param name="y">A sequence of divisors.</param>
        /// <returns>A sequnce of numbers equal to x - (y Q), where Q is the quotient of x / y rounded to
        /// the nearest integer (if x / y falls halfway between two integers, the even
        /// integer is returned).If x - (y Q) is zero, the value +0 is returned if x
        /// is positive, or -0 if x is negative.If y = 0, System.Double.NaN is returned.</returns>
        public static MathEnumerable<double> IEEERemainder(this MathEnumerable<double> x, MathEnumerable<double> y)
        {
            return x.Zip(y, (xi, yi) => Math.IEEERemainder(xi, yi));
        }

        /// <summary>
        /// Returns the sequence of remainders resulting from the division of a specified sequence by
        /// another specified sequence.
        /// </summary>
        /// <param name="x">A sequence of dividends.</param>
        /// <param name="y">A divisor.</param>
        /// <returns>A sequnce of numbers equal to x - (y Q), where Q is the quotient of x / y rounded to
        /// the nearest integer (if x / y falls halfway between two integers, the even
        /// integer is returned).If x - (y Q) is zero, the value +0 is returned if x
        /// is positive, or -0 if x is negative.If y = 0, System.Double.NaN is returned.</returns>
        public static MathEnumerable<double> IEEERemainder(this MathEnumerable<double> x, double y)
        {
            return x.Select(xi => Math.IEEERemainder(xi, y));
        }

        /// <summary>
        /// Returns the natural (base e) logarithm of a specified number sequence.
        /// </summary>
        /// <param name="source">A sequence of double-precision numbers.</param>
        /// <returns>One of the values in the following table. d parameterReturn value Positive
        /// The natural logarithm of d; that is, ln d, or log edZero System.Double.NegativeInfinityNegative
        /// System.Double.NaNEqual to System.Double.NaNSystem.Double.NaNEqual to System.Double.PositiveInfinitySystem.Double.PositiveInfinity</returns>
        public static MathEnumerable<double> Log(this MathEnumerable<double> source)
        {
            return source.Select(d => Math.Log(d));
        }

        /// <summary>
        /// Returns the logarithm of a specified number sequence in a specified base.
        /// </summary>
        /// <param name="source">A sequence of double-precsision numbers.</param>
        /// <param name="newBase">The base of the logarithm.</param>
        /// <returns>One of the values in the following table. (+Infinity denotes System.Double.PositiveInfinity,
        /// -Infinity denotes System.Double.NegativeInfinity, and NaN denotes System.Double.NaN.)anewBaseReturn
        /// valuea&gt; 0(0 &lt;newBase&lt; 1) -or-(newBase&gt; 1)lognewBase(a)a&lt; 0(any value)NaN(any
        /// value)newBase&lt; 0NaNa != 1newBase = 0NaNa != 1newBase = +InfinityNaNa = NaN(any
        /// value)NaN(any value)newBase = NaNNaN(any value)newBase = 1NaNa = 00 &lt;newBase&lt;
        /// 1 +Infinitya = 0newBase&gt; 1-Infinitya = +Infinity0 &lt;newBase&lt; 1-Infinitya =
        /// +InfinitynewBase&gt; 1+Infinitya = 1newBase = 00a = 1newBase = +Infinity0</returns>
        public static MathEnumerable<double> Log(this MathEnumerable<double> source, double newBase)
        {
            return source.Select(d => Math.Log(d, newBase));
        }

        /// <summary>
        /// Returns the base 10 logarithm of a number sequence.
        /// </summary>
        /// <param name="source">A sequence of double-precsision numbers.</param>
        /// <returns>One of the values in the following table. d parameter Return value Positive
        /// The base 10 log of d; that is, log 10d. Zero System.Double.NegativeInfinityNegative
        /// System.Double.NaNEqual to System.Double.NaNSystem.Double.NaNEqual to System.Double.PositiveInfinitySystem.Double.PositiveInfinity</returns>
        public static MathEnumerable<double> Log10(this MathEnumerable<double> source)
        {
            return source.Select(d => Math.Log10(d));
        }

        /// <summary>
        /// Returns the sequence of largest 8-bit unsigned integers.
        /// </summary>
        /// <param name="val1">The first of two sequences of 8-bit unsigned integers to compare.</param>
        /// <param name="val2">The second of two sequences of 8-bit unsigned integers to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is larger.</returns>
        public static MathEnumerable<byte> Max(this MathEnumerable<byte> val1, MathEnumerable<byte> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Max(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of largest decimal numbers.
        /// </summary>
        /// <param name="val1">The first of two sequences of decimal numbers to compare.</param>
        /// <param name="val2">The second of two sequences of decimal numers to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is larger.</returns>
        public static MathEnumerable<decimal> Max(this MathEnumerable<decimal> val1, MathEnumerable<decimal> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Max(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of largest doubles.
        /// </summary>
        /// <param name="val1">The first of two sequences of doubles to compare.</param>
        /// <param name="val2">The second of two sequences of doubles to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is larger.</returns>
        public static MathEnumerable<double> Max(this MathEnumerable<double> val1, MathEnumerable<double> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Max(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of largest floats.
        /// </summary>
        /// <param name="val1">The first of two sequences of floats to compare.</param>
        /// <param name="val2">The second of two sequences of floats to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is larger.</returns>
        public static MathEnumerable<float> Max(this MathEnumerable<float> val1, MathEnumerable<float> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Max(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of largest 32-bit integers.
        /// </summary>
        /// <param name="val1">The first of two sequences of 32-bit integers to compare.</param>
        /// <param name="val2">The second of two sequences of 32-bit integers to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is larger.</returns>
        public static MathEnumerable<int> Max(this MathEnumerable<int> val1, MathEnumerable<int> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Max(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of largest 64-bit integers.
        /// </summary>
        /// <param name="val1">The first of two sequences of 64-bit integers to compare.</param>
        /// <param name="val2">The second of two sequences of 64-bit integers to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is larger.</returns>
        public static MathEnumerable<long> Max(this MathEnumerable<long> val1, MathEnumerable<long> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Max(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of largest 8-bit integers.
        /// </summary>
        /// <param name="val1">The first of two sequences of 8-bit integers to compare.</param>
        /// <param name="val2">The second of two sequences of 8-bit integers to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is larger.</returns>
        public static MathEnumerable<sbyte> Max(this MathEnumerable<sbyte> val1, MathEnumerable<sbyte> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Max(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of largest 16-bit integers.
        /// </summary>
        /// <param name="val1">The first of two sequences of 16-bit integers to compare.</param>
        /// <param name="val2">The second of two sequences of 16-bit integers to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is larger.</returns>
        public static MathEnumerable<short> Max(this MathEnumerable<short> val1, MathEnumerable<short> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Max(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of largest 32-bit unsigned integers.
        /// </summary>
        /// <param name="val1">The first of two sequences of 32-bit unsigned integers to compare.</param>
        /// <param name="val2">The second of two sequences of 32-bit unsigned integers to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is larger.</returns>
        public static MathEnumerable<uint> Max(this MathEnumerable<uint> val1, MathEnumerable<uint> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Max(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of largest 64-bit unsigned integers.
        /// </summary>
        /// <param name="val1">The first of two sequences of 64-bit unsigned integers to compare.</param>
        /// <param name="val2">The second of two sequences of 64-bit unsigned integers to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is larger.</returns>
        public static MathEnumerable<ulong> Max(this MathEnumerable<ulong> val1, MathEnumerable<ulong> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Max(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of largest 16-bit unsigned integers.
        /// </summary>
        /// <param name="val1">The first of two sequences of 16-bit unsigned integers to compare.</param>
        /// <param name="val2">The second of two sequences of 16-bit unsigned integers to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is larger.</returns>
        public static MathEnumerable<ushort> Max(this MathEnumerable<ushort> val1, MathEnumerable<ushort> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Max(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of smallest 8-bit unsigned integers.
        /// </summary>
        /// <param name="val1">The first of two sequences of 8-bit unsigned integers to compare.</param>
        /// <param name="val2">The second of two sequences of 8-bit unsigned integers to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is smaller.</returns>
        public static MathEnumerable<byte> Min(this MathEnumerable<byte> val1, MathEnumerable<byte> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Min(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of smallest decimal numbers.
        /// </summary>
        /// <param name="val1">The first of two sequences of decimal numbers to compare.</param>
        /// <param name="val2">The second of two sequences of decimal numers to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is smaller.</returns>
        public static MathEnumerable<decimal> Min(this MathEnumerable<decimal> val1, MathEnumerable<decimal> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Min(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of smallest doubles.
        /// </summary>
        /// <param name="val1">The first of two sequences of doubles to compare.</param>
        /// <param name="val2">The second of two sequences of doubles to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is smaller.</returns>
        public static MathEnumerable<double> Min(this MathEnumerable<double> val1, MathEnumerable<double> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Min(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of smallest floats.
        /// </summary>
        /// <param name="val1">The first of two sequences of floats to compare.</param>
        /// <param name="val2">The second of two sequences of floats to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is smaller.</returns>
        public static MathEnumerable<float> Min(this MathEnumerable<float> val1, MathEnumerable<float> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Min(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of smallest 32-bit integers.
        /// </summary>
        /// <param name="val1">The first of two sequences of 32-bit integers to compare.</param>
        /// <param name="val2">The second of two sequences of 32-bit integers to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is smaller.</returns>
        public static MathEnumerable<int> Min(this MathEnumerable<int> val1, MathEnumerable<int> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Min(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of smallest 64-bit integers.
        /// </summary>
        /// <param name="val1">The first of two sequences of 64-bit integers to compare.</param>
        /// <param name="val2">The second of two sequences of 64-bit integers to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is smaller.</returns>
        public static MathEnumerable<long> Min(this MathEnumerable<long> val1, MathEnumerable<long> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Min(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of smallest 8-bit integers.
        /// </summary>
        /// <param name="val1">The first of two sequences of 8-bit integers to compare.</param>
        /// <param name="val2">The second of two sequences of 8-bit integers to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is smaller.</returns>
        public static MathEnumerable<sbyte> Min(this MathEnumerable<sbyte> val1, MathEnumerable<sbyte> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Min(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of smallest 16-bit integers.
        /// </summary>
        /// <param name="val1">The first of two sequences of 16-bit integers to compare.</param>
        /// <param name="val2">The second of two sequences of 16-bit integers to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is smaller.</returns>
        public static MathEnumerable<short> Min(this MathEnumerable<short> val1, MathEnumerable<short> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Min(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of smallest 32-bit unsigned integers.
        /// </summary>
        /// <param name="val1">The first of two sequences of 32-bit unsigned integers to compare.</param>
        /// <param name="val2">The second of two sequences of 32-bit unsigned integers to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is smaller.</returns>
        public static MathEnumerable<uint> Min(this MathEnumerable<uint> val1, MathEnumerable<uint> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Min(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of smallest 64-bit unsigned integers.
        /// </summary>
        /// <param name="val1">The first of two sequences of 64-bit unsigned integers to compare.</param>
        /// <param name="val2">The second of two sequences of 64-bit unsigned integers to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is smaller.</returns>
        public static MathEnumerable<ulong> Min(this MathEnumerable<ulong> val1, MathEnumerable<ulong> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Min(v1, v2));
        }

        /// <summary>
        /// Returns the sequence of smallest 16-bit unsigned integers.
        /// </summary>
        /// <param name="val1">The first of two sequences of 16-bit unsigned integers to compare.</param>
        /// <param name="val2">The second of two sequences of 16-bit unsigned integers to compare.</param>
        /// <returns>Sequence of element-wise val1 or val2, whichever is smaller.</returns>
        public static MathEnumerable<ushort> Min(this MathEnumerable<ushort> val1, MathEnumerable<ushort> val2)
        {
            return val1.Zip(val2, (v1, v2) => Math.Min(v1, v2));
        }

        /// <summary>
        /// Raises each element of a sequence to a specified power
        /// </summary>
        /// <param name="source">A sequence of doubles to be raised to a power</param>
        /// <param name="y">A double-precision number that specifies a power</param>
        /// <returns>The sequence of elements raised to the power y</returns>
        public static MathEnumerable<double> Pow(this MathEnumerable<double> source, double y)
        {
            return source.Select(d => Math.Pow(d, y));
        }

        /// <summary>
        /// Rounds a sequence of decimal values to their nearest integral value.
        /// </summary>
        /// <param name="source">A sequence of decimal values to be rounded.</param>
        /// <returns>The integer nearest parameter d. If the fractional component of d is halfway
        /// between two integers, one of which is even and the other odd, the even number
        /// is returned. Note that this method returns a System.Decimal instead of an
        /// integral type.</returns>
        public static MathEnumerable<decimal> Round(this MathEnumerable<decimal> source)
        {
            return source.Select(d => Math.Round(d));
        }

        /// <summary>
        /// Rounds a sequence of doubles to their nearest integral value.
        /// </summary>
        /// <param name="source">A sequence of doubles to be rounded.</param>
        /// <returns>The integer nearest parameter d. If the fractional component of d is halfway
        /// between two integers, one of which is even and the other odd, the even number
        /// is returned. Note that this method returns a System.Double instead of an
        /// integral type.</returns>
        public static MathEnumerable<double> Round(this MathEnumerable<double> source)
        {
            return source.Select(d => Math.Round(d));
        }

        /// <summary>
        /// Rounds a sequence of decimal values to a specified number of fractional digits.
        /// </summary>
        /// <param name="source">A sequence of decimal values to be rounded.</param>
        /// <param name="decimals">The number of decimal places in the return value.</param>
        /// <returns>The numbers nearest to source that contains a number of fractional digits equal
        /// to decimals.</returns>
        public static MathEnumerable<decimal> Round(this MathEnumerable<decimal> source, int decimals)
        {
            return source.Select(d => Math.Round(d, decimals));
        }

        /// <summary>
        /// Rounds a sequence of decimal values to the nearest integer. A parameter specifies how
        /// to round the value if it is midway between two other numbers.
        /// </summary>
        /// <param name="source">A sequence of decimal values to be rounded.</param>
        /// <param name="mode">Specification for how to round a value if it is midway between two other numbers.</param>
        /// <returns>The integers nearest to the elements of source. If an element is halfway between two numbers, one of which
        /// is even and the other odd, then mode determines which of the two is returned.</returns>
        public static MathEnumerable<decimal> Round(this MathEnumerable<decimal> source, MidpointRounding mode)
        {
            return source.Select(d => Math.Round(d, mode));
        }

        /// <summary>
        /// Rounds a sequence of doubles to a specified number of fractional digits.
        /// </summary>
        /// <param name="source">A sequence of doubles to be rounded.</param>
        /// <param name="digits">The number of decimal places in the return value.</param>
        /// <returns>The numbers nearest to source that contains a number of fractional digits equal
        /// to decimals.</returns>
        public static MathEnumerable<double> Round(this MathEnumerable<double> source, int digits)
        {
            return source.Select(d => Math.Round(d, digits));
        }

        /// <summary>
        /// Rounds a sequence of doubles to the nearest integer. A parameter specifies how
        /// to round the value if it is midway between two other numbers.
        /// </summary>
        /// <param name="source">A sequence of doubles to be rounded.</param>
        /// <param name="mode">Specification for how to round a value if it is midway between two other numbers.</param>
        /// <returns>The integers nearest to the elements of source. If an element is halfway between two numbers, one of which
        /// is even and the other odd, then mode determines which of the two is returned.</returns>
        public static MathEnumerable<double> Round(this MathEnumerable<double> source, MidpointRounding mode)
        {
            return source.Select(d => Math.Round(d, mode));
        }

        /// <summary>
        /// Rounds a sequence of decimal values to a specified number of fractional digits. A parameter
        /// specifies how to round the value if it is midway between two other numbers.
        /// </summary>
        /// <param name="source">A sequence of decimal values to be rounded.</param>
        /// <param name="decimals">The number of decimal places in the return value.</param>
        /// <param name="mode">Specification for how to round a value if it is midway between two other numbers.</param>
        /// <returns>The numbers nearest to source that contains a number of fractional digits equal
        /// to decimals. If the number of fractional digits in d is less than decimals,
        /// d is returned unchanged.</returns>
        public static MathEnumerable<decimal> Round(this MathEnumerable<decimal> source, int decimals, MidpointRounding mode)
        {
            return source.Select(d => Math.Round(d, decimals, mode));
        }

        /// <summary>
        /// Rounds a sequence of doubles to a specified number of fractional digits. A parameter
        /// specifies how to round the value if it is midway between two other numbers.
        /// </summary>
        /// <param name="source">A sequence of doubles to be rounded.</param>
        /// <param name="digits">The number of decimal places in the return value.</param>
        /// <param name="mode">Specification for how to round a value if it is midway between two other numbers.</param>
        /// <returns>The numbers nearest to source that contains a number of fractional digits equal
        /// to decimals. If the number of fractional digits in d is less than decimals,
        /// d is returned unchanged.</returns>
        public static MathEnumerable<double> Round(this MathEnumerable<double> source, int digits, MidpointRounding mode)
        {
            return source.Select(d => Math.Round(d, digits, mode));
        }

        /// <summary>
        /// Returns values indicating the sign of a sequence of decimal numbers.
        /// </summary>
        /// <param name="source">A sequence of signed System.Decimal numbers.</param>
        /// <returns>A sequence of number that indicates the sign of the values of source, as shown in the following table.Return
        /// value Meaning -1 value is less than zero. 0 value is equal to zero. 1 value
        /// is greater than zero.</returns>
        public static MathEnumerable<int> Sign(this MathEnumerable<decimal> source)
        {
            return source.Select(d => Math.Sign(d));
        }

        /// <summary>
        /// Returns values indicating the sign of a sequence of doubles.
        /// </summary>
        /// <param name="source">A sequence of signed System.Double numbers.</param>
        /// <returns>A sequence of number that indicates the sign of the values of source, as shown in the following table.Return
        /// value Meaning -1 value is less than zero. 0 value is equal to zero. 1 value
        /// is greater than zero.</returns>
        public static MathEnumerable<int> Sign(this MathEnumerable<double> source)
        {
            return source.Select(d => Math.Sign(d));
        }

        /// <summary>
        /// Returns values indicating the sign of a sequence of floats.
        /// </summary>
        /// <param name="source">A sequence of signed System.Float numbers.</param>
        /// <returns>A sequence of number that indicates the sign of the values of source, as shown in the following table.Return
        /// value Meaning -1 value is less than zero. 0 value is equal to zero. 1 value
        /// is greater than zero.</returns>        
        public static MathEnumerable<int> Sign(this MathEnumerable<float> source)
        {
            return source.Select(d => Math.Sign(d));
        }

        /// <summary>
        /// Returns values indicating the sign of a sequence of 32-bit integers.
        /// </summary>
        /// <param name="source">A sequence of signed 32-bit integeres.</param>
        /// <returns>A sequence of number that indicates the sign of the values of source, as shown in the following table.Return
        /// value Meaning -1 value is less than zero. 0 value is equal to zero. 1 value
        /// is greater than zero.</returns>        
        public static MathEnumerable<int> Sign(this MathEnumerable<int> source)
        {
            return source.Select(d => Math.Sign(d));
        }

        /// <summary>
        /// Returns values indicating the sign of a sequence of 64-bit integers.
        /// </summary>
        /// <param name="source">A sequence of signed 64-bit integeres.</param>
        /// <returns>A sequence of number that indicates the sign of the values of source, as shown in the following table.Return
        /// value Meaning -1 value is less than zero. 0 value is equal to zero. 1 value
        /// is greater than zero.</returns>        
        public static MathEnumerable<int> Sign(this MathEnumerable<long> source)
        {
            return source.Select(d => Math.Sign(d));
        }

        /// <summary>
        /// Returns values indicating the sign of a sequence of 8-bit integers.
        /// </summary>
        /// <param name="source">A sequence of signed 8-bit integeres.</param>
        /// <returns>A sequence of number that indicates the sign of the values of source, as shown in the following table.Return
        /// value Meaning -1 value is less than zero. 0 value is equal to zero. 1 value
        /// is greater than zero.</returns>        
        public static MathEnumerable<int> Sign(this MathEnumerable<sbyte> source)
        {
            return source.Select(d => Math.Sign(d));
        }

        /// <summary>
        /// Returns values indicating the sign of a sequence of 16-bit integers.
        /// </summary>
        /// <param name="source">A sequence of signed 16-bit integeres.</param>
        /// <returns>A sequence of number that indicates the sign of the values of source, as shown in the following table.Return
        /// value Meaning -1 value is less than zero. 0 value is equal to zero. 1 value
        /// is greater than zero.</returns>        
        public static MathEnumerable<int> Sign(this MathEnumerable<short> source)
        {
            return source.Select(d => Math.Sign(d));
        }

        /// <summary>
        /// Returns the sine of the specified sequence of angles.
        /// </summary>
        /// <param name="source">A sequence of angles, measured in radians.</param>
        /// <returns>The sine of source. If source is equal to System.Double.NaN, System.Double.NegativeInfinity,
        /// or System.Double.PositiveInfinity, this method returns System.Double.NaN.</returns>
        public static MathEnumerable<double> Sin(this MathEnumerable<double> source)
        {
            return source.Select(d => Math.Sin(d));
        }

        /// <summary>
        /// Returns the hyperbolic sine of the specified sequence of angles.
        /// </summary>
        /// <param name="source">A sequence of angles, measured in radians.</param>
        /// <returns>The hyperbolic sine of source. If source is equal to System.Double.NegativeInfinity,
        /// System.Double.PositiveInfinity, or System.Double.NaN, this method returns
        /// a System.Double equal to value.</returns>
        public static MathEnumerable<double> Sinh(this MathEnumerable<double> source)
        {
            return source.Select(d => Math.Sinh(d));
        }

        /// <summary>
        /// Takes the square root of each element of a sequence of double-precision numbers.
        /// </summary>
        /// <param name="source">A sequence of double-precision numbers.</param>
        /// <returns>The square root of sequence of elements.</returns>
        public static MathEnumerable<double> Sqrt(this MathEnumerable<double> source)
        {
            return source.Select(d => Math.Sqrt(d));
        }

        /// <summary>
        /// Returns the tangent of the specified sequence of angles.
        /// </summary>
        /// <param name="source">A sequence of angles, measured in radians.</param>
        /// <returns>The tangent of source. If source is equal to System.Double.NaN, System.Double.NegativeInfinity,
        /// or System.Double.PositiveInfinity, this method returns System.Double.NaN.</returns>
        public static MathEnumerable<double> Tan(this MathEnumerable<double> source)
        {
            return source.Select(d => Math.Tan(d));
        }

        /// <summary>
        /// Returns the hyperbolic tangent of the sequence of specified angles.
        /// </summary>
        /// <param name="source">A sequence of angles, measured in radians.</param>
        /// <returns>The hyperbolic tangent of source. If source is equal to System.Double.NegativeInfinity,
        /// this method returns -1. If source is equal to System.Double.PositiveInfinity,
        /// this method returns 1. If source is equal to System.Double.NaN, this method
        /// returns System.Double.NaN.</returns>
        public static MathEnumerable<double> Tanh(this MathEnumerable<double> source)
        {
            return source.Select(d => Math.Tan(d));
        }

        /// <summary>
        /// Calculates the integral parts of a specified sequence of decimal numbers.
        /// </summary>
        /// <param name="source">A sequence of numbers to truncate.</param>
        /// <returns>The integral part of source; that is, the number that remains after any fractional
        /// digits have been discarded.</returns>
        public static MathEnumerable<decimal> Truncate(this MathEnumerable<decimal> source)
        {
            return source.Select(d => Math.Truncate(d));
        }

        /// <summary>
        /// Calculates the integral parts of a specified sequence of doubles.
        /// </summary>
        /// <param name="source">A sequence of numbers to truncate.</param>
        /// <returns>The integral part of source; that is, the number that remains after any fractional
        /// digits have been discarded.</returns>
        public static MathEnumerable<double> Truncate(this MathEnumerable<double> source)
        {
            return source.Select(d => Math.Truncate(d));
        }

        #endregion

        #region System.Double wrappers

        /// <summary>
        ///  Returns a value indicating whether the specified number evaluates to negative
        /// or positive infinity
        /// </summary>
        /// <param name="source">The sequence of elements.</param>
        /// <returns>true if d evaluates to System.Double.PositiveInfinity or System.Double.NegativeInfinity;
        /// otherwise, false.</returns>
        public static MathEnumerable<bool> IsInfinity(this MathEnumerable<double> source)
        {
            return source.Select(d => double.IsInfinity(d));
        }


        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to a value
        /// that is not a number (System.Double.NaN).
        /// </summary>
        /// <param name="source">The sequence of elements.</param>
        /// <returns>
        /// true if d evaluates to System.Double.NaN; otherwise, false.
        /// </returns>
        public static MathEnumerable<bool> IsNaN(this MathEnumerable<double> source)
        {
            return source.Select(d => double.IsNaN(d));
        }


        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to negative
        /// infinity.
        /// </summary>
        /// <param name="source">The sequence of elements.</param>
        /// <returns>
        /// true if d evaluates to System.Double.NegativeInfinity; otherwise, false.
        /// </returns>
        public static MathEnumerable<bool> IsNegativeInfinity(this MathEnumerable<double> source)
        {
            return source.Select(d => double.IsNegativeInfinity(d));
        }

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to positive
        /// infinity.
        /// </summary>
        /// <param name="source">The sequence of elements.</param>
        /// <returns>
        /// true if d evaluates to System.Double.PositiveInfinity; otherwise, false.
        /// </returns>
        public static MathEnumerable<bool> IsPositiveInfinity(this MathEnumerable<double> source)
        {
            return source.Select(d => double.IsPositiveInfinity(d));
        }

        #endregion

        #region Non-system math extension methods

        /// <summary>
        /// Raises each element of a sequence to the second power
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="source">A sequence of doubles to be raised to the second power</param>
        /// <returns>The sequence of elements raised to the power of 2</returns>
        public static MathEnumerable<T> Square<T>(this MathEnumerable<T> source)
        {
            return source * source;
        }


        /// <summary>
        /// Takes the arc tangent hyperbolicus of element of a sequence
        /// </summary>
        /// <param name="source">A sequence of doubles to be taken Atanh of</param>
        /// <returns>The sequence of elements taken Atanh of</returns>
        public static MathEnumerable<double> Atanh(this MathEnumerable<double> source)
        {
            return source.Select(d => d.Atanh());
        }


        /// <summary>
        /// Calculates the remainder of a sequence divided by y
        /// </summary>
        /// <param name="source">A sequence of doubles to be taken the remainder of</param>
        /// <param name="y">The denominator</param>
        /// <returns>The sequence of remainders</returns>
        public static MathEnumerable<double> Mod(this MathEnumerable<double> source, double y)
        {
            return source.Select(d => d.Mod(y));
        }

        #endregion

        #endregion

        #region Scalar wrappers

        #region System.Math wrappers

        /// <summary>
        /// Returns the absolute value of a System.Decimal number.
        /// </summary>
        /// <param name="value">
        /// A number in the range System.Decimal.MinValue≤ value ≤System.Decimal.MaxValue.
        /// </param>
        /// <returns>
        /// A System.Decimal, x, such that 0 ≤ x ≤System.Decimal.MaxValue.
        /// </returns>
        public static decimal Abs(this decimal value)
        {
            return Math.Abs(value);
        }

        /// <summary>
        /// Returns the absolute value of a double-precision floating-point number.
        /// </summary>
        /// <param name="value">
        /// A number in the range System.Double.MinValue≤value≤System.Double.MaxValue.
        /// </param>
        /// <returns>
        /// A double-precision floating-point number, x, such that 0 ≤ x ≤System.Double.MaxValue.
        /// </returns>
        public static double Abs(this double value)
        {
            return Math.Abs(value);
        }

        /// <summary>
        /// Returns the absolute value of a single-precision floating-point number.
        /// </summary>
        /// <param name="value">
        /// A number in the range System.Single.MinValue≤value≤System.Single.MaxValue.
        /// </param>
        /// <returns>
        /// A single-precision floating-point number, x, such that 0 ≤ x ≤System.Single.MaxValue.
        /// </returns>
        public static float Abs(this float value)
        {
            return Math.Abs(value);
        }

        /// <summary>
        /// Returns the absolute value of a 32-bit signed integer.
        /// </summary>
        /// <param name="value">
        /// A number in the range System.Int32.MinValue to value≤System.Int32.MaxValue.
        /// </param>
        /// <returns>
        /// A 32-bit signed integer, x, such that 0 ≤ x ≤System.Int32.MaxValue.
        /// </returns>
        /// <exception cref="System.OverflowException">
        /// value equals System.Int32.MinValue.
        /// </exception>
        public static int Abs(this int value)
        {
            return Math.Abs(value);
        }

        /// <summary>
        /// Returns the absolute value of a 64-bit signed integer.
        /// </summary>
        /// <param name="value">
        /// A number in the range System.Int64.MinValue to value≤System.Int64.MaxValue.
        /// </param>
        /// <returns>
        /// A 64-bit signed integer, x, such that 0 ≤ x ≤System.Int64.MaxValue.
        /// </returns>
        /// <exception cref="System.OverflowException">
        /// value equals System.Int64.MinValue.
        /// </exception>
        public static long Abs(this long value)
        {
            return Math.Abs(value);
        }

        /// <summary>
        /// Returns the absolute value of an 8-bit signed integer.
        /// </summary>
        /// <param name="value">
        /// A number in the range System.SByte.MinValue to value≤System.SByte.MaxValue.
        /// </param>
        /// <returns>
        /// An 8-bit signed integer, x, such that 0 ≤ x ≤System.SByte.MaxValue.
        /// </returns>
        /// <exception cref="System.OverflowException">
        /// value equals System.SByte.MinValue.
        /// </exception>
        public static sbyte Abs(this sbyte value)
        {
            return Math.Abs(value);
        }

        /// <summary>
        /// Returns the absolute value of a 16-bit signed integer.
        /// </summary>
        /// <param name="value">
        /// A number in the range System.Int16.MinValue to value≤System.Int16.MaxValue.
        /// </param>
        /// <returns>
        /// A 16-bit signed integer, x, such that 0 ≤ x ≤System.Int16.MaxValue.
        /// </returns>
        /// <exception cref="System.OverflowException">
        /// value equals System.Int16.MinValue.
        /// </exception>
        public static short Abs(this short value)
        {
            return Math.Abs(value);
        }

        /// <summary>
        /// Returns the angle whose cosine is the specified number.
        /// </summary>
        /// <param name="d">
        /// A number representing a cosine, where -1 ≤d≤ 1.
        /// </param>
        /// <returns>
        /// An angle, θ, measured in radians, such that 0 ≤θ≤π-or- System.Double.NaN
        /// if d less than -1 or d greater than 1.
        /// </returns>
        public static double Acos(this double d)
        {
            return Math.Acos(d);
        }

        /// <summary>
        /// Returns the angle whose sine is the specified number.
        /// </summary>
        /// <param name="d">
        /// A number representing a sine, where -1 ≤d≤ 1.
        /// </param>
        /// <returns>
        /// An angle, θ, measured in radians, such that -π/2 ≤θ≤π/2 -or- System.Double.NaN
        /// if d less than -1 or d greater than 1.
        /// </returns>
        public static double Asin(this double d)
        {
            return Math.Asin(d);
        }

        /// <summary>
        /// Returns the angle whose tangent is the specified number.
        /// </summary>
        /// <param name="d">
        /// A number representing a tangent.
        /// </param>
        /// <returns>
        /// An angle, θ, measured in radians, such that -π/2 ≤θ≤π/2.-or- System.Double.NaN
        /// if d equals System.Double.NaN, -π/2 rounded to double precision (-1.5707963267949)
        /// if d equals System.Double.NegativeInfinity, or π/2 rounded to double precision
        /// (1.5707963267949) if d equals System.Double.PositiveInfinity.
        /// </returns>
        public static double Atan(this double d)
        {
            return Math.Atan(d);
        }

        /// <summary>
        /// Returns the angle whose tangent is the quotient of two specified numbers.
        /// </summary>
        /// <param name="y">
        /// The y coordinate of a point.
        /// </param>
        /// <param name="x">
        /// The x coordinate of a point.
        /// </param>
        /// <returns>
        /// An angle, θ, measured in radians, such that -π≤θ≤π, and tan(θ) = y / x, where
        /// (x, y) is a point in the Cartesian plane. Observe the following: For (x,
        /// y) in quadrant 1, 0 less than θ &lt; π/2.For (x, y) in quadrant 2, π/2 &lt; θ≤π.For (x,
        /// y) in quadrant 3, -π &lt; θ &lt; -π/2.For (x, y) in quadrant 4, -π/2 &lt; θ &lt; 0.For
        /// points on the boundaries of the quadrants, the return value is the following:If
        /// y is 0 and x is not negative, θ = 0.If y is 0 and x is negative, θ = π.If
        /// y is positive and x is 0, θ = π/2.If y is negative and x is 0, θ = -π/2.
        /// </returns>
        public static double Atan2(this double y, double x)
        {
            return Math.Atan2(y, x);
        }

        /// <summary>
        /// Produces the full product of two 32-bit numbers.
        /// </summary>
        /// <param name="a">
        /// The first System.Int32 to multiply.
        /// </param>
        /// <param name="b">
        /// The second System.Int32 to multiply.
        /// </param>
        /// <returns>
        /// The System.Int64 containing the product of the specified numbers.
        /// </returns>
        public static long BigMul(this int a, int b)
        {
            return Math.BigMul(a, b);
        }

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the
        /// specified decimal number.
        /// </summary>
        /// <param name="d">
        /// A decimal number.
        /// </param>
        /// <returns>
        /// The smallest integral value that is greater than or equal to d. Note that
        /// this method returns a System.Decimal instead of an integral type.
        /// </returns>
        public static decimal Ceiling(this decimal d)
        {
            return Math.Ceiling(d);
        }

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the
        /// specified double-precision floating-point number.
        /// </summary>
        /// <param name="a">
        /// A double-precision floating-point number.
        /// </param>
        /// <returns>
        /// The smallest integral value that is greater than or equal to a. If a is equal
        /// to System.Double.NaN, System.Double.NegativeInfinity, or System.Double.PositiveInfinity,
        /// that value is returned. Note that this method returns a System.Double instead
        /// of an integral type.
        /// </returns>
        public static double Ceiling(this double a)
        {
            return Math.Ceiling(a);
        }

        /// <summary>
        /// Returns the cosine of the specified angle.
        /// </summary>
        /// <param name="d">
        /// An angle, measured in radians.
        /// </param>
        /// <returns>
        /// The cosine of d. If d is equal to System.Double.NaN, System.Double.NegativeInfinity,
        /// or System.Double.PositiveInfinity, this method returns System.Double.NaN.
        /// </returns>
        public static double Cos(this double d)
        {
            return Math.Cos(d);
        }

        /// <summary>
        /// Returns the hyperbolic cosine of the specified angle.
        /// </summary>
        /// <param name="value">
        /// An angle, measured in radians.
        /// </param>
        /// <returns>
        /// The hyperbolic cosine of value. If value is equal to System.Double.NegativeInfinity
        /// or System.Double.PositiveInfinity, System.Double.PositiveInfinity is returned.
        /// If value is equal to System.Double.NaN, System.Double.NaN is returned.
        /// </returns>
        public static double Cosh(this double value)
        {
            return Math.Cosh(value);
        }

        /// <summary>
        /// Calculates the quotient of two 32-bit signed integers and also returns the
        /// remainder in an output parameter.
        /// </summary>
        /// <param name="a">
        /// The dividend.
        /// </param>
        /// <param name="b">
        /// The divisor.
        /// </param>
        /// <param name="result">
        /// The remainder.
        /// </param>
        /// <returns>
        /// The quotient of the specified numbers.
        /// </returns>
        /// <exception cref="System.DivideByZeroException">
        /// b is zero.
        /// </exception>
        public static int DivRem(this int a, int b, out int result)
        {
            return Math.DivRem(a, b, out result);
        }

        /// <summary>
        /// Calculates the quotient of two 64-bit signed integers and also returns the
        /// remainder in an output parameter.
        /// </summary>
        /// <param name="a">
        /// The dividend.
        /// </param>
        /// <param name="b">
        /// The divisor.
        /// </param>
        /// <param name="result">
        /// The remainder.
        /// </param>
        /// <returns>
        /// The quotient of the specified numbers.
        /// </returns>
        /// <exception cref="System.DivideByZeroException">
        /// b is zero.
        /// </exception>
        public static long DivRem(this long a, long b, out long result)
        {
            return Math.DivRem(a, b, out result);
        }

        /// <summary>
        /// Returns e raised to the specified power.
        /// </summary>
        /// <param name="d">
        /// A number specifying a power.
        /// </param>
        /// <returns>
        /// The number e raised to the power d. If d equals System.Double.NaN or System.Double.PositiveInfinity,
        /// that value is returned. If d equals System.Double.NegativeInfinity, 0 is
        /// returned.
        /// </returns>
        public static double Exp(this double d)
        {
            return Math.Exp(d);
        }

        /// <summary>
        /// Returns the largest integer less than or equal to the specified decimal number.
        /// </summary>
        /// <param name="d">
        /// A decimal number.
        /// </param>
        /// <returns>
        /// The largest integer less than or equal to d.
        /// </returns>
        public static decimal Floor(this decimal d)
        {
            return Math.Floor(d);
        }

        /// <summary>
        /// Returns the largest integer less than or equal to the specified double-precision
        /// floating-point number.
        /// </summary>
        /// <param name="d">
        /// A double-precision floating-point number.
        /// </param>
        /// <returns>
        /// The largest integer less than or equal to d. If d is equal to System.Double.NaN,
        /// System.Double.NegativeInfinity, or System.Double.PositiveInfinity, that value
        /// is returned.
        /// </returns>
        public static double Floor(this double d)
        {
            return Math.Floor(d);
        }

        /// <summary>
        /// Returns the remainder resulting from the division of a specified number by
        /// another specified number.
        /// </summary>
        /// <param name="x">
        /// A dividend.
        /// </param>
        /// <param name="y">
        /// A divisor.
        /// </param>
        /// <returns>
        /// A number equal to x - (y Q), where Q is the quotient of x / y rounded to
        /// the nearest integer (if x / y falls halfway between two integers, the even
        /// integer is returned).If x - (y Q) is zero, the value +0 is returned if x
        /// is positive, or -0 if x is negative.If y = 0, System.Double.NaN is returned.
        /// </returns>
        public static double IEEERemainder(this double x, double y)
        {
            return Math.IEEERemainder(x, y);
        }

        /// <summary>
        /// Returns the natural (base e) logarithm of a specified number.
        /// </summary>
        /// <param name="d">
        /// A number whose logarithm is to be found.
        /// </param>
        /// <returns>
        /// One of the values in the following table. d parameterReturn value Positive
        /// The natural logarithm of d; that is, ln d, or log edZero System.Double.NegativeInfinityNegative
        /// System.Double.NaNEqual to System.Double.NaNSystem.Double.NaNEqual to 
        /// System.Double.PositiveInfinity
        /// </returns>
        public static double Log(this double d)
        {
            return Math.Log(d);
        }

        /// <summary>
        /// Returns the logarithm of a specified number in a specified base.
        /// </summary>
        /// <param name="a">
        /// A number whose logarithm is to be found.
        /// </param>
        /// <param name="newBase">
        /// The base of the logarithm.
        /// </param>
        /// <returns>
        /// One of the values in the following table. (+Infinity denotes System.Double.PositiveInfinity,
        /// -Infinity denotes System.Double.NegativeInfinity, and NaN denotes System.Double.NaN.)anewBaseReturn
        /// valuea> 0(0 &lt; newBase &lt; 1) -or-(newBase &gt; 1)lognewBase(a)a &lt; 0(any value)NaN(any
        /// value)newBase &lt; 0NaNa != 1newBase = 0NaNa != 1newBase = +InfinityNaNa = NaN(any
        /// value)NaN(any value)newBase = NaNNaN(any value)newBase = 1NaNa = 00 &lt; newBase &lt;
        /// 1 +Infinitya = 0newBase> 1-Infinitya = +Infinity0 &lt; newBase &lt; 1-Infinitya =
        /// +InfinitynewBase &gt; 1+Infinitya = 1newBase = 00a = 1newBase = +Infinity0
        /// </returns>
        public static double Log(this double a, double newBase)
        {
            return Math.Log(a, newBase);
        }

        /// <summary>
        /// Returns the base 10 logarithm of a specified number.
        /// </summary>
        /// <param name="d">
        /// A number whose logarithm is to be found.
        /// </param>
        /// <returns>
        /// One of the values in the following table. d parameter Return value Positive
        /// The base 10 log of d; that is, log 10d. Zero System.Double.NegativeInfinityNegative
        /// System.Double.NaNEqual to System.Double.NaNSystem.Double.NaNEqual to System.Double.PositiveInfinity
        /// </returns>
        public static double Log10(this double d)
        {
            return Math.Log10(d);
        }

        /// <summary>
        /// Returns the larger of two 8-bit unsigned integers.
        /// </summary>
        /// <param name="val1">
        /// The first of two 8-bit unsigned integers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two 8-bit unsigned integers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is larger.
        /// </returns>    
        public static byte Max(this byte val1, byte val2)
        {
            return Math.Max(val1, val2);
        }

        /// <summary>
        /// Returns the larger of two decimal numbers.
        /// </summary>
        /// <param name="val1">
        /// The first of two System.Decimal numbers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two System.Decimal numbers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is larger.
        /// </returns>
        public static decimal Max(this decimal val1, decimal val2)
        {
            return Math.Max(val1, val2);
        }

        /// <summary>
        /// Returns the larger of two double-precision floating-point numbers.
        /// </summary>
        /// <param name="val1">
        /// The first of two double-precision floating-point numbers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two double-precision floating-point numbers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is larger. If val1, val2, or both val1
        /// and val2 are equal to System.Double.NaN, System.Double.NaN is returned.
        /// </returns>
        public static double Max(this double val1, double val2)
        {
            return Math.Max(val1, val2);
        }

        /// <summary>
        /// Returns the larger of two single-precision floating-point numbers.
        /// </summary>
        /// <param name="val1">
        /// The first of two single-precision floating-point numbers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two single-precision floating-point numbers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is larger. If val1, or val2, or both val1
        /// and val2 are equal to System.Single.NaN, System.Single.NaN is returned.
        /// </returns>
        public static float Max(this float val1, float val2)
        {
            return Math.Max(val1, val2);
        }

        /// <summary>
        /// Returns the larger of two 32-bit signed integers.
        /// </summary>
        /// <param name="val1">
        /// The first of two 32-bit signed integers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two 32-bit signed integers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is larger.
        /// </returns>
        public static int Max(this int val1, int val2)
        {
            return Math.Max(val1, val2);
        }


        /// <summary>
        /// Returns the larger of two 64-bit signed integers.
        /// </summary>
        /// <param name="val1">
        /// The first of two 64-bit signed integers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two 64-bit signed integers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is larger.
        /// </returns>
        public static long Max(this long val1, long val2)
        {
            return Math.Max(val1, val2);
        }

        /// <summary>
        /// Returns the larger of two 8-bit signed integers.
        /// </summary>
        /// <param name="val1">
        /// The first of two 8-bit signed integers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two 8-bit signed integers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is larger.
        /// </returns>
        public static sbyte Max(this sbyte val1, sbyte val2)
        {
            return Math.Max(val1, val2);
        }

        /// <summary>
        /// Returns the larger of two 16-bit signed integers.
        /// </summary>
        /// <param name="val1">
        /// The first of two 16-bit signed integers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two 16-bit signed integers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is larger.
        /// </returns>
        public static short Max(this short val1, short val2)
        {
            return Math.Max(val1, val2);
        }

        /// <summary>
        /// Returns the larger of two 32-bit unsigned integers.
        /// </summary>
        /// <param name="val1">
        /// The first of two 32-bit unsigned integers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two 32-bit unsigned integers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is larger.
        /// </returns>
        public static uint Max(this uint val1, uint val2)
        {
            return Math.Max(val1, val2);
        }

        /// <summary>
        /// Returns the larger of two 64-bit unsigned integers.
        /// </summary>
        /// <param name="val1">
        /// The first of two 64-bit unsigned integers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two 64-bit unsigned integers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is larger.
        /// </returns>
        public static ulong Max(this  ulong val1, ulong val2)
        {
            return Math.Max(val1, val2);
        }

        /// <summary>
        /// Returns the larger of two 16-bit unsigned integers.
        /// </summary>
        /// <param name="val1">
        /// The first of two 16-bit unsigned integers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two 16-bit unsigned integers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is larger.
        /// </returns>
        public static ushort Max(this  ushort val1, ushort val2)
        {
            return Math.Max(val1, val2);
        }

        /// <summary>
        /// Returns the smaller of two 8-bit unsigned integers.
        /// </summary>
        /// <param name="val1">
        /// The first of two 8-bit unsigned integers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two 8-bit unsigned integers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is smaller.
        /// </returns>
        public static byte Min(this  byte val1, byte val2)
        {
            return Math.Min(val1, val2);
        }

        /// <summary>
        /// Returns the smaller of two decimal numbers.
        /// </summary>
        /// <param name="val1">
        /// The first of two System.Decimal numbers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two System.Decimal numbers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is smaller.
        /// </returns>
        public static decimal Min(this  decimal val1, decimal val2)
        {
            return Math.Min(val1, val2);
        }

        /// <summary>
        /// Returns the smaller of two double-precision floating-point numbers.
        /// </summary>
        /// <param name="val1">
        /// The first of two double-precision floating-point numbers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two double-precision floating-point numbers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is smaller. If val1, val2, or both val1
        /// and val2 are equal to System.Double.NaN, System.Double.NaN is returned.
        /// </returns>
        public static double Min(this  double val1, double val2)
        {
            return Math.Min(val1, val2);
        }

        /// <summary>
        /// Returns the smaller of two single-precision floating-point numbers.
        /// </summary>
        /// <param name="val1">
        /// The first of two single-precision floating-point numbers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two single-precision floating-point numbers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is smaller. If val1, val2, or both val1
        /// and val2 are equal to System.Single.NaN, System.Single.NaN is returned.
        /// </returns>
        public static float Min(this  float val1, float val2)
        {
            return Math.Min(val1, val2);
        }

        /// <summary>
        /// Returns the smaller of two 32-bit signed integers.
        /// </summary>
        /// <param name="val1">
        /// The first of two 32-bit signed integers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two 32-bit signed integers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is smaller.
        /// </returns>
        public static int Min(this  int val1, int val2)
        {
            return Math.Min(val1, val2);
        }

        /// <summary>
        /// Returns the smaller of two 64-bit signed integers.
        /// </summary>
        /// <param name="val1">
        /// The first of two 64-bit signed integers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two 64-bit signed integers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is smaller.
        /// </returns>
        public static long Min(this  long val1, long val2)
        {
            return Math.Min(val1, val2);
        }

        /// <summary>
        /// Returns the smaller of two 8-bit signed integers.
        /// </summary>
        /// <param name="val1">
        /// The first of two 8-bit signed integers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two 8-bit signed integers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is smaller.
        /// </returns>
        public static sbyte Min(this  sbyte val1, sbyte val2)
        {
            return Math.Min(val1, val2);
        }

        /// <summary>
        /// Returns the smaller of two 16-bit signed integers.
        /// </summary>
        /// <param name="val1">
        /// The first of two 16-bit signed integers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two 16-bit signed integers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is smaller.
        /// </returns>
        public static short Min(this  short val1, short val2)
        {
            return Math.Min(val1, val2);
        }

        /// <summary>
        /// Returns the smaller of two 32-bit unsigned integers.
        /// </summary>
        /// <param name="val1">
        /// The first of two 32-bit unsigned integers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two 32-bit unsigned integers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is smaller.
        /// </returns>
        public static uint Min(this  uint val1, uint val2)
        {
            return Math.Min(val1, val2);
        }

        /// <summary>
        /// Returns the smaller of two 64-bit unsigned integers.
        /// </summary>
        /// <param name="val1">
        /// The first of two 64-bit unsigned integers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two 64-bit unsigned integers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is smaller.
        /// </returns>
        public static ulong Min(this  ulong val1, ulong val2)
        {
            return Math.Min(val1, val2);
        }

        /// <summary>
        /// Returns the smaller of two 16-bit unsigned integers.
        /// </summary>
        /// <param name="val1">
        /// The first of two 16-bit unsigned integers to compare.
        /// </param>
        /// <param name="val2">
        /// The second of two 16-bit unsigned integers to compare.
        /// </param>
        /// <returns>
        /// Parameter val1 or val2, whichever is smaller.
        /// </returns>
        public static ushort Min(this  ushort val1, ushort val2)
        {
            return Math.Min(val1, val2);
        }

        /// <summary>
        /// Returns a specified number raised to the specified power.
        /// </summary>
        /// <param name="x">
        /// A double-precision floating-point number to be raised to a power.
        /// </param>
        /// <param name="y">
        /// A double-precision floating-point number that specifies a power.
        /// </param>
        /// <returns>
        /// The number x raised to the power y.
        /// </returns>
        public static double Pow(this double x, double y)
        {
            return Math.Pow(x, y);
        }


        /// <summary>
        /// Rounds a decimal value to the nearest integral value.
        /// </summary>
        /// <param name="d">
        /// A decimal number to be rounded.
        /// </param>
        /// <returns>
        /// The integer nearest parameter d. If the fractional component of d is halfway
        /// between two integers, one of which is even and the other odd, the even number
        /// is returned. Note that this method returns a System.Decimal instead of an
        /// integral type.
        /// </returns>
        /// <exception cref="System.OverflowException">
        /// The result is outside the range of a System.Decimal.
        /// </exception>
        public static decimal Round(this decimal d)
        {
            return Math.Round(d);
        }


        /// <summary>
        /// Rounds a double-precision floating-point value to the nearest integral value.
        /// </summary>
        /// <param name="a">
        /// A double-precision floating-point number to be rounded.
        /// </param>
        /// <returns>
        /// The integer nearest a. If the fractional component of a is halfway between
        /// two integers, one of which is even and the other odd, then the even number
        /// is returned. Note that this method returns a System.Double instead of an
        /// integral type.
        /// </returns>
        public static double Round(this double a)
        {
            return Math.Round(a);
        }

        /// <summary>
        /// Rounds a decimal value to a specified number of fractional digits.
        /// </summary>
        /// <param name="d">
        /// A decimal number to be rounded.
        /// </param>
        /// <param name="decimals">
        /// The number of decimal places in the return value.
        /// </param>
        /// <returns>
        /// The number nearest to d that contains a number of fractional digits equal
        /// to decimals.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// decimals is less than 0 or greater than 28.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The result is outside the range of a System.Decimal.
        /// </exception>
        public static decimal Round(this decimal d, int decimals)
        {
            return Math.Round(d, decimals);
        }

        /// <summary>
        /// Rounds a decimal value to the nearest integer. A parameter specifies how
        /// to round the value if it is midway between two other numbers.
        /// </summary>
        /// <param name="d">
        /// A decimal number to be rounded.
        /// </param>
        /// <param name="mode">
        /// Specification for how to round d if it is midway between two other numbers.
        /// </param>
        /// <returns>
        /// The integer nearest d. If d is halfway between two numbers, one of which
        /// is even and the other odd, then mode determines which of the two is returned.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// mode is not a valid value of System.MidpointRounding.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The result is outside the range of a System.Decimal.
        /// </exception>
        public static decimal Round(this  decimal d, MidpointRounding mode)
        {
            return Math.Round(d, mode);
        }

        /// <summary>
        /// Rounds a double-precision floating-point value to a specified number of fractional
        /// digits.
        /// </summary>
        /// <param name="value">
        /// A double-precision floating-point number to be rounded.
        /// </param>
        /// <param name="digits">
        /// The number of fractional digits in the return value.
        /// </param>
        /// <returns>
        /// The number nearest to value that contains a number of fractional digits equal
        /// to digits.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// digits is less than 0 or greater than 15.
        /// </exception>
        public static double Round(this  double value, int digits)
        {
            return Math.Round(value, digits);
        }

        /// <summary>
        /// Rounds a double-precision floating-point value to the nearest integer. A
        /// parameter specifies how to round the value if it is midway between two other
        /// numbers.
        /// </summary>
        /// <param name="value">
        /// A double-precision floating-point number to be rounded.
        /// </param>
        /// <param name="mode">
        /// Specification for how to round value if it is midway between two other numbers.
        /// </param>
        /// <returns>
        /// The integer nearest value. If value is halfway between two integers, one
        /// of which is even and the other odd, then mode determines which of the two
        /// is returned.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// mode is not a valid value of System.MidpointRounding.
        /// </exception>
        public static double Round(this  double value, MidpointRounding mode)
        {
            return Math.Round(value, mode);
        }

        /// <summary>
        /// Rounds a decimal value to a specified number of fractional digits. A parameter
        /// specifies how to round the value if it is midway between two other numbers.
        /// </summary>
        /// <param name="d">
        /// A decimal number to be rounded.
        /// </param>
        /// <param name="decimals">
        /// The number of decimal places in the return value.
        /// </param>
        /// <param name="mode">
        /// Specification for how to round d if it is midway between two other numbers.
        /// </param>
        /// <returns>
        /// The number nearest to d that contains a number of fractional digits equal
        /// to decimals. If the number of fractional digits in d is less than decimals,
        /// d is returned unchanged.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// decimals is less than 0 or greater than 28.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// mode is not a valid value of System.MidpointRounding.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// The result is outside the range of a System.Decimal.
        /// </exception>
        public static decimal Round(this  decimal d, int decimals, MidpointRounding mode)
        {
            return Math.Round(d, decimals, mode);
        }

        /// <summary>
        /// Rounds a double-precision floating-point value to the specified number of
        /// fractional digits. A parameter specifies how to round the value if it is
        /// midway between two other numbers.
        /// </summary>
        /// <param name="value">
        /// A double-precision floating-point number to be rounded.
        /// </param>
        /// <param name="digits">
        /// The number of fractional digits in the return value.
        /// </param>
        /// <param name="mode">
        /// Specification for how to round value if it is midway between two other numbers.
        /// </param>
        /// <returns>
        /// The number nearest to value that has a number of fractional digits equal
        /// to digits. If the number of fractional digits in value is less than digits,
        /// value is returned unchanged.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// digits is less than 0 or greater than 15.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// mode is not a valid value of System.MidpointRounding.
        /// </exception>
        public static double Round(this  double value, int digits, MidpointRounding mode)
        {
            return Math.Round(value, digits, mode);
        }

        /// <summary>
        /// Returns a value indicating the sign of a decimal number.
        /// </summary>
        /// <param name="value">
        /// A signed System.Decimal number.
        /// </param>
        /// <returns>
        /// A number that indicates the sign of value, as shown in the following table.Return
        /// value Meaning -1 value is less than zero. 0 value is equal to zero. 1 value
        /// is greater than zero.
        /// </returns>
        public static int Sign(this  decimal value)
        {
            return Math.Sign(value);
        }

        /// <summary>
        /// Returns a value indicating the sign of a double-precision floating-point
        /// number.
        /// </summary>
        /// <param name="value">
        /// A signed number.
        /// </param>
        /// <returns>
        /// A number that indicates the sign of value, as shown in the following table.Return
        /// value Meaning -1 value is less than zero. 0 value is equal to zero. 1 value
        /// is greater than zero.
        /// </returns>
        /// <exception cref="System.ArithmeticException">
        /// value is equal to System.Double.NaN.
        /// </exception>
        public static int Sign(this  double value)
        {
            return Math.Sign(value);
        }

        /// <summary>
        /// Returns a value indicating the sign of a single-precision floating-point
        /// number.
        /// </summary>
        /// <param name="value">
        /// A signed number.
        /// </param>
        /// <returns>
        /// A number that indicates the sign of value, as shown in the following table.Return
        /// value Meaning -1 value is less than zero. 0 value is equal to zero. 1 value
        /// is greater than zero.
        /// </returns>
        /// <exception cref="System.ArithmeticException">
        /// value is equal to System.Single.NaN.
        /// </exception>
        public static int Sign(this float value)
        {
            return Math.Sign(value);
        }

        /// <summary>
        /// Returns a value indicating the sign of a 32-bit signed integer.
        /// </summary>
        /// <param name="value">
        /// A signed number.
        /// </param>
        /// <returns>
        /// A number that indicates the sign of value, as shown in the following table.Return
        /// value Meaning -1 value is less than zero. 0 value is equal to zero. 1 value
        /// is greater than zero.
        /// </returns>
        public static int Sign(this  int value)
        {
            return Math.Sign(value);
        }

        /// <summary>
        /// Returns a value indicating the sign of a 64-bit signed integer.
        /// </summary>
        /// <param name="value">
        /// A signed number.
        /// </param>
        /// <returns>
        /// A number that indicates the sign of value, as shown in the following table.Return
        /// value Meaning -1 value is less than zero. 0 value is equal to zero. 1 value
        /// is greater than zero.
        /// </returns>
        public static int Sign(this  long value)
        {
            return Math.Sign(value);
        }

        /// <summary>
        /// Returns a value indicating the sign of an 8-bit signed integer.
        /// </summary>
        /// <param name="value">
        /// A signed number.
        /// </param>
        /// <returns>
        /// A number that indicates the sign of value, as shown in the following table.Return
        /// value Meaning -1 value is less than zero. 0 value is equal to zero. 1 value
        /// is greater than zero.
        /// </returns>
        public static int Sign(this  sbyte value)
        {
            return Math.Sign(value);
        }

        /// <summary>
        /// Returns a value indicating the sign of a 16-bit signed integer.
        /// </summary>
        /// <param name="value">
        /// A signed number.
        /// </param>
        /// <returns>
        /// A number that indicates the sign of value, as shown in the following table.Return
        /// value Meaning -1 value is less than zero. 0 value is equal to zero. 1 value
        /// is greater than zero.
        /// </returns>
        public static int Sign(this  short value)
        {
            return Math.Sign(value);
        }

        /// <summary>
        /// Returns the sine of the specified angle.
        /// </summary>
        /// <param name="a">
        /// An angle, measured in radians.
        /// </param>
        /// <returns>
        /// The sine of a. If a is equal to System.Double.NaN, System.Double.NegativeInfinity,
        /// or System.Double.PositiveInfinity, this method returns System.Double.NaN.
        /// </returns>
        public static double Sin(this  double a)
        {
            return Math.Sin(a);
        }

        /// <summary>
        /// Returns the hyperbolic sine of the specified angle.
        /// </summary>
        /// <param name="value">
        /// An angle, measured in radians.
        /// </param>
        /// <returns>
        /// The hyperbolic sine of value. If value is equal to System.Double.NegativeInfinity,
        /// System.Double.PositiveInfinity, or System.Double.NaN, this method returns
        /// a System.Double equal to value.
        /// </returns>
        public static double Sinh(this  double value)
        {
            return Math.Sinh(value);
        }

        /// <summary>
        /// Returns the square root of a specified number.
        /// </summary>
        /// <param name="d">
        /// A number.
        /// </param>
        /// <returns>
        /// One of the values in the following table. d parameter Return value Zero,
        /// or positive The positive square root of d. Negative System.Double.NaNEquals
        /// System.Double.NaNSystem.Double.NaNEquals System.Double.PositiveInfinitySystem.Double.PositiveInfinity
        /// </returns>
        public static double Sqrt(this  double d)
        {
            return Math.Sqrt(d);
        }

        /// <summary>
        /// Returns the tangent of the specified angle.
        /// </summary>
        /// <param name="a">
        /// An angle, measured in radians.
        /// </param>
        /// <returns>
        /// The tangent of a. If a is equal to System.Double.NaN, System.Double.NegativeInfinity,
        /// or System.Double.PositiveInfinity, this method returns System.Double.NaN.
        /// </returns>
        public static double Tan(this  double a)
        {
            return Math.Tan(a);
        }

        /// <summary>
        /// Returns the hyperbolic tangent of the specified angle.
        /// </summary>
        /// <param name="value">
        /// An angle, measured in radians.
        /// </param>
        /// <returns>
        /// The hyperbolic tangent of value. If value is equal to System.Double.NegativeInfinity,
        /// this method returns -1. If value is equal to System.Double.PositiveInfinity,
        /// this method returns 1. If value is equal to System.Double.NaN, this method
        /// returns System.Double.NaN.
        /// </returns>
        public static double Tanh(this  double value)
        {
            return Math.Tanh(value);
        }

        /// <summary>
        /// Calculates the integral part of a specified decimal number.
        /// </summary>
        /// <param name="d">
        /// A number to truncate.
        /// </param>
        /// <returns>
        /// The integral part of d; that is, the number that remains after any fractional
        /// digits have been discarded.
        /// </returns>
        public static decimal Truncate(this  decimal d)
        {
            return Math.Truncate(d);
        }

        /// <summary>
        /// Calculates the integral part of a specified double-precision floating-point
        /// number.
        /// </summary>
        /// <param name="d">
        /// A number to truncate.
        /// </param>
        /// <returns>
        /// The integral part of d; that is, the number that remains after any fractional
        /// digits have been discarded.
        /// </returns>
        public static double Truncate(this double d)
        {
            return Math.Truncate(d);
        }



        #endregion

        #region System.Double wrappers

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to negative
        /// or positive infinity
        /// </summary>
        /// <param name="d">
        /// A double-precision floating-point number.
        /// </param>
        /// <returns>
        /// true if d evaluates to System.Double.PositiveInfinity or System.Double.NegativeInfinity;
        /// otherwise, false.
        /// </returns>
        public static bool IsInfinity(this double d)
        {
            return double.IsInfinity(d);
        }

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to a value
        /// that is not a number (System.Double.NaN).
        /// </summary>
        /// <param name="d">
        /// A double-precision floating-point number.
        /// </param>
        /// <returns>
        /// true if d evaluates to System.Double.NaN; otherwise, false.
        /// </returns>
        public static bool IsNaN(this double d)
        {
            return double.IsNaN(d);
        }

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to negative
        /// infinity.
        /// </summary>
        /// <param name="d">
        /// A double-precision floating-point number.
        /// </param>
        /// <returns>
        /// true if d evaluates to System.Double.NegativeInfinity; otherwise, false.
        /// </returns>
        public static bool IsNegativeInfinity(this double d)
        {
            return double.IsNegativeInfinity(d);
        }

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to positive
        /// infinity.
        /// </summary>
        /// <param name="d">
        /// A double-precision floating-point number.
        /// </param>
        /// <returns>
        /// true if d evaluates to System.Double.PositiveInfinity; otherwise, false.
        /// </returns>
        public static bool IsPositiveInfinity(this double d)
        {
            return double.IsPositiveInfinity(d);
        }

        #endregion

        #region System.Int32 wrappers

        /// <summary>
        /// Converts an integer to a double.
        /// </summary>
        /// <param name="i">An integer.</param>
        /// <returns>A double.</returns>
        public static double ToDouble(this int i)
        {
            return (double)i;
        }

        #endregion

        #region Non-system based extension methods

        /// <summary>
        /// Returns atan hyperbolicus of the double x
        /// </summary>
        /// <param name="x">A double to be taken Atanh of.</param>
        /// <returns>The double taken Atanh of.</returns>
        public static double Atanh(this double x)
        {
            return ((1 + x).Log() - (1 - x).Log()) / 2;
        }

        /// <summary>
        /// Finds the remainder of division of one number by another
        /// </summary>
        /// <param name="d">A double to be taken the remainder of.</param>
        /// <param name="y">The number that is divided with.</param>
        /// <returns>The remainder.</returns>
        public static double Mod(this double d, double y)
        {
            return d - (d / y).Floor() * y;
        }

        #endregion

        #endregion
    }

}
