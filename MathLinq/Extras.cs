using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLinq
{
    public static class Extras
    {

       // Repeat,Sum

        /// <summary>
        /// Generates a sequence that contains one repeated value.
        /// </summary>
        /// <param name="element">
        /// The value to be repeated.
        /// </param>
        /// <param name="count">
        /// The number of times to repeat the value in the generated sequence.
        /// </param>
        /// <typeparam name="TResult">
        /// The type of the value to be repeated in the result sequence.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains a repeated value.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// count is less than 0.
        /// </exception>
        public static MathEnumerable<MathEnumerable<TSource>> Repeat<TSource>(this MathEnumerable<TSource> source, int count)
        {
            return MathEnumerable.Repeat<MathEnumerable<TSource>>(source, count);
        }

        public static MathEnumerable<TSource> Sum<TSource>(this MathEnumerable<MathEnumerable<TSource>> source)
        {
            return source.Aggregate((running, next) => running + next);
        }


        #region All, Any

        /// <summary>
        /// Determines whether all elements in the sequence of bools are true.
        /// </summary>
        /// <param name="boolSource">A sequence of bool elements.</param>
        /// <returns>True íf all elements of the sequence are true, otherwise false.</returns>
        public static bool All(this MathEnumerable<bool> boolSource)
        {
            return boolSource.All(b => b);
        }

        /// <summary>
        ///  Determines whether a sequence of bools contains any elements with a value of true.
        /// </summary>
        /// <param name="boolSource">A sequence of bool elements.</param>
        /// <returns>True íf any element of the sequence is true, otherwise false.</returns>
        public static bool Any(this MathEnumerable<bool> boolSource)
        {
            return boolSource.Any(b => b);
        }

        #endregion

        #region Find variants

        /// <summary>
        /// Finds the index of all elements of a bool sequence corresponding to a true.
        /// </summary>
        /// <param name="boolSource">
        /// A sequence determining which indexes to return.
        /// </param>
        /// <returns>
        /// All elements of a sequence that correspond to a true of boolSource
        /// </returns>
        public static MathEnumerable<int> Find(this MathEnumerable<bool> boolSource)
        {
            return boolSource.Select((b, i) => new { b, i }).Where(a => a.b).Select(a => a.i).AsMathEnumerable();
        }

        /// <summary>
        /// Finds the index of the first true element of a sequence of bool values.
        /// </summary>
        /// <param name="boolSource">
        /// A sequence of bool values.
        /// </param>
        /// <returns>
        /// The index of first element with value true.
        /// </returns>
        public static int FindFirst(this MathEnumerable<bool> boolSource)
        {
            return boolSource.Select((b, i) => new { b, i }).Where(a => a.b).First().i;
        }

        /// <summary>
        /// Finds the index of the last true element of a sequence of bool values.
        /// </summary>
        /// <param name="boolSource">A sequence of bool values.</param>
        /// <returns>The index of last element with value true.</returns>
        public static int FindLast(this MathEnumerable<bool> boolSource)
        {
            return boolSource.Select((b, i) => new { b, i }).Where(a => a.b).Last().i;
        }


        /// <summary>
        /// Finds the index of all elements of a bool sequence corresponding to a true.
        /// </summary>
        /// <param name="boolSource">
        /// A sequence determining which indexes to return.
        /// </param>
        /// <returns>
        /// All elements of a sequence that correspond to a true of boolSource
        /// </returns>
        public static MathEnumerable<int> Find<TSource>(this MathEnumerable<TSource> source, TSource value)
        {
            return (source == value).Find();
        }



        #endregion

        #region IndexOf variants

        /// <summary>
        /// Finds the index of the first element equal to the maximum of the sequence of elements.
        /// </summary>
        /// <typeparam name="TSource">Type of the elements of source</typeparam>
        /// <param name="source">A sequence of elements</param>
        /// <returns>The index of the maximum in a sequence of elements</returns>
        public static int IndexOfMax<TSource>(this MathEnumerable<TSource> source)
        {
            return (source == source.Max()).FindFirst();
        }

        /// <summary>
        /// Finds the index of the first element equal to the minimum of the sequence of elements.
        /// </summary>
        /// <typeparam name="TSource">Type of the elements of source</typeparam>
        /// <param name="source">A sequence of elements</param>
        /// <returns>The index of the minimum in a sequence of elements</returns>
        public static int IndexOfMin<TSource>(this MathEnumerable<TSource> source)
        {
            return (source == source.Min()).FindFirst();
        }

        /// <summary>
        /// Find the index of the element that is nearest above the specified value
        /// </summary>
        /// <typeparam name="TSource">Type of the elements of source</typeparam>
        /// <param name="source">A sequency of elements</param>
        /// <param name="value">The value to which the elements of source is compared</param>
        /// <returns>The index of the element that is nearest above the given value</returns>
        public static int IndexOfNearestAbove<TSource>(this MathEnumerable<TSource> source, TSource value)
        {
            var indexAbove = (source > value).Find();
            int indexOfMin = source[indexAbove].IndexOfMin();
            return indexAbove[indexOfMin];
        }


        /// <summary>
        /// Find the index of the element that is nearest below the specified value
        /// </summary>
        /// <typeparam name="TSource">Type of the elements of source</typeparam>
        /// <param name="source">A sequence of elements</param>
        /// <param name="value">The value to which the elements of source is compared</param>
        /// <returns>The index of the element that is nearest above the given value</returns>
        public static int IndexOfNearestBelow<TSource>(this MathEnumerable<TSource> source, TSource value)
        {
            var indexBelow = (source < value).Find();
            int indexOfMax = source[indexBelow].IndexOfMax();
            return indexBelow[indexOfMax];
        }

        /// <summary>
        /// Find the index of the element that is nearest the specified value
        /// </summary>
        /// <typeparam name="TSource">Type of the elements of source</typeparam>
        /// <param name="source">A sequence of elements</param>
        /// <param name="value">The value to which the elements of source is compared</param>
        /// <returns>The index of the element that is nearest the given value</returns>
        public static int IndexOfNearest<TSource>(this MathEnumerable<TSource> source, TSource value)
        {
            var diff = source-value;
            var negdiff = value - source;
            var absdiff = (source > value).Zip(diff, (b, d) => new { b, d }).Zip(negdiff, (a, nd) => new { a, nd }).Select(aa => aa.a.b ? aa.a.d : aa.nd);
            return absdiff.IndexOfMin();
        }

        #endregion

        #region Nearest variants

        /// <summary>
        /// Find the element of a sequence that is nearest above the specified value
        /// </summary>
        /// <typeparam name="TSource">Type of the elements of source</typeparam>
        /// <param name="source">A sequence of elements</param>
        /// <param name="value">The value to which the elements of source is compared</param>
        /// <returns>The element that is nearest above the given value</returns>
        public static TSource NearestAbove<TSource>(this MathEnumerable<TSource> source, TSource value)
        {
            return source[source > value].Min();
        }

        /// <summary>
        /// Find the element of a sequence that is nearest below the specified value
        /// </summary>
        /// <typeparam name="TSource">Type of the elements of source</typeparam>
        /// <param name="source">A sequence of elements</param>
        /// <param name="value">The value to which the elements of source is compared</param>
        /// <returns>The element that is nearest above the given value</returns>
        public static TSource NearestBelow<TSource>(this MathEnumerable<TSource> source, TSource value)
        {
            return source[source < value].Max();
        }

        /// <summary>
        /// Find the element of a sequence that is nearest the specified value
        /// </summary>
        /// <typeparam name="TSource">Type of the elements of source</typeparam>
        /// <param name="source">A sequence of elements</param>
        /// <param name="value">The value to which the elements of source is compared</param>
        /// <returns>The element that is nearest the given value</returns>
        public static TSource Nearest<TSource>(this MathEnumerable<TSource> source, TSource value)
        {
            return source[source.IndexOfNearest(value)];
        }

        #endregion

    }
}
