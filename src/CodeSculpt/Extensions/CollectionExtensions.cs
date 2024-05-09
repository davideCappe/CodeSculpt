using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CodeSculpt.Extensions;
public static class CollectionExtensions
{
    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var item in source)
        {
            action(item);
        }

        return source;
    }
    public static async Task<IEnumerable<T>> ForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> action, CancellationToken cancellationToken = default)
    {
        foreach (var item in source)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await action.Invoke(item).ConfigureAwait(false);
        }

        return source;
    }
}
