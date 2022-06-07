using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute
{
    using Stat;

    public class DexterityAttribute : Attribute
    {
        public readonly AgilityStat agilityStat = new AgilityStat();
        public readonly ReflexesStat reflexesStat = new ReflexesStat();
        public readonly QuicknessStat quicknessStat = new QuicknessStat();

        public override void Initialize()
        {
            base.Initialize();
            agilityStat.Initialize(this);
            reflexesStat.Initialize(this);
            quicknessStat.Initialize(this);
            stats = new Stat.Stat[3];
            stats[0] = agilityStat;
            stats[1] = reflexesStat;
            stats[2] = quicknessStat;
        }
    } 
}
