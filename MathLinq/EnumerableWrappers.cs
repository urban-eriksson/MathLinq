using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Security;
using System.Runtime;
using System.Runtime.ConstrainedExecution;
using System.Threading;


namespace MathLinq
{

    /// <summary>
    /// Class that is wrapping the existing Enumerable operations to yield MathEnumerable objects.
    /// </summary>
    public static class MathEnumerable
    {

        #region Wrapping Enumerable operations to yield a MathEnumerable object

        /// <summary>
        /// Concatenates two sequences.
        /// </summary>
        /// <param name="first">
        /// The first sequence to concatenate.
        /// </param>
        /// <param name="second">
        /// The sequence to concatenate to the first sequence.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of the input sequences.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains the concatenated elements of the two input sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> Concat<TSource>(this MathEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            return System.Linq.Enumerable.Concat(first, second).AsMathEnumerable();
        }

        /// <summary>
        /// Returns the elements of the specified sequence or the type parameter's
        /// default value in a singleton collection if the sequence is empty.
        /// </summary>
        /// <param name="source">
        /// The sequence to return a default value for if it is empty.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains default(TSource) if source is empty; otherwise,
        /// source.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> DefaultIfEmpty<TSource>(this MathEnumerable<TSource> source)
        {
            return System.Linq.Enumerable.DefaultIfEmpty(source).AsMathEnumerable();

        }

        /// <summary>
        /// Returns the elements of the specified sequence or the specified
        /// value in a singleton collection if the sequence is empty.
        /// </summary>
        /// <param name="source">
        /// The sequence to return the specified value for if it is empty.
        /// </param>
        /// <param name="defaultValue">
        /// The value to return if the sequence is empty.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains defaultValue if source is empty; otherwise, source.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> DefaultIfEmpty<TSource>(this MathEnumerable<TSource> source, TSource defaultValue)
        {
            return System.Linq.Enumerable.DefaultIfEmpty(source, defaultValue).AsMathEnumerable();
        }

        /// <summary>
        /// Returns distinct elements from a sequence by using the default equality
        /// comparer to compare values.
        /// </summary>
        /// <param name="source">
        /// The sequence to remove duplicate elements from.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains distinct elements from the source sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> Distinct<TSource>(this MathEnumerable<TSource> source)
        {
            return System.Linq.Enumerable.Distinct(source).AsMathEnumerable();
        }

        /// <summary>
        /// Returns distinct elements from a sequence by using a specified IEqualityComparer{T}
        /// to compare values.
        /// </summary>
        /// <param name="source">
        /// The sequence to remove duplicate elements from.
        /// </param>
        /// <param name="comparer">
        /// An IEqualityComparer{T} to compare values.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains distinct elements from the source sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> Distinct<TSource>(this MathEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            return System.Linq.Enumerable.Distinct(source, comparer).AsMathEnumerable();
        }

        /// <summary>
        /// Returns an empty MathEnumerable{TResult} that has the specified type argument.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type to assign to the type parameter of the returned generic sequence.
        /// </typeparam>
        /// <returns>
        /// An empty sequence whose type argument is .
        /// </returns>
        public static MathEnumerable<TResult> Empty<TResult>()
        {
            return System.Linq.Enumerable.Empty<TResult>().AsMathEnumerable();
        }

        /// <summary>
        /// Produces the set difference of two sequences by using the default
        /// equality comparer to compare values.
        /// </summary>
        /// <param name="first">
        /// A sequence whose elements that are not also in second will be returned.
        /// </param>
        /// <param name="second">
        /// A sequence whose elements that also occur in the first sequence will cause
        /// those elements to be removed from the returned sequence.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of the input sequences.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains the set difference of the elements of two sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> Except<TSource>(this MathEnumerable<TSource> first, MathEnumerable<TSource> second)
        {
            return System.Linq.Enumerable.Except(first, second).AsMathEnumerable();
        }

        /// <summary>
        /// Produces the set difference of two sequences by using the specified
        /// IEqualityComparer{T} to compare values.
        /// </summary>
        /// <param name="first">
        /// A sequence whose elements that are not also in second will be returned.
        /// </param>
        /// <param name="second">
        /// A sequence whose elements that also occur in the first sequence will cause
        /// those elements to be removed from the returned sequence.
        /// </param>
        /// <param name="comparer">
        /// An IEqualityComparer{T} to compare values.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of the input sequences.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains the set difference of the elements of two sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> Except<TSource>(this MathEnumerable<TSource> first, MathEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            return System.Linq.Enumerable.Except(first, second, comparer).AsMathEnumerable();
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key
        /// selector function.
        /// </summary>
        /// <param name="source">
        /// A MathEnumerable{TSource} that contains elements to sort.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from an element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// A MathEnumerable{TSource} whose elements are sorted descending according
        /// to a key.
        /// </returns>
        public static MathEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this MathEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return System.Linq.Enumerable.GroupBy(source, keySelector).AsMathEnumerable();
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key
        /// selector function and creates a result value from each group and its key.
        /// </summary>
        /// <param name="source">
        /// A sequence whose elements to group.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract the key for each element.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result value from each group.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the result value returned by resultSelector.
        /// </typeparam>
        /// <returns>
        /// A collection of elements of type where each element represents a projection
        /// over a group and its key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector or resultSelector is a null reference (Nothing in Visual
        /// Basic).
        /// </exception>
        public static MathEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this MathEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
        {
            return System.Linq.Enumerable.GroupBy(source, keySelector, resultSelector).AsMathEnumerable();
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key
        /// selector function and projects the elements for each group by using a specified
        /// function.
        /// </summary>
        /// <param name="source">
        /// An OrderedParallelQuery{TElement} that contains elements to sort.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from an element.
        /// </param>
        /// <param name="elementSelector">
        /// A function to map each source element to an element in an IGrouping.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <typeparam name="TElement">
        /// The type of the elements in the IGrouping
        /// </typeparam>
        /// <returns>
        /// A collection of elements of type TResult where each element represents a
        /// projection over a group and its key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector or elementSelector is a null reference (Nothing in
        /// Visual Basic).
        /// </exception>
        public static MathEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this MathEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            return System.Linq.Enumerable.GroupBy(source, keySelector, elementSelector).AsMathEnumerable();
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key
        /// selector function and compares the keys by using a specified comparer.
        /// </summary>
        /// <param name="source">
        /// A MathEnumerable{TSource} than contains elements to sort.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from an element.
        /// </param>
        /// <param name="comparer">
        /// An IComparer{TSource} to compare keys.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector>.
        /// </typeparam>
        /// <returns>
        /// A MathEnumerable{TSource} whose elements are sorted descending according
        /// to a key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is a null reference.
        /// </exception>
        public static MathEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this MathEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return System.Linq.Enumerable.GroupBy(source, keySelector, comparer).AsMathEnumerable();
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key
        /// selector function and creates a result value from each group and its key.
        /// The keys are compared by using a specified comparer.
        /// </summary>
        /// <param name="source">
        /// A sequence whose elements to group.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract the key for each element.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result value from each group.
        /// </param>
        /// <param name="comparer">
        /// An IEqualityComparer{TKey} to compare keys.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the result value returned by resultSelector.
        /// </typeparam>
        /// <returns>
        /// A collection of elements of type TResult where each element represents a
        /// projection over a group and its key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector or resultSelector is a null reference.
        /// </exception>
        public static MathEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this MathEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return System.Linq.Enumerable.GroupBy(source, keySelector, resultSelector, comparer).AsMathEnumerable();
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key
        /// selector function and creates a result value from each group and its key.
        /// The elements of each group are projected by using a specified function.
        /// </summary>
        /// <param name="source">
        /// A sequence whose elements to group.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract the key for each element.
        /// </param>
        /// <param name="elementSelector">
        /// A function to map each source element to an element in an IGrouping{TKey,
        /// TElement}.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result value from each group.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <typeparam name="TElement">
        /// The type of the elements in each IGrouping{TKey, TElement}.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the result value returned by resultSelector.
        /// </typeparam>
        /// <returns>
        /// A collection of elements of type where each element represents a projection
        /// over a group and its key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector or elementSelector or resultSelector is a null reference.
        /// </exception>
        public static MathEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this MathEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
        {
            return System.Linq.Enumerable.GroupBy(source, keySelector, elementSelector, resultSelector).AsMathEnumerable();
        }

        /// <summary>
        /// Groups the elements of a sequence according to a key selector
        /// function. The keys are compared by using a comparer and each group's elements
        /// are projected by using a specified function.
        /// </summary>
        /// <param name="source">
        /// A MathEnumerable{TSource}than contains elements to sort.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from an element.
        /// </param>
        /// <param name="elementSelector">
        /// A function to map each source element to an element in an IGrouping.
        /// </param>
        /// <param name="comparer">
        /// An IComparer{TSource} to compare keys.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <typeparam name="TElement">
        /// The type of the elements in the IGrouping
        /// </typeparam>
        /// <returns>
        /// An MathEnumerable{IGrouping{TKey, TElement}} where each System.Linq.IGrouping{TKey,TElement}
        /// object contains a collection of objects of type TElement and a key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector or elementSelector is a null reference (Nothing in
        /// Visual Basic).
        /// </exception>
        public static MathEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this MathEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            return System.Linq.Enumerable.GroupBy(source, keySelector, elementSelector, comparer).AsMathEnumerable();
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function
        /// and creates a result value from each group and its key. Key values are compared
        /// by using a specified comparer, and the elements of each group are projected
        /// by using a specified function.
        /// </summary>
        /// <param name="source">
        /// A sequence whose elements to group.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract the key for each element.
        /// </param>
        /// <param name="elementSelector">
        /// A function to map each source element to an element in an IGrouping{Key,
        /// TElement}.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result value from each group.
        /// </param>
        /// <param name="comparer">
        /// An IEqualityComparer{TKey} to compare keys.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <typeparam name="TElement">
        /// The type of the elements in each IGrouping{TKey, TElement}.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the result value returned by resultSelector.
        /// </typeparam>
        /// <returns>
        /// A collection of elements of type where each element represents a projection
        /// over a group and its key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector or elementSelector or resultSelector is a null reference.
        /// </exception>
        public static MathEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this MathEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return System.Linq.Enumerable.GroupBy(source, keySelector, elementSelector, resultSelector, comparer).AsMathEnumerable();
        }

        /// <summary>
        /// Correlates the elements of two sequences based on equality of
        /// keys and groups the results. The default equality comparer is used to compare
        /// keys.
        /// </summary>
        /// <param name="outer">
        /// The first sequence to join.
        /// </param>
        /// <param name="inner">
        /// The sequence to join to the first sequence.
        /// </param>
        /// <param name="outerKeySelector">
        /// A function to extract the join key from each element of the first sequence.
        /// </param>
        /// <param name="innerKeySelector">
        /// A function to extract the join key from each element of the second sequence.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result element from an element from the first sequence
        /// and a collection of matching elements from the second sequence.
        /// </param>
        /// <typeparam name="TOuter">
        /// The type of the elements of the first sequence.
        /// </typeparam>
        /// <typeparam name="TInner">
        /// The type of the elements of the second sequence.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the keys returned by the key selector functions.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the result elements.
        /// </typeparam>
        /// <returns>
        /// A sequence that has elements of type that are obtained by performing a grouped
        /// join on two sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// outer or inner or outerKeySelector or innerKeySelector or resultSelector
        /// is a null reference.
        /// </exception>
        public static MathEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this MathEnumerable<TOuter> outer, MathEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
        {
            return System.Linq.Enumerable.GroupJoin(outer, inner, outerKeySelector, innerKeySelector, resultSelector).AsMathEnumerable();
        }

        /// <summary>
        /// Correlates 
        /// the elements of two sequences based on key equality
        /// and groups the results. A specified IEqualityComparer{T} is used to compare
        /// keys.
        /// </summary>
        /// <param name="outer">
        /// The first sequence to join.
        /// </param>
        /// <param name="inner">
        /// The sequence to join to the first sequence.
        /// </param>
        /// <param name="outerKeySelector">
        /// A function to extract the join key from each element of the first sequence.
        /// </param>
        /// <param name="innerKeySelector">
        /// A function to extract the join key from each element of the second sequence.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result element from an element from the first sequence
        /// and a collection of matching elements from the second sequence.
        /// </param>
        /// <param name="comparer">
        /// An IEqualityComparer{T} to hash and compare keys.
        /// </param>
        /// <typeparam name="TOuter">
        /// The type of the elements of the first sequence.
        /// </typeparam>
        /// <typeparam name="TInner">
        /// The type of the elements of the second sequence.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the keys returned by the key selector functions.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the result elements.
        /// </typeparam>
        /// <returns>
        /// A sequence that has elements of type that are obtained by performing a grouped
        /// join on two sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// outer or inner or outerKeySelector or innerKeySelector or resultSelector
        /// is a null reference.
        /// </exception>
        public static MathEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this MathEnumerable<TOuter> outer, MathEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return System.Linq.Enumerable.GroupJoin(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer).AsMathEnumerable();
        }

        /// <summary>
        /// Produces the set intersection of two sequences by using the default
        /// equality comparer to compare values.
        /// </summary>
        /// <param name="first">
        /// A sequence whose distinct elements that also appear in second will be returned.
        /// </param>
        /// <param name="second">
        /// A sequence whose distinct elements that also appear in the first sequence
        /// will be returned.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of the input sequences.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains the elements that form the set intersection of two
        /// sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> Intersect<TSource>(this MathEnumerable<TSource> first, MathEnumerable<TSource> second)
        {
            return System.Linq.Enumerable.Intersect(first, second).AsMathEnumerable();
        }

        /// <summary>
        /// Produces the set intersection of two sequences by using the specified
        /// IEqualityComparer{T} to compare values.
        /// </summary>
        /// <param name="first">
        /// A sequence whose distinct elements that also appear in second will be returned.
        /// </param>
        /// <param name="second">
        /// A sequence whose distinct elements that also appear in the first sequence
        /// will be returned.
        /// </param>
        /// <param name="comparer">
        /// An IEqualityComparer {T} to compare values.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of the input sequences.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains the elements that form the set intersection of two
        /// sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> Intersect<TSource>(this MathEnumerable<TSource> first, MathEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            return System.Linq.Enumerable.Intersect(first, second, comparer).AsMathEnumerable();
        }

        /// <summary>
        /// Correlates in the elements of two sequences based on matching keys.
        /// The default equality comparer is used to compare keys.
        /// </summary>
        /// <param name="outer">
        /// The first sequence to join.
        /// </param>
        /// <param name="inner">
        /// The sequence to join to the first sequence.
        /// </param>
        /// <param name="outerKeySelector">
        /// A function to extract the join key from each element of the first sequence.
        /// </param>
        /// <param name="innerKeySelector">
        /// A function to extract the join key from each element of the second sequence.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result element from two matching elements.
        /// </param>
        /// <typeparam name="TOuter">
        /// The type of the elements of the first sequence.
        /// </typeparam>
        /// <typeparam name="TInner">
        /// The type of the elements of the second sequence.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the keys returned by the key selector functions.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the result elements.
        /// </typeparam>
        /// <returns>
        /// A sequence that has elements of type that are obtained by performing an inner
        /// join on two sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// outer or inner or outerKeySelector or innerKeySelector or resultSelector
        /// is a null reference.
        /// </exception>
        public static MathEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this MathEnumerable<TOuter> outer, MathEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
        {
            return System.Linq.Enumerable.Join(outer, inner, outerKeySelector, innerKeySelector, resultSelector).AsMathEnumerable();
        }

        /// <summary>
        /// Correlates in the elements of two sequences based on matching keys.
        /// A specified IEqualityComparer{T} is used to compare keys.
        /// </summary>
        /// <param name="outer">
        /// The first sequence to join.
        /// </param>
        /// <param name="inner">
        /// The sequence to join to the first sequence.
        /// </param>
        /// <param name="outerKeySelector">
        /// A function to extract the join key from each element of the first sequence.
        /// </param>
        /// <param name="innerKeySelector">
        /// A function to extract the join key from each element of the second sequence.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result element from two matching elements.
        /// </param>
        /// <param name="comparer">
        /// An IEqualityComparer {T} to hash and compare keys.
        /// </param>
        /// <typeparam name="TOuter">
        /// The type of the elements of the first sequence.
        /// </typeparam>
        /// <typeparam name="TInner">
        /// The type of the elements of the second sequence.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the keys returned by the key selector functions.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the result elements.
        /// </typeparam>
        /// <returns>
        /// A sequence that has elements of type that are obtained by performing an inner
        /// join on two sequences.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// outer or inner or outerKeySelector or innerKeySelector or resultSelector
        /// is a null reference.
        /// </exception>
        public static MathEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this MathEnumerable<TOuter> outer, MathEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return System.Linq.Enumerable.Join(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer).AsMathEnumerable();
        }


        // Of type TODO:

        /// <summary>
        /// Sorts the elements of a sequence in ascending order according
        /// to a key.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to order.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from an element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// A MathEnumerable{TSource} whose elements are sorted according to a
        /// key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> OrderBy<TSource, TKey>(this MathEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return System.Linq.Enumerable.OrderBy(source, keySelector).AsMathEnumerable();
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order by using
        /// a specified comparer.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to order.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from an element.
        /// </param>
        /// <param name="comparer">
        /// An IComparer{TKey} to compare keys.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// A MathEnumerable{TSource} whose elements are sorted according to a
        /// key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> OrderBy<TSource, TKey>(this MathEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            return System.Linq.Enumerable.OrderBy(source, keySelector, comparer).AsMathEnumerable();
        }

        /// <summary>
        /// Sorts the elements of a sequence in descending order according
        /// to a key.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to order.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from an element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// A MathEnumerable{TSource} whose elements are sorted descending according
        /// to a key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> OrderByDescending<TSource, TKey>(this MathEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return System.Linq.Enumerable.OrderByDescending(source, keySelector).AsMathEnumerable();
        }

        /// <summary>
        /// Sorts the elements of a sequence in descending order by using a specified
        /// comparer.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to order.
        /// </param>
        /// <param name="keySelector">
        /// A function to extract a key from an element.
        /// </param>
        /// <param name="comparer">
        /// An IComparer{TKey} to compare keys.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of elements of source.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type of the key returned by keySelector.
        /// </typeparam>
        /// <returns>
        /// A MathEnumerable{TSource} whose elements are sorted descending according
        /// to a key.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or keySelector is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> OrderByDescending<TSource, TKey>(this MathEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            return System.Linq.Enumerable.OrderByDescending(source, keySelector, comparer).AsMathEnumerable();
        }

        /// <summary>
        /// Generates a sequence of integral numbers within a specified range.
        /// </summary>
        /// <param name="start">
        /// The value of the first integer in the sequence.
        /// </param>
        /// <param name="count">
        /// The number of sequential integers to generate.
        /// </param>
        /// <returns>
        /// An IEnumerable{Int32} in C# or IEnumerable(Of Int32) in Visual Basic that
        /// contains a range of sequential integral numbers.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// count is less than 0 -or- start + count - 1 is larger than System.Int32.MaxValue().
        /// </exception>
        public static MathEnumerable<int> Range(int start, int count)
        {
            return System.Linq.Enumerable.Range(start, count).AsMathEnumerable();
        }

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
        public static MathEnumerable<TResult> Repeat<TResult>(TResult element, int count)
        {
            return System.Linq.Enumerable.Repeat(element, count).AsMathEnumerable();
        }

        /// <summary>
        /// Inverts the order of the elements in a sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to reverse.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// A sequence whose elements correspond to those of the input sequence in reverse
        /// order.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> Reverse<TSource>(this MathEnumerable<TSource> source)
        {
            return System.Linq.Enumerable.Reverse(source).AsMathEnumerable();
        }

        /// <summary>
        /// Projects each element of a sequence into a new form by incorporating
        /// the element's index.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to invoke a transform function on.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of elements resturned by selector.
        /// </typeparam>
        /// <returns>
        /// A sequence whose elements are the result of invoking the transform function
        /// on each element of source.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is a null reference.
        /// </exception>
        public static MathEnumerable<TResult> Select<TSource, TResult>(this MathEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            return System.Linq.Enumerable.Select(source, selector).AsMathEnumerable();
        }

        /// <summary>
        /// Projects each element of a sequence into a new form.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to invoke a transform function on.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of elements resturned by selector.
        /// </typeparam>
        /// <returns>
        /// A sequence whose elements are the result of invoking the transform function
        /// on each element of source.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is a null reference.
        /// </exception>
        public static MathEnumerable<TResult> Select<TSource, TResult>(this MathEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return System.Linq.Enumerable.Select(source, selector).AsMathEnumerable();
        }

        /// <summary>
        /// Projects each element of a sequence to an MathEnumerable{T} and
        /// flattens the resulting sequences into one sequence.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to project.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of elements of source.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the elements of the sequence returned by selector.
        /// </typeparam>
        /// <returns>
        /// A sequence whose elements are the result of invoking the one-to-many transform
        /// function on each element of the input sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is a null reference.
        /// </exception>
        public static MathEnumerable<TResult> SelectMany<TSource, TResult>(this MathEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            return System.Linq.Enumerable.SelectMany(source, selector).AsMathEnumerable();
        }

        /// <summary>
        /// Projects each element of a sequence to a MathEnumerable{T}, and
        /// flattens the resulting sequences into one sequence. The index of each source
        /// element is used in the projected form of that element.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to project.
        /// </param>
        /// <param name="selector">
        /// A transform function to apply to each element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of elements of source.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the elements of the sequence returned by selector.
        /// </typeparam>
        /// <returns>
        /// A sequence whose elements are the result of invoking the one-to-many transform
        /// function on each element of the input sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or selector is a null reference.
        /// </exception>
        public static MathEnumerable<TResult> SelectMany<TSource, TResult>(this MathEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector)
        {
            return System.Linq.Enumerable.SelectMany(source, selector).AsMathEnumerable();
        }

        /// <summary>
        /// Projects each element of a sequence to an MathEnumerable{T}, flattens the resulting
        /// sequences into one sequence, and invokes a result selector function on each
        /// element therein.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to project.
        /// </param>
        /// <param name="collectionSelector">
        /// A transform function to apply to each source element; the second parameter
        /// of the function represents the index of the source element.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result element from an element from the first sequence
        /// and a collection of matching elements from the second sequence.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of elements of source.
        /// </typeparam>
        /// <typeparam name="TCollection">
        /// The type of the intermediate elements collected by collectionSelector.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of elements in the result sequence.
        /// </typeparam>
        /// <returns>
        /// A sequence whose elements are the result of invoking the one-to-many transform
        /// function collectionSelector on each element of source and then mapping each
        /// of those sequence elements and their corresponding source element to a result
        /// element.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or collectionSelector or resultSelector is a null reference.
        /// </exception>
        public static MathEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this MathEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            return System.Linq.Enumerable.SelectMany(source, collectionSelector, resultSelector).AsMathEnumerable();
        }

        /// <summary>
        /// Projects each element of a sequence to a MathEnumerable{T}, flattens the resulting
        /// sequences into one sequence, and invokes a result selector function on each
        /// element therein. The index of each source element is used in the intermediate
        /// projected form of that element.
        /// </summary>
        /// <param name="source">
        /// A sequence of values to project.
        /// </param>
        /// <param name="collectionSelector">
        /// A transform function to apply to each source element; the second parameter
        /// of the function represents the index of the source element.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result element from an element from the first sequence
        /// and a collection of matching elements from the second sequence.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of elements of source.
        /// </typeparam>
        /// <typeparam name="TCollection">
        /// The type of the intermediate elements collected by collectionSelector.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of elements to return.
        /// </typeparam>
        /// <returns>
        /// A sequence whose elements are the result of invoking the one-to-many transform
        /// function collectionSelector on each element of source and then mapping each
        /// of those sequence elements and their corresponding source element to a result
        /// element.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or collectionSelector or resultSelector is a null reference.
        /// </exception>
        public static MathEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this MathEnumerable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            return System.Linq.Enumerable.SelectMany(source, collectionSelector, resultSelector).AsMathEnumerable();
        }

        /// <summary>
        /// Bypasses a specified number of elements in a sequence and then returns
        /// the remaining elements.
        /// </summary>
        /// <param name="source">
        /// The sequence to return elements from.
        /// </param>
        /// <param name="count">
        /// The number of elements to skip before returning the remaining elements.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of elements of source.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains the elements that occur after the specified index
        /// in the input sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> Skip<TSource>(this MathEnumerable<TSource> source, int count)
        {
            return System.Linq.Enumerable.Skip(source, count).AsMathEnumerable();
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition
        /// is true and then returns the remaining elements.
        /// </summary>
        /// <param name="source">
        /// The sequence to return elements from.
        /// </param>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of elements of source.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains the elements from the input sequence starting at
        /// the first element in the linear series that does not pass the test specified
        /// by predicate.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> SkipWhile<TSource>(this MathEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return System.Linq.Enumerable.SkipWhile(source, predicate).AsMathEnumerable();
        }

        /// <summary>
        /// Bypasses elements in a sequence as long as a specified condition
        /// is true and then returns the remaining elements. The element's index is used
        /// in the logic of the predicate function.
        /// </summary>
        /// <param name="source">
        /// The sequence to return elements from.
        /// </param>
        /// <param name="predicate">
        /// A function to test each source element for a condition; the second parameter
        /// of the function represents the index of the source element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of elements of source.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains the elements from the input sequence starting at
        /// the first element in the linear series that does not pass the test specified
        /// by predicate.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> SkipWhile<TSource>(this MathEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            return System.Linq.Enumerable.SkipWhile(source, predicate).AsMathEnumerable();
        }



        /// <summary>
        /// Returns a specified number of contiguous elements from the start of a
        /// sequence.
        /// </summary>
        /// <param name="source">
        /// The sequence to return elements from.
        /// </param>
        /// <param name="count">
        /// The number of elements to return.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of elements of source.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains the specified number of elements from the start
        /// of the input sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> Take<TSource>(this MathEnumerable<TSource> source, int count)
        {
            return System.Linq.Enumerable.Take(source, count).AsMathEnumerable();
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition
        /// is true.
        /// </summary>
        /// <param name="source">
        /// The sequence to return elements from.
        /// </param>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of elements of source.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains the elements from the input sequence that occur
        /// before the element at which the test no longer passes.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> TakeWhile<TSource>(this MathEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return System.Linq.Enumerable.TakeWhile(source, predicate).AsMathEnumerable();
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition
        /// is true. The element's index is used in the logic of the predicate function.
        /// </summary>
        /// <param name="source">
        /// The sequence to return elements from.
        /// </param>
        /// <param name="predicate">
        /// A function to test each source element for a condition; the second parameter
        /// of the function represents the index of the source element.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of elements of source.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains elements from the input sequence that occur before
        /// the element at which the test no longer passes.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> TakeWhile<TSource>(this MathEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            return System.Linq.Enumerable.TakeWhile(source, predicate).AsMathEnumerable();
        }

        /// <summary>
        /// Produces the set union of two sequences by using the default equality
        /// comparer.
        /// </summary>
        /// <param name="first">
        /// A sequence whose distinct elements form the first set for the union.
        /// </param>
        /// <param name="second">
        /// A sequence whose distinct elements form the second set for the union.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of the input sequences.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains the elements from both input sequences, excluding
        /// duplicates.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> Union<TSource>(this MathEnumerable<TSource> first, MathEnumerable<TSource> second)
        {
            return System.Linq.Enumerable.Union(first, second).AsMathEnumerable();
        }

        /// <summary>
        /// Produces the set union of two sequences by using a specified IEqualityComparer{T}.
        /// </summary>
        /// <param name="first">
        /// A sequence whose distinct elements form the first set for the union.
        /// </param>
        /// <param name="second">
        /// A sequence whose distinct elements form the second set for the union.
        /// </param>
        /// <param name="comparer">
        /// An IEqualityComparer {T} to compare values.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of the input sequences.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains the elements from both input sequences, excluding
        /// duplicates.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> Union<TSource>(this MathEnumerable<TSource> first, MathEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            return System.Linq.Enumerable.Union(first, second, comparer).AsMathEnumerable();
        }

        /// <summary>
        /// Filters in a sequence of values based on a predicate.
        /// </summary>
        /// <param name="source">
        /// A sequence to filter.
        /// </param>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains elements from the input sequence that satisfy the
        /// condition.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> Where<TSource>(this MathEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return System.Linq.Enumerable.Where(source, predicate).AsMathEnumerable();
        }

        /// <summary>
        /// Filters in a sequence of values based on a predicate. Each element's
        /// index is used in the logic of the predicate function.
        /// </summary>
        /// <param name="source">
        /// A sequence to filter.
        /// </param>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <typeparam name="TSource">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// A sequence that contains elements from the input sequence that satisfy the
        /// condition.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// source or predicate is a null reference.
        /// </exception>
        public static MathEnumerable<TSource> Where<TSource>(this MathEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            return System.Linq.Enumerable.Where(source, predicate).AsMathEnumerable();
        }

        /// <summary>
        /// Merges two sequences by using the specified predicate function.
        /// </summary>
        /// <param name="first">
        /// The first sequence to zip.
        /// </param>
        /// <param name="second">
        /// The second sequence to zip.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result element from two matching elements.
        /// </param>
        /// <typeparam name="TFirst">
        /// The type of the elements of the first sequence.
        /// </typeparam>
        /// <typeparam name="TSecond">
        /// The type of the elements of the second sequence.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the return elements.
        /// </typeparam>
        /// <returns>
        /// A sequence that has elements of type that are obtained by performing resultSelector
        /// pairwise on two sequences. If the sequence lengths are unequal, this truncates
        /// to the length of the shorter sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second or resultSelector is a null reference.
        /// </exception>
        public static MathEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this MathEnumerable<TFirst> first, MathEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            return System.Linq.Enumerable.Zip(first, second, resultSelector).AsMathEnumerable();
        }

        /// <summary>
        /// Merges two sequences by using the specified predicate function.
        /// </summary>
        /// <param name="first">
        /// The first sequence to zip.
        /// </param>
        /// <param name="second">
        /// The second sequence to zip.
        /// </param>
        /// <param name="resultSelector">
        /// A function to create a result element from two matching elements.
        /// </param>
        /// <typeparam name="TFirst">
        /// The type of the elements of the first sequence.
        /// </typeparam>
        /// <typeparam name="TSecond">
        /// The type of the elements of the second sequence.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the return elements.
        /// </typeparam>
        /// <returns>
        /// A sequence that has elements of type that are obtained by performing resultSelector
        /// pairwise on two sequences. If the sequence lengths are unequal, this truncates
        /// to the length of the shorter sequence.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// first or second or resultSelector is a null reference.
        /// </exception>
        public static MathEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this MathEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            return System.Linq.Enumerable.Zip(first, second, resultSelector).AsMathEnumerable();
        }


        #endregion


        /// <summary>
        /// Converts a generic System.Collections.Generic.IEnumerable{T} to a generic
        /// MathEnumerable{T}.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"> A sequence to convert.</param>
        /// <returns>A MathEnumerable{T} that represents the input sequence.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// source is a null reference.
        /// </exception>
        public static MathEnumerable<T> AsMathEnumerable<T>(this IEnumerable<T> source)
        {
            return new MathEnumerable<T>(source);
        }


        #region Factory functions

        #region Range

        /// <summary>
        /// Generates a sequence of integral numbers starting from 0.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the numbers in the sequence.
        /// </typeparam>
        /// <param name="count">
        /// Number of elements in the sequence.
        /// </param>
        /// <returns>
        /// A sequence of integeral numbers of type T.
        /// </returns>
        public static MathEnumerable<T> Range<T>(int count)
        {
            var p1 = Expression.Parameter(typeof(int));
            Func<int, T> caster = Expression.Lambda<Func<int, T>>(Expression.Convert(p1, typeof(T)), p1).Compile();
            return Enumerable.Select(Enumerable.Range(0, count), caster).AsMathEnumerable<T>();
        }

        /// <summary>
        /// Generates a sequence of numbers with integral steps starting from a specified number.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the numbers in the sequence.
        /// </typeparam>
        /// <param name="start">
        /// First number in sequence.
        /// </param>
        /// <param name="count">
        /// Number of elements in the sequence.
        /// </param>
        /// <returns>
        /// A sequence of numbers of type T with integral steps starting a specififed number.
        /// </returns>
        public static MathEnumerable<T> Range<T>(T start, int count)
        {
            var p1 = Expression.Parameter(typeof(int));
            Func<int, T> casteradder = Expression.Lambda<Func<int, T>>(Expression.Add(Expression.Constant(start), Expression.Convert(p1, typeof(T))), p1).Compile();
            return Enumerable.Select(Enumerable.Range(0, count), casteradder).AsMathEnumerable<T>();
        }

        /// <summary>
        /// Generates a sequence of numbers with an arbitrary step starting and ending at specified numbers.
        /// </summary>
        /// <typeparam name="T">The type of the numbers in the sequence.</typeparam>
        /// <param name="start">First number in sequence.</param>
        /// <param name="step">Step between consecutive numbers.</param>
        /// <param name="stop">Highest possible number in the sequence.</param>
        /// <returns>A sequence of numbers of type T with an arbitrary step starting and ending at specififed numbers.</returns>
        public static MathEnumerable<T> Range<T>(T start, T step, T stop)
        {
            int count = 1 + Expression.Lambda<Func<int>>(Expression.Convert(Expression.Divide(Expression.Subtract(Expression.Constant(stop), Expression.Constant(start)), Expression.Constant(step)), typeof(int))).Compile().Invoke();
            return start + step * Range<T>(count);
        }

        #endregion

        #region LinSpace

        /// <summary>
        /// Generates a sequence of numbers from one value to with a specified number of elements.
        /// </summary>
        /// <typeparam name="T">The type of the numbers in the sequence.</typeparam>
        /// <param name="start">First number in sequence.</param>
        /// <param name="stop">Last number in sequence.</param>
        /// <returns>A sequence of numbers of type T with integer steps starting and ending at specififed numbers.</returns>
        public static MathEnumerable<T> LinSpace<T>(T start, T stop)
        {
            int count = 1 + Expression.Lambda<Func<int>>(Expression.Convert(Expression.Subtract(Expression.Constant(stop), Expression.Constant(start)), typeof(int))).Compile().Invoke();
            return start + Range<T>(count);
        }

        /// <summary>
        /// Generates a sequence of numbers from one value to with a specified number of elements.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the numbers in the sequence.
        /// </typeparam>
        /// <param name="start">
        /// First number in sequence.
        /// </param>
        /// <param name="stop">
        /// Last number in sequence.
        /// </param>
        /// <param name="count">
        /// Number of elements in the sequence.
        /// </param>
        /// <returns>
        /// A sequence of numbers of type T with arbitrary steps starting and ending at specififed numbers.
        /// </returns>
        public static MathEnumerable<T> LinSpace<T>(T start, T stop, int count)
        {
            var p1 = Expression.Parameter(typeof(int));
            Func<int, T> startfun = Expression.Lambda<Func<int, T>>(Expression.Divide(Expression.Multiply(Expression.Convert(p1, typeof(T)), Expression.Constant(start)), Expression.Convert(Expression.Constant(count - 1), typeof(T))), p1).Compile();
            Func<int, T> stopfun = Expression.Lambda<Func<int, T>>(Expression.Divide(Expression.Multiply(Expression.Convert(p1, typeof(T)), Expression.Constant(stop)), Expression.Convert(Expression.Constant(count - 1), typeof(T))), p1).Compile();
            return Enumerable.Select(Enumerable.Range(0, count).Reverse(), startfun).AsMathEnumerable<T>() + Enumerable.Select(Enumerable.Range(0, count), stopfun).AsMathEnumerable<T>();
        }

        #endregion

        #region Random

        /// <summary>
        /// Creates a sequence of integral random numbers from 0 up to the maxvalue-1
        /// </summary>
        /// <param name="maxValue">Upper limit that is not a part of the sequence.</param>
        /// <param name="count">Number of elements in the sequence.</param>
        /// <returns>A sequence of int random numbers.</returns>
        public static MathEnumerable<int> Random(int maxValue, int count)
        {
            return new MathEnumerable<int>(RandomIntGenerator(maxValue, count));
        }

        // Helper function
        static IEnumerable<int> RandomIntGenerator(int maxValue, int count)
        {
            System.Random r = new System.Random();
            for (int i = 0; i < count; i++)
            {
                yield return r.Next(maxValue);
            }
        }

        /// <summary>
        /// Creates a sequence of double precision random numbers between 0 and 1
        /// </summary>
        /// <param name="count">Number of elements in the sequence.</param>
        /// <returns>A sequence of random numbers between 0 and 1</returns>
        public static MathEnumerable<double> Random(int count)
        {
            return new MathEnumerable<double>(RandomDoubleGenerator(count));
        }

        // Helper function
        static IEnumerable<double> RandomDoubleGenerator(int count)
        {
            System.Random r = new System.Random();
            for (int i = 0; i < count; i++)
            {
                yield return r.NextDouble();
            }
        }

        #endregion

        #region Ones, Zeros

        /// <summary>
        /// Generates a sequence of zeros with arbitrary type.
        /// </summary>
        /// <typeparam name="T">The type of the numbers in the sequence.</typeparam>
        /// <param name="count">Number of elements in the sequence.</param>
        /// <returns>A sequence of zeros of type T.</returns>
        public static MathEnumerable<T> Zeros<T>(int count)
        {
            var p1 = Expression.Parameter(typeof(int));
            Func<int, T> caster = Expression.Lambda<Func<int, T>>(Expression.Convert(p1, typeof(T)), p1).Compile();
            return MathEnumerable.Repeat(caster(0), count);
        }

        /// <summary>
        /// Generates a sequence of zeros.
        /// </summary>
        /// <param name="count">Number of elements in the sequence.</param>
        /// <returns>A sequence of zeros.</returns>
        public static MathEnumerable<double> Zeros(int count)
        {
            return MathEnumerable.Zeros<double>(count);
        }

        /// <summary>
        /// Generates a sequence of ones with arbitrary type.
        /// </summary>
        /// <typeparam name="T">The type of the numbers in the sequence.</typeparam>
        /// <param name="count">Number of elements in the sequence.</param>
        /// <returns>A sequence of ones of type T.</returns>
        public static MathEnumerable<T> Ones<T>(int count)
        {
            var p1 = Expression.Parameter(typeof(int));
            Func<int, T> caster = Expression.Lambda<Func<int, T>>(Expression.Convert(p1, typeof(T)), p1).Compile();
            return MathEnumerable.Repeat(caster(1), count);
        }

        /// <summary>
        /// Generates a sequence of ones.
        /// </summary>
        /// <param name="count">Number of elements in the sequence.</param>
        /// <returns>A sequence of ones.</returns>
        public static MathEnumerable<double> Ones(int count)
        {
            return MathEnumerable.Ones<double>(count);
        }

        #endregion

        /// <summary>
        /// Initializes sequnce to arbitrary number of objects.
        /// </summary>
        /// <typeparam name="T">Type of sequence.</typeparam>
        /// <param name="count">Number of elements.</param>
        /// <param name="instantiator">The constructor or similar for the objects.</param>
        /// <returns>A sequence of arbitrary objects.</returns>
        public static MathEnumerable<T> Initialize<T>(int count, Func<int,T> instantiator) 
        {
            return MathEnumerable.Range<int>(count).Select(i=>instantiator(i));
        }

        #endregion


    }

    ////public static class MathArrays
    ////{

    //    /// <summary>
    //    /// Replaces selected elements of a sequence by a constant value. 
    //    /// </summary>
    //    /// <typeparam name="TSource">
    //    /// The type of elements of source.
    //    /// </typeparam>
    //    /// <param name="source">
    //    /// A sequence whose elements to replace elements of.
    //    /// </param>
    //    /// <param name="boolSource">
    //    /// A sequence determining which elements to replace.
    //    /// </param>
    //    /// <param name="newElement">
    //    /// The value of the replaced elements.
    //    /// </param>
    //    /// <returns>
    //    /// A sequence of elements where some elements have been replaced by a constant value.
    //    /// </returns>
    //    //public static MathEnumerable<TSource> Replace<TSource>( this MathEnumerable<TSource> source, Func<TSource,bool> predicate, TSource newElement ) {
    //    //  //return source.Select( a => predicate(a) ? newElement : a ).AsMathEnumerable( );
    //    //  return source.AsSequential( ).Select( a => predicate( a ) ? newElement : a ).AsMathEnumerable( );
    //    //}
    //    //public static MathEnumerable<TSource> Replace<TSource>( this MathEnumerable<TSource> source, MathEnumerable<bool> boolSource, TSource newElement ) {
    //    //  return source.Zip( boolSource, ( s, b ) => new { s, b } ).Select( a => a.b ? newElement : a.s ).AsMathEnumerable( );
    //    //}
    //    //public static MathEnumerable<TSource> Replace<TSource>( this MathEnumerable<TSource> source, Func<TSource,bool> predicate, TSource newElement ) {
    //    //  //return source.Select( a => predicate(a) ? newElement : a ).AsMathEnumerable( );
    //    //  return source.Zip(MathEnumerable.Repeat(newElement), (a,b) => predicate( a ) ? b : a ).AsMathEnumerable( );
    //    //}



    //    //public static T Find<T>(this MathEnumerable<T> source, Func<T, T, bool> preferenceCondition)
    //    //{
    //    //    return source.Aggregate((agg, a) => preferenceCondition(agg, a) ? a : agg);
    //    //}

    //    //public static T Find<T, TSecond>(this MathEnumerable<T> source, MathEnumerable<TSecond> second, Func<TSecond, TSecond, bool> preferenceCondition)
    //    //{
    //    //    return source.Zip(second, (s1, s2) => new { s1, s2 }).Aggregate((agg, a) => preferenceCondition(agg.s2, a.s2) ? a : agg).s1;
    //    //}

    //    //public static T FindNearest<T>(this MathEnumerable<T> source, T value)
    //    //{
    //    //    ParameterExpression a = Expression.Parameter(typeof(T));
    //    //    ParameterExpression agg = Expression.Parameter(typeof(T));
    //    //    var v0 = Expression.Constant(value);

    //    //    var delta_a = Expression.Subtract(a, v0);
    //    //    var delta_agg = Expression.Subtract(agg, v0);

    //    //    var subcond1 = Expression.And(Expression.LessThan(delta_a, delta_agg), Expression.GreaterThan(delta_a, Expression.Negate(delta_agg)));
    //    //    var subcond2 = Expression.And(Expression.LessThan(delta_a, Expression.Negate(delta_agg)), Expression.GreaterThan(delta_a, delta_agg));
    //    //    var comboexp = Expression.Or(subcond1, subcond2);

    //    //    Func<T, T, bool> aggfun = Expression.Lambda<Func<T, T, bool>>(comboexp, agg, a).Compile();
    //    //    return source.Find(aggfun);
    //    //}

    //    //public static T FindNearest<T, TSecond>(this MathEnumerable<T> source, MathEnumerable<TSecond> second, T value)
    //    //{
    //    //    ParameterExpression a = Expression.Parameter(typeof(TSecond));
    //    //    ParameterExpression agg = Expression.Parameter(typeof(TSecond));
    //    //    var v0 = Expression.Constant(value);

    //    //    var delta_a = Expression.Subtract(a, v0);
    //    //    var delta_agg = Expression.Subtract(agg, v0);

    //    //    var subcond1 = Expression.And(Expression.LessThan(delta_a, delta_agg), Expression.GreaterThan(delta_a, Expression.Negate(delta_agg)));
    //    //    var subcond2 = Expression.And(Expression.LessThan(delta_a, Expression.Negate(delta_agg)), Expression.GreaterThan(delta_a, delta_agg));
    //    //    var comboexp = Expression.Or(subcond1, subcond2);

    //    //    Func<TSecond, TSecond, bool> aggfun = Expression.Lambda<Func<TSecond, TSecond, bool>>(comboexp, agg, a).Compile();
    //    //    return source.Find(second, aggfun);
    //    //}

    //    //public static T FindNearest2<T, TSecond>(this MathEnumerable<T> source, MathEnumerable<TSecond> second, T value)
    //    //{
    //    //    ParameterExpression a = Expression.Parameter(typeof(TSecond));
    //    //    ParameterExpression agg = Expression.Parameter(typeof(TSecond));
    //    //    var v0 = Expression.Constant(value);

    //    //    var delta_a = Expression.Subtract(a, v0);
    //    //    var delta_agg = Expression.Subtract(agg, v0);

    //    //    var subcond1 = Expression.And(Expression.LessThan(delta_a, delta_agg), Expression.GreaterThan(delta_a, Expression.Negate(delta_agg)));
    //    //    var subcond2 = Expression.And(Expression.LessThan(delta_a, Expression.Negate(delta_agg)), Expression.GreaterThan(delta_a, delta_agg));
    //    //    var comboexp = Expression.Or(subcond1, subcond2);

    //    //    Func<TSecond, TSecond, bool> aggfun = Expression.Lambda<Func<TSecond, TSecond, bool>>(comboexp, agg, a).Compile();
    //    //    return source.Find(second, aggfun);
    //    //}


    //    //public static T FindNearestAbove<T>(this MathEnumerable<T> source, T value)
    //    //{

    //    //    var v0 = Expression.Constant(value);
    //    //    ParameterExpression a = Expression.Parameter(typeof(T));

    //    //    Func<T, bool> predicate = Expression.Lambda<Func<T, bool>>(Expression.GreaterThanOrEqual(a, v0), a).Compile();
    //    //    MathEnumerable<T> candidates = source.Where(predicate);

    //    //    ParameterExpression agg = Expression.Parameter(typeof(T));

    //    //    var cond = Expression.And(Expression.LessThan(a, agg), Expression.GreaterThanOrEqual(a, v0));

    //    //    Func<T, T, bool> aggfun = Expression.Lambda<Func<T, T, bool>>(cond, agg, a).Compile();
    //    //    return candidates.Find(aggfun);
    //    //}

    //    //public static T FindNearestBelow<T>(this MathEnumerable<T> source, T value)
    //    //{

    //    //    var v0 = Expression.Constant(value);
    //    //    ParameterExpression a = Expression.Parameter(typeof(T));

    //    //    Func<T, bool> predicate = Expression.Lambda<Func<T, bool>>(Expression.LessThanOrEqual(a, v0), a).Compile();
    //    //    MathEnumerable<T> candidates = source.Where(predicate);

    //    //    ParameterExpression agg = Expression.Parameter(typeof(T));

    //    //    var cond = Expression.And(Expression.LessThanOrEqual(a, v0), Expression.GreaterThan(a, agg));

    //    //    Func<T, T, bool> aggfun = Expression.Lambda<Func<T, T, bool>>(cond, agg, a).Compile();
    //    //    return candidates.Find(aggfun);
    //    //}


    ////}


}
