using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute.Stat
{
    [CreateAssetMenu(fileName = "Stats", menuName = "Data/Attribute/Stat/Stats", order = 0)]
    public class Stats : ScriptableObject
    {
        public float MovementSpeedMultiplier { get { return Agility.MovementSpeedMultiplier.Value; } }
        //public float UNDEFINED { get { return AlertnessStat.UNDEFINED.Value; } }
        //public float UNDEFINED { get { return AwarenessStat.UNDEFINED.Value; } }

        public AgilityStat Agility;
        public AlertnessStat Alertness;
        public AwarenessStat Awareness;
        public BodyStat Body;
        public BrawnStat Brawn;
        public CautiousnessStat Cautiousness;
        public ChanceStat Chance;
        public CharmStat Charm;
        public EgoStat Ego;
        public EnduranceStat Endurance;
        public FateStat Fate;
        public FortitudeStat Fortitude;
        public FortuneStat Fortune;
        public IntellectStat Intellect;
        public KnowledgeStat Knowledge;
        public MightStat Might;
        public MindStat Mind;
        public PersonalityStat Personality;
        public PowerStat Power;
        public PresenceStat Presence;
        public PsycheStat Psyche;
        public QuicknessStat Quickness;
        public RecoveryStat Recovery;
        public ReflexesStat Reflexes;
        public ResilienceStat Resilience;
        public ResistanceStat Resistance;
        public ResolveStat Resolve;
        public SanityStat Sanity;
        public SenseStat Sense;
        public SocialStat Social;
        public SpiritStat Spirit;
        public StaminaStat Stamina;
        public VitalityStat Vitality;
        public WitsStat Wits;
    } 
}
