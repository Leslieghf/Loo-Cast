using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute
{
    using Stat;

    public class PerceptionAttribute : Attribute
    {
        public readonly AlertnessStat alertnessStat = new AlertnessStat();
        public readonly AwarenessStat awarenessStat = new AwarenessStat();
        public readonly CautiousnessStat cautiousnessStat = new CautiousnessStat();

        public override void Initialize()
        {
            base.Initialize();
            alertnessStat.Initialize(this);
            awarenessStat.Initialize(this);
            cautiousnessStat.Initialize(this);
            stats = new Stat.Stat[3];
            stats[0] = alertnessStat;
            stats[1] = awarenessStat;
            stats[2] = cautiousnessStat;
        }
    }
}
