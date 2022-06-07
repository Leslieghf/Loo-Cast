using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Attribute;

namespace LooCast.Attribute
{
    using Stat;

    public class IntelligenceAttribute : Attribute
    {
        public readonly IntellectStat intellectStat = new IntellectStat();
        public readonly MindStat mindStat = new MindStat();
        public readonly KnowledgeStat knowledgeStat = new KnowledgeStat();

        public override void Initialize()
        {
            base.Initialize();
            intellectStat.Initialize(this);
            mindStat.Initialize(this);
            knowledgeStat.Initialize(this);
            stats = new Stat.Stat[3];
            stats[0] = intellectStat;
            stats[1] = mindStat;
            stats[2] = knowledgeStat;
        }
    } 
}
