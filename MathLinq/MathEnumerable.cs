using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Diagnostics;

namespace MathLinq
{

    /// <summary>
    /// A generic sequence of objects, that can be manipulated by standard arithmetic operators.
    /// </summary>
    /// <typeparam name="T">Type of element in sequence.</typeparam>
    public class MathEnumerable<T> : IEnumerable<T>
    {

        IEnumerable<T> enumerable;

        #region Constructors

        /// <summary>
        /// Constructor for the empty MathEnumerable
        /// </summary>
        public MathEnumerable()
        {
            enumerable = System.Linq.Enumerable.Empty<T>();
        }

        /// <summary>
        /// Constructor for MathEnumerable{T}
        /// </summary>
        /// <param name="source">The source of elements</param>
        public MathEnumerable(IEnumerable<T> source)
        {
            enumerable = source;
        }

        #endregion

        #region Operator overload

        #region * Unary operators *

        /// <summary>
        /// Unary operator +, returns source unprocessed.
        /// </summary>
        /// <param name="source">The sequence of elements to process.</param>
        /// <returns>The input sequence of elements.</returns>
        public static MathEnumerable<T> operator +(MathEnumerable<T> source)
        {
            return source;
        }

        /// <summary>
        /// Unary operator -, reverses the sign of each element of source.
        /// </summary>
        /// <param name="source">The sequence of elements to process.</param>
        /// <returns>The negated sequence of elements.</returns>
        public static MathEnumerable<T> operator -(MathEnumerable<T> source)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(source), Expression.Lambda<Func<T, T>>(Expression.Negate(parex1), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Unary operator !, e.g. reverses the value of elements of source if a sequence of bool.
        /// </summary>
        /// <param name="source">The sequence of elements to process.</param>
        /// <returns>The logically negated sequence of elements</returns>
        public static MathEnumerable<T> operator !(MathEnumerable<T> source)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(source), Expression.Lambda<Func<T, T>>(Expression.Not(parex1), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// The bitwise complement operator.
        /// </summary>
        /// <param name="source">The sequence of elements to process.</param>
        /// <returns>The bitwise complemented sequence of elements.</returns>
        public static MathEnumerable<T> operator ~(MathEnumerable<T> source)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(source), Expression.Lambda<Func<T, T>>(Expression.OnesComplement(parex1), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();

        }

        /// <summary>
        /// Applies the increment operator on a sequence of elements.
        /// </summary>
        /// <param name="source">The sequence of elements to process.</param>
        /// <returns>The incremented sequence of elements.</returns>
        public static MathEnumerable<T> operator ++(MathEnumerable<T> source)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(source), Expression.Lambda<Func<T, T>>(Expression.Increment(parex1), parex1));
            //return new MathEnumerable<T>(Expression.Lambda<Func<ParallelQuery<T>>>(enumexp).Compile().Invoke());
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();

        }

        /// <summary>
        /// Applies the decrement operator on a sequence of elements.
        /// </summary>
        /// <param name="source">The sequence of elements to process.</param>
        /// <returns>The decremented sequence of elements</returns>
        public static MathEnumerable<T> operator --(MathEnumerable<T> source)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(source), Expression.Lambda<Func<T, T>>(Expression.Decrement(parex1), parex1));
            //return new MathEnumerable<T>(Expression.Lambda<Func<ParallelQuery<T>>>(enumexp).Compile().Invoke());
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();

        }

        #endregion

        #region * Binary operators *

        #region ADD

        /// <summary>
        /// Adds each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the sums.</returns>
        public static MathEnumerable<T> operator +(MathEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Add(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Adds each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the sums.</returns>
        public static MathEnumerable<T> operator +(MathEnumerable<T> lop, IEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Add(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Adds each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the sums.</returns>
        public static MathEnumerable<T> operator +(IEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Add(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Adds an element of type {T} to a sequence of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the sums.</returns>
        public static MathEnumerable<T> operator +(MathEnumerable<T> lop, T rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.Add(parex1, Expression.Constant(rop)), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Adds an element of type {T} to a sequence of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the sums.</returns>
        public static MathEnumerable<T> operator +(T lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(rop), Expression.Lambda<Func<T, T>>(Expression.Add(Expression.Constant(lop), parex1), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        #endregion

        #region SUBTRACT

        /// <summary>
        /// Subtracts each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the differences.</returns>
        public static MathEnumerable<T> operator -(MathEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Subtract(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Subtracts each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the differences.</returns>
        public static MathEnumerable<T> operator -(MathEnumerable<T> lop, IEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Subtract(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Subtracts each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the differences.</returns>
        public static MathEnumerable<T> operator -(IEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Subtract(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Subtracts an element of type {T} from a sequence of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the differences.</returns>
        public static MathEnumerable<T> operator -(MathEnumerable<T> lop, T rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.Subtract(parex1, Expression.Constant(rop)), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Subtracts a sequence of elements from an element of type {T}.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the differences.</returns>
        public static MathEnumerable<T> operator -(T lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(rop), Expression.Lambda<Func<T, T>>(Expression.Subtract(Expression.Constant(lop), parex1), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        #endregion

        #region MULTIPLY

        /// <summary>
        /// Multiplies each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the products.</returns>
        public static MathEnumerable<T> operator *(MathEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Multiply(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Multiplies each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the products.</returns>
        public static MathEnumerable<T> operator *(MathEnumerable<T> lop, IEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Multiply(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Multiplies each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the products.</returns>
        public static MathEnumerable<T> operator *(IEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Multiply(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Multiplies an element of type {T} with a sequence of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the products.</returns>
        public static MathEnumerable<T> operator *(MathEnumerable<T> lop, T rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.Multiply(parex1, Expression.Constant(rop)), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Multiplies an element of type {T} with a sequence of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the products.</returns>
        public static MathEnumerable<T> operator *(T lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(rop), Expression.Lambda<Func<T, T>>(Expression.Multiply(Expression.Constant(lop), parex1), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        #endregion

        #region DIVIDE

        /// <summary>
        /// Divides each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the ratios.</returns>
        public static MathEnumerable<T> operator /(MathEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Divide(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Divides each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the ratios.</returns>
        public static MathEnumerable<T> operator /(MathEnumerable<T> lop, IEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Divide(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Divides each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the ratios.</returns>
        public static MathEnumerable<T> operator /(IEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Divide(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Divides a sequence of elements with an element of type {T}.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the ratios.</returns>
        public static MathEnumerable<T> operator /(MathEnumerable<T> lop, T rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.Divide(parex1, Expression.Constant(rop)), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Divides an element of type {T} with a sequence of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the ratios.</returns>
        public static MathEnumerable<T> operator /(T lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(rop), Expression.Lambda<Func<T, T>>(Expression.Divide(Expression.Constant(lop), parex1), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        #endregion

        #region MODULUS

        /// <summary>
        /// Computes the remainder of each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the remainders.</returns>
        public static MathEnumerable<T> operator %(MathEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Modulo(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Computes the remainder of each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the remainders.</returns>
        public static MathEnumerable<T> operator %(MathEnumerable<T> lop, IEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Modulo(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Computes the remainder of each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the remainders.</returns>
        public static MathEnumerable<T> operator %(IEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Modulo(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Computes the remainder of a sequence of elements and an element of type {T}.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the remainders.</returns>
        public static MathEnumerable<T> operator %(MathEnumerable<T> lop, T rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.Modulo(parex1, Expression.Constant(rop)), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Computes the remainder of an element of type {T} and a sequence of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the remainders.</returns>
        public static MathEnumerable<T> operator %(T lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(rop), Expression.Lambda<Func<T, T>>(Expression.Modulo(Expression.Constant(lop), parex1), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        #endregion

        #region AND

        /// <summary>
        /// Computes the bitwise AND of each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the AND:s.</returns>
        public static MathEnumerable<T> operator &(MathEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.And(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Computes the bitwise AND of each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the AND:s.</returns>
        public static MathEnumerable<T> operator &(MathEnumerable<T> lop, IEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.And(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Computes the bitwise AND of each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the AND:s.</returns>
        public static MathEnumerable<T> operator &(IEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.And(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Computes the bitwise AND of a sequence of elements and an element of type {T}.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the AND:s.</returns>
        public static MathEnumerable<T> operator &(MathEnumerable<T> lop, T rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.And(parex1, Expression.Constant(rop)), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Computes the bitwise AND of an element of type {T} and a sequence of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the AND:s.</returns>
        public static MathEnumerable<T> operator &(T lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(rop), Expression.Lambda<Func<T, T>>(Expression.And(Expression.Constant(lop), parex1), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        #endregion

        #region OR

        /// <summary>
        /// Computes the bitwise OR of each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the OR:s.</returns>
        public static MathEnumerable<T> operator |(MathEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Or(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Computes the bitwise OR of each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the OR:s.</returns>
        public static MathEnumerable<T> operator |(MathEnumerable<T> lop, IEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Or(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Computes the bitwise OR of each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the OR:s.</returns>
        public static MathEnumerable<T> operator |(IEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Or(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Computes the bitwise OR of a sequence of elements and an element of type {T}.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the OR:s.</returns>
        public static MathEnumerable<T> operator |(MathEnumerable<T> lop, T rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.Or(parex1, Expression.Constant(rop)), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Computes the bitwise OR of an element of type {T} and a sequence of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the OR:s.</returns>
        public static MathEnumerable<T> operator |(T lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(rop), Expression.Lambda<Func<T, T>>(Expression.Or(Expression.Constant(lop), parex1), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        #endregion

        #region XOR

        /// <summary>
        /// Computes the bitwise XOR of each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the XOR:s.</returns>
        public static MathEnumerable<T> operator ^(MathEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.ExclusiveOr(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Computes the bitwise XOR of each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the XOR:s.</returns>
        public static MathEnumerable<T> operator ^(MathEnumerable<T> lop, IEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.ExclusiveOr(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Computes the bitwise XOR of each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the XOR:s.</returns>
        public static MathEnumerable<T> operator ^(IEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.ExclusiveOr(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Computes the bitwise XOR of a sequence of elements and an element of type {T}.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the XOR:s.</returns>
        public static MathEnumerable<T> operator ^(MathEnumerable<T> lop, T rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.ExclusiveOr(parex1, Expression.Constant(rop)), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Computes the bitwise XOR of an element of type {T} and a sequence of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of the XOR:s.</returns>
        public static MathEnumerable<T> operator ^(T lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(rop), Expression.Lambda<Func<T, T>>(Expression.ExclusiveOr(Expression.Constant(lop), parex1), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        #endregion

        #region GREATER THAN

        /// <summary>
        /// Evaluates greater than for each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator >(MathEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.GreaterThan(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates greater than for each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator >(MathEnumerable<T> lop, IEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.GreaterThan(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates greater than for each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator >(IEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.GreaterThan(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates greater than for a sequence of elements and an element of type {T}.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator >(MathEnumerable<T> lop, T rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Lambda<Func<T, bool>>(Expression.GreaterThan(parex1, Expression.Constant(rop)), parex1));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates greater than for an element of type {T} and a sequence of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator >(T lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(rop), Expression.Lambda<Func<T, bool>>(Expression.GreaterThan(Expression.Constant(lop), parex1), parex1));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        #endregion

        #region LESS THAN

        /// <summary>
        /// Evaluates less than for each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator <(MathEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.LessThan(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates less than for each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator <(MathEnumerable<T> lop, IEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.LessThan(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates less than for each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator <(IEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.LessThan(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates less than for a sequence of elements and an element of type {T}.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator <(MathEnumerable<T> lop, T rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Lambda<Func<T, bool>>(Expression.LessThan(parex1, Expression.Constant(rop)), parex1));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates less than for an element of type {T} and a sequence of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator <(T lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(rop), Expression.Lambda<Func<T, bool>>(Expression.LessThan(Expression.Constant(lop), parex1), parex1));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        #endregion

        #region GREATER THAN OR EQUAL

        /// <summary>
        /// Evaluates greater than or equal for each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator >=(MathEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.GreaterThanOrEqual(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates greater than or equal for each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator >=(MathEnumerable<T> lop, IEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.GreaterThanOrEqual(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates greater than or equal for each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator >=(IEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.GreaterThanOrEqual(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates greater than or equal for a sequence of elements and an element of type {T}.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator >=(MathEnumerable<T> lop, T rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Lambda<Func<T, bool>>(Expression.GreaterThanOrEqual(parex1, Expression.Constant(rop)), parex1));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates greater than or equal for an element of type {T} and a sequence of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator >=(T lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(rop), Expression.Lambda<Func<T, bool>>(Expression.GreaterThanOrEqual(Expression.Constant(lop), parex1), parex1));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        #endregion

        #region LESS THAN OR EQUAL

        /// <summary>
        /// Evaluates less than or equal for each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator <=(MathEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.LessThanOrEqual(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates less than or equal for each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator <=(MathEnumerable<T> lop, IEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.LessThanOrEqual(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates less than or equal for each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator <=(IEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.LessThanOrEqual(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates less than or equal for a sequence of elements and an element of type {T}.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator <=(MathEnumerable<T> lop, T rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Lambda<Func<T, bool>>(Expression.LessThanOrEqual(parex1, Expression.Constant(rop)), parex1));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates less than or equal for an element of type {T} and a sequence of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator <=(T lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(rop), Expression.Lambda<Func<T, bool>>(Expression.LessThanOrEqual(Expression.Constant(lop), parex1), parex1));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        #endregion

        #region EQUAL

        /// <summary>
        /// Evaluates equality for each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator ==(MathEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.Equal(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates equality for each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator ==(MathEnumerable<T> lop, IEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.Equal(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates equality for each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator ==(IEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.Equal(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates equality for a sequence of elements and an element of type {T}.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator ==(MathEnumerable<T> lop, T rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Lambda<Func<T, bool>>(Expression.Equal(parex1, Expression.Constant(rop)), parex1));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates equality than or equal for an element of type {T} and a sequence of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator ==(T lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(rop), Expression.Lambda<Func<T, bool>>(Expression.Equal(Expression.Constant(lop), parex1), parex1));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        #endregion

        #region NOT EQUAL

        /// <summary>
        /// Evaluates inequality for each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator !=(MathEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.NotEqual(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates inequality for each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator !=(MathEnumerable<T> lop, IEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.NotEqual(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates inequality for each pair of operands of two sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator !=(IEnumerable<T> lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            ParameterExpression parex2 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.NotEqual(parex1, parex2), parex1, parex2));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates inequality for a sequence of elements and an element of type {T}.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator !=(MathEnumerable<T> lop, T rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Lambda<Func<T, bool>>(Expression.NotEqual(parex1, Expression.Constant(rop)), parex1));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        /// <summary>
        /// Evaluates inequality than or equal for an element of type {T} and a sequence of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The sequence of resulting bools.</returns>
        public static MathEnumerable<bool> operator !=(T lop, MathEnumerable<T> rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(rop), Expression.Lambda<Func<T, bool>>(Expression.NotEqual(Expression.Constant(lop), parex1), parex1));
            return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
        }

        #endregion

        #region LEFT SHIFT

        /// <summary>
        /// Evaluates left shift for a sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The left shifted sequence.</returns>
        public static MathEnumerable<T> operator <<(MathEnumerable<T> lop, int rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.LeftShift(parex1, Expression.Constant(rop)), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        #endregion

        #region RIGHT SHIFT

        /// <summary>
        /// Evaluates right shift for a sequences of elements.
        /// </summary>
        /// <param name="lop">The left hand side.</param>
        /// <param name="rop">The right hand side.</param>
        /// <returns>The right shifted sequence.</returns>
        public static MathEnumerable<T> operator >>(MathEnumerable<T> lop, int rop)
        {
            ParameterExpression parex1 = Expression.Parameter(typeof(T));
            Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.RightShift(parex1, Expression.Constant(rop)), parex1));
            return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
        }

        #endregion

        #endregion

        #endregion

        #region Type casting

        /// <summary>
        /// Casts an array to a MathEnumerable
        /// </summary>
        /// <param name="array">Array to be casted</param>
        /// <returns>MathEnumerable {T}</returns>
        public static implicit operator MathEnumerable<T>(T[] array)
        {
            return new MathEnumerable<T>(array);
        }

        #endregion

        #region Indexers

        /// <summary>
        /// Indexes and element in the MathEnumerable.
        /// </summary>
        /// <param name="index">Integer index.</param>
        /// <returns>An element from the sequence of elements.</returns>
        public T this[int index]
        {
            get
            {
                return this.ElementAt(index);
            }
        }

        /// <summary>
        /// Selects elements based on the boolean source of elements.
        /// </summary>
        /// <param name="boolSource">A sequence of booleans.</param>
        /// <returns>A sub selection of elements.</returns>
        public MathEnumerable<T> this[MathEnumerable<bool> boolSource]
        {
            get
            {
                return this.Zip(boolSource, (s, b) => new { s, b }).Where(sb => sb.b).Select(sb => sb.s);
            }
        }


        /// <summary>
        ///  Selects elements based on a sequence of integer indexes.
        /// </summary>
        /// <param name="indexSource">A sequence of integers.</param>
        /// <returns>A sub selection of elements.</returns>
        public MathEnumerable<T> this[MathEnumerable<int> indexSource]
        {
            get
            {
                return this.Select((s, i) => new { s, i }).Join(indexSource, outer => outer.i, inner => inner, (outer, inner) => outer.s);
            }
        }

        #endregion

        /// <summary>
        /// Check if an object is equal to this.
        /// </summary>
        /// <param name="obj">Other object.</param>
        /// <returns>True if objects are (reference) equal.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as MathEnumerable<T>);
        }

        /// <summary>
        /// Check if an object is equal to another MathEnumerable
        /// </summary>
        /// <param name="other">Another MathEnumerable.</param>
        /// <returns>True if objects are (reference) equal.</returns>
        public bool Equals(MathEnumerable<T> other)
        {
            // Check for null 
            if (ReferenceEquals(other, null))
                return false;

            // Check for same reference 
            return ReferenceEquals(this, other);

        }

        /// <summary>
        /// Calculates the hash code.
        /// </summary>
        /// <returns>An integer hash code.</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            foreach (T t in enumerable)
            {
                hash *= 17;
                if (t != null)
                    hash = hash + t.GetHashCode();
            }
            return hash;
        }

        /// <summary>
        /// Adds an element to a sequence.
        /// </summary>
        /// <param name="items">Item to add.</param>
        public void Add(params T[] items)
        {
            enumerable = enumerable.Concat(items);
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return enumerable.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

}
