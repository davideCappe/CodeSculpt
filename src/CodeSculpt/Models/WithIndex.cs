namespace CodeSculpt.Models;

public readonly struct WithIndex<TValue> where TValue : class
{
    public TValue? Value { get; }
    public int Index { get; }

    internal WithIndex(TValue? value, int index)
    {
        (Value, Index) = (value, index);
    }

    public void Deconstruct(out TValue? value, out int index)
        => (value, index) = (Value, Index);
}