using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute
{
    using Stat;

    public class StrengthAttribute : Attribute
    {
        public readonly BodyStat bodyStat = new BodyStat();
        public readonly MightStat mightStat = new MightStat();
        public readonly BrawnStat brawnStat = new BrawnStat();
        public readonly PowerStat powerStat = new PowerStat();

        public override void Initialize()
        {
            base.Initialize();
            bodyStat.Initialize(this);
            mightStat.Initialize(this);
            brawnStat.Initialize(this);
            powerStat.Initialize(this);
            stats = new Stat.Stat[4];
            stats[0] = bodyStat;
            stats[1] = mightStat;
            stats[2] = brawnStat;
            stats[3] = powerStat;
        }
    } 
}
