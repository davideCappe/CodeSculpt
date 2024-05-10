using CodeSculpt.Models;

namespace CodeSculpt.Extensions;
/// <summary>
/// 
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var item in source)
        {
            action(item);
        }

        return source;
    }

    /// <summary>
    /// 
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="action"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<IEnumerable<T>> ForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> action, CancellationToken cancellationToken = default)
    {
        foreach (var item in source)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await action.Invoke(item).ConfigureAwait(false);
        }

        return source;
    }

    /// <summary>
    /// Creates an <see cref="IEnumerable{T}"/> of elements from an <see cref="IEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements.</typeparam>
    /// <param name="source">The <see cref="IEnumerable{T}"/> to create an <see cref="IEnumerable{T}"/> of elements from.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> of  elements that contains projected elements from the input sequence.</returns>
    public static IEnumerable<WithIndex<TSource>> WithIndex<TSource>(this IEnumerable<TSource> source) where TSource : class
        => source.Select((item, index) => new WithIndex<TSource>(item, index));

    /// <summary>
    /// Creates an elements from an <see cref="IQueryable{T}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements.</typeparam>
    /// <param name="source">The <see cref="IQueryable{T}"/> to create an <see cref="IEnumerable{T}"/> of elements from.</param>
    /// <returns>An elements that contains projected elements from the input sequence.</returns>
    public static IQueryable<WithIndex<TSource>> WithIndex<TSource>(this IQueryable<TSource> source) where TSource : class
        => source.Select((item, index) => new WithIndex<TSource>(item, index));

}
