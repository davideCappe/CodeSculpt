﻿namespace CodeSculpt.Models;

/// <summary>
/// Represents a generic object with its relative index within a collection.
/// </summary>
/// <typeparam name="TValue">The type of the object.</typeparam>
/// <seealso cref="Extensions.CollectionExtensions.WithIndex{TSource}(IEnumerable{TSource})"/>
public readonly struct WithIndex<TValue> where TValue : class
{
    /// <summary>
    /// Gets the value of the object.
    /// </summary>
    public TValue? Value { get; }

    /// <summary>
    /// Gets the index of the object.
    /// </summary>
    public int Index { get; }

    internal WithIndex(TValue? value, int index)
    {
        (Value, Index) = (value, index);
    }

    /// <summary>
    /// Separates value and index of the instance.
    /// </summary>
    /// <param name="value">The value of the instance.</param>
    /// <param name="index">The index of the value of the instance.</param>
    public void Deconstruct(out TValue? value, out int index)
        => (value, index) = (Value, Index);
}