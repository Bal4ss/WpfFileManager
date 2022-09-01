using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Extensions;

public static class EnumerableExtension
{
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