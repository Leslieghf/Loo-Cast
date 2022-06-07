using System;
using UnityEngine;

public sealed class Chance
{
    public Seed<IComparable> seed 
    { 
        get
        {
            return _seed;
        }

        private set
        {
            _seed = value;
        }
    }
    private Seed<IComparable> _seed;
    private AnimationCurve distribution;
    private System.Random random;

    public Chance(AnimationCurve distribution) : base()
    {
        seed = new Seed<int>(DateTime.Now.Millisecond);
        this.distribution = distribution;
        random = new System.Random((int)seed.seed);
    }

    public Chance(IComparable seed, AnimationCurve distribution) : base()
    {
        this.seed = new Seed<IComparable>(seed);
        this.distribution = distribution;
        if (seed is int || seed is float || seed is double)
        {
            random = new System.Random((int)seed);
        }
    }

    public float GetValue()
    {
        float value = (float)random.NextDouble();
        return distribution.Evaluate(value);
    }
}
