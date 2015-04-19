using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MathLinq {

  /// <summary>
  /// A generic sequence of objects, that can be manipulated by standard arithmetic operators.
  /// </summary>
  /// <typeparam name="T">Type of element in sequence.</typeparam>
  public class MathEnumerable<T> : IEnumerable<T> {

    IEnumerable<T> enumerable;

    #region Constructors

    public MathEnumerable( ) {
      enumerable = System.Linq.Enumerable.Empty<T>( );
    }

    public MathEnumerable( IEnumerable<T> source ) {
      enumerable = source;
    }

    #endregion

    #region Operator overload

    #region * Unary operators *

    public static MathEnumerable<T> operator +(MathEnumerable<T> source)
    {
        return source;
    }

    public static MathEnumerable<T> operator -(MathEnumerable<T> source)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(source), Expression.Lambda<Func<T, T>>(Expression.Negate(parex1), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator !(MathEnumerable<T> source)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(source), Expression.Lambda<Func<T, T>>(Expression.Not(parex1), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator ~(MathEnumerable<T> source)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(source), Expression.Lambda<Func<T, T>>(Expression.OnesComplement(parex1), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();

    }

    public static MathEnumerable<T> operator ++(MathEnumerable<T> source)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(source), Expression.Lambda<Func<T, T>>(Expression.Increment(parex1), parex1));
        //return new MathEnumerable<T>(Expression.Lambda<Func<ParallelQuery<T>>>(enumexp).Compile().Invoke());
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();

    }

    public static MathEnumerable<T> operator --(MathEnumerable<T> source)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(source), Expression.Lambda<Func<T, T>>(Expression.Decrement(parex1), parex1));
        //return new MathEnumerable<T>(Expression.Lambda<Func<ParallelQuery<T>>>(enumexp).Compile().Invoke());
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();

    }

    // Overload true and false??


    #endregion

    #region * Binary operators *

    #region ADD

    public static MathEnumerable<T> operator +(MathEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Add(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator +(MathEnumerable<T> lop, IEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Add(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator +(IEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Add(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator +(MathEnumerable<T> lop, T rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.Add(parex1, Expression.Constant(rop)), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator +(T lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(rop), Expression.Lambda<Func<T, T>>(Expression.Add(Expression.Constant(lop), parex1), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    #endregion

    #region SUBTRACT

    public static MathEnumerable<T> operator -(MathEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Subtract(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator -(MathEnumerable<T> lop, IEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Subtract(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator -(IEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Subtract(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator -(MathEnumerable<T> lop, T rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.Subtract(parex1, Expression.Constant(rop)), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator -(T lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(rop), Expression.Lambda<Func<T, T>>(Expression.Subtract(Expression.Constant(lop), parex1), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    #endregion

    #region MULTIPLY

    public static MathEnumerable<T> operator *(MathEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Multiply(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator *(MathEnumerable<T> lop, IEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Multiply(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator *(IEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Multiply(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator *(MathEnumerable<T> lop, T rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.Multiply(parex1, Expression.Constant(rop)), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator *(T lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(rop), Expression.Lambda<Func<T, T>>(Expression.Multiply(Expression.Constant(lop), parex1), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    #endregion

    #region DIVIDE

    public static MathEnumerable<T> operator /(MathEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Divide(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator /(MathEnumerable<T> lop, IEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Divide(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator /(IEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Divide(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator /(MathEnumerable<T> lop, T rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.Divide(parex1, Expression.Constant(rop)), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator /(T lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(rop), Expression.Lambda<Func<T, T>>(Expression.Divide(Expression.Constant(lop), parex1), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    #endregion

    #region MODULUS

    public static MathEnumerable<T> operator %(MathEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Modulo(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator %(MathEnumerable<T> lop, IEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Modulo(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator %(IEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Modulo(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator %(MathEnumerable<T> lop, T rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.Modulo(parex1, Expression.Constant(rop)), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator %(T lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(rop), Expression.Lambda<Func<T, T>>(Expression.Modulo(Expression.Constant(lop), parex1), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    #endregion

    #region AND

    public static MathEnumerable<T> operator &(MathEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.And(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator &(MathEnumerable<T> lop, IEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.And(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator &(IEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.And(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator &(MathEnumerable<T> lop, T rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.And(parex1, Expression.Constant(rop)), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator &(T lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(rop), Expression.Lambda<Func<T, T>>(Expression.And(Expression.Constant(lop), parex1), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    #endregion

    #region OR

    public static MathEnumerable<T> operator |(MathEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Or(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator |(MathEnumerable<T> lop, IEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Or(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator |(IEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.Or(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator |(MathEnumerable<T> lop, T rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.Or(parex1, Expression.Constant(rop)), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator |(T lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(rop), Expression.Lambda<Func<T, T>>(Expression.Or(Expression.Constant(lop), parex1), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    #endregion

    #region XOR

    public static MathEnumerable<T> operator ^(MathEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.ExclusiveOr(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator ^(MathEnumerable<T> lop, IEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.ExclusiveOr(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator ^(IEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, T>>(Expression.ExclusiveOr(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator ^(MathEnumerable<T> lop, T rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.ExclusiveOr(parex1, Expression.Constant(rop)), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<T> operator ^(T lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(rop), Expression.Lambda<Func<T, T>>(Expression.ExclusiveOr(Expression.Constant(lop), parex1), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    #endregion

    #region GREATER THAN

    public static MathEnumerable<bool> operator >(MathEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.GreaterThan(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator >(MathEnumerable<T> lop, IEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.GreaterThan(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator >(IEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.GreaterThan(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator >(MathEnumerable<T> lop, T rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Lambda<Func<T, bool>>(Expression.GreaterThan(parex1, Expression.Constant(rop)), parex1));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator >(T lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(rop), Expression.Lambda<Func<T, bool>>(Expression.GreaterThan(Expression.Constant(lop), parex1), parex1));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    #endregion

    #region LESS THAN

    public static MathEnumerable<bool> operator <(MathEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.LessThan(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator <(MathEnumerable<T> lop, IEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.LessThan(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator <(IEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.LessThan(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator <(MathEnumerable<T> lop, T rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Lambda<Func<T, bool>>(Expression.LessThan(parex1, Expression.Constant(rop)), parex1));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator <(T lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(rop), Expression.Lambda<Func<T, bool>>(Expression.LessThan(Expression.Constant(lop), parex1), parex1));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    #endregion

    #region GREATER THAN OR EQUAL

    public static MathEnumerable<bool> operator >=(MathEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.GreaterThanOrEqual(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator >=(MathEnumerable<T> lop, IEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.GreaterThanOrEqual(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator >=(IEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.GreaterThanOrEqual(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator >=(MathEnumerable<T> lop, T rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Lambda<Func<T, bool>>(Expression.GreaterThanOrEqual(parex1, Expression.Constant(rop)), parex1));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator >=(T lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(rop), Expression.Lambda<Func<T, bool>>(Expression.GreaterThanOrEqual(Expression.Constant(lop), parex1), parex1));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    #endregion

    #region LESS THAN OR EQUAL

    public static MathEnumerable<bool> operator <=(MathEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.LessThanOrEqual(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator <=(MathEnumerable<T> lop, IEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.LessThanOrEqual(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator <=(IEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.LessThanOrEqual(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator <=(MathEnumerable<T> lop, T rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Lambda<Func<T, bool>>(Expression.LessThanOrEqual(parex1, Expression.Constant(rop)), parex1));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator <=(T lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(rop), Expression.Lambda<Func<T, bool>>(Expression.LessThanOrEqual(Expression.Constant(lop), parex1), parex1));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    #endregion

    #region EQUAL

    public static MathEnumerable<bool> operator ==(MathEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.Equal(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator ==(MathEnumerable<T> lop, IEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.Equal(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator ==(IEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.Equal(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator ==(MathEnumerable<T> lop, T rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Lambda<Func<T, bool>>(Expression.Equal(parex1, Expression.Constant(rop)), parex1));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator ==(T lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(rop), Expression.Lambda<Func<T, bool>>(Expression.Equal(Expression.Constant(lop), parex1), parex1));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    #endregion

    #region NOT EQUAL

    public static MathEnumerable<bool> operator !=(MathEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.NotEqual(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator !=(MathEnumerable<T> lop, IEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.NotEqual(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator !=(IEnumerable<T> lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        ParameterExpression parex2 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Zip", new[] { typeof(T), typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Constant(rop), Expression.Lambda<Func<T, T, bool>>(Expression.NotEqual(parex1, parex2), parex1, parex2));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator !=(MathEnumerable<T> lop, T rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(lop), Expression.Lambda<Func<T, bool>>(Expression.NotEqual(parex1, Expression.Constant(rop)), parex1));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    public static MathEnumerable<bool> operator !=(T lop, MathEnumerable<T> rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(bool) }, Expression.Constant(rop), Expression.Lambda<Func<T, bool>>(Expression.NotEqual(Expression.Constant(lop), parex1), parex1));
        return Expression.Lambda<Func<MathEnumerable<bool>>>(enumexp).Compile().Invoke();
    }

    #endregion

    #region LEFT SHIFT

    public static MathEnumerable<T> operator <<(MathEnumerable<T> lop, int rop)
    {
        ParameterExpression parex1 = Expression.Parameter(typeof(T));
        Expression enumexp = Expression.Call(typeof(MathEnumerable), "Select", new[] { typeof(T), typeof(T) }, Expression.Constant(lop), Expression.Lambda<Func<T, T>>(Expression.LeftShift(parex1, Expression.Constant(rop)), parex1));
        return Expression.Lambda<Func<MathEnumerable<T>>>(enumexp).Compile().Invoke();
    }

    #endregion

    #region RIGHT SHIFT

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

    public static implicit operator MathEnumerable<T>( T[ ] array ) {
      return new MathEnumerable<T>( array );
    }

    #endregion

    #region Indexers

    public T this[ int index ] {
      get {
        return this.ElementAt( index );
      }
    }

    public MathEnumerable<T> this[ MathEnumerable<bool> boolSource ] {
      get {
        return this.Zip( boolSource, ( s, b ) => new { s, b } ).Where( sb => sb.b ).Select( sb => sb.s );
      }
    }

    public MathEnumerable<T> this[ MathEnumerable<int> indexSource ] {
      get {
        return this.Select( ( s, i ) => new { s, i } ).Join( indexSource, outer => outer.i, inner => inner, ( outer, inner ) => outer.s );
      }
    }

    #endregion

    public override bool Equals( object obj ) {
      return Equals( obj as MathEnumerable<T> );
    }

    public bool Equals( MathEnumerable<T> other ) {
      // Check for null 
      if( ReferenceEquals( other, null ) )
        return false;

      // Check for same reference 
      return ReferenceEquals(this, other);

    }

    public override int GetHashCode( ) {
      int hash = 0;
      foreach( T t in enumerable ) {
        hash *= 17;
        if( t != null )
          hash = hash + t.GetHashCode( );
      }
      return hash;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="items"></param>
    public void Add( params T[ ] items ) {
      enumerable = enumerable.Concat( items );
    }

    public IEnumerator<T> GetEnumerator( ) {
      return enumerable.GetEnumerator( );
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator( ) {
      return GetEnumerator( );
    }

  }

}
