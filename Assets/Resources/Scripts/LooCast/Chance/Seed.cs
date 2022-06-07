using System;

public struct Seed<T> where T : IComparable
{
    public IComparable seed { get; private set; }

    public Seed(IComparable seed = null)
    {
        this.seed = seed;
    }

    public static implicit operator Seed<T>(Seed<int> v)
    {
        return new Seed<T>(v.seed);
    }
}
