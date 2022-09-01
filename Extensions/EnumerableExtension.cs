using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Extensions;

/// <summary>
///     Enumerable extension
/// </summary>
public static class EnumerableExtension
{
    /// <summary>
    ///     Convert Enumerable to ConcurrentDictionary
    /// </summary>
    /// <param name="source">source</param>
    /// <param name="keySelector">set key method</param>
    /// <param name="elementSelector">set value method</param>
    /// <typeparam name="TSource">source type</typeparam>
    /// <typeparam name="TKey">key type</typeparam>
    /// <typeparam name="TElement">value type</typeparam>
    /// <returns>ConcurrentDictionary</returns>
    /// <exception cref="Exception">argument checks</exception>
    public static ConcurrentDictionary<TKey, TElement> ToConcurrentDictionary<TSource, TKey, TElement>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TElement> elementSelector)
    {
        if (source == null)
            throw Error.ArgumentNull(nameof(source));
        if (keySelector == null)
            throw Error.ArgumentNull(nameof(keySelector));
        if (elementSelector == null)
            throw Error.ArgumentNull(nameof(elementSelector));
        var dictionary = new ConcurrentDictionary<TKey, TElement>();
        foreach (var source1 in source)
            dictionary.TryAdd(keySelector(source1), elementSelector(source1));
        return dictionary;
    }
}