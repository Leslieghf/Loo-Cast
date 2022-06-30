using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute.Stat
{
    [CreateAssetMenu(fileName = "Stats", menuName = "Data/Attribute/Stat/Stats", order = 0)]
    public class Stats : ScriptableObject
    {
        public float MovementSpeedMultiplier { get { return Agility.MovementSpeedMultiplier.Value; } }
        //public float UNDEFINED { get { return Alertness.UNDEFINED.Value; } }
        //public float UNDEFINED { get { return Awareness.UNDEFINED.Value; } }
        public float EnergyMultiplier { get { return Body.EnergyMultiplier.Value; } }
        public int ArmorPenetrationIncrease { get { return Brawn.ArmorPenetrationIncrease.Value; } }
        //public float UNDEFINED { get { return Cautiousness.UNDEFINED.Value; } }
        public float RandomChanceMultiplier { get { return Chance.RandomChanceMultiplier.Value; } }
        //public float UNDEFINED { get { return Charm.UNDEFINED.Value; } }
        public float DamageReflection { get { return Ego.DamageReflection.Value; } }
        public float EnergyRegenerationMultiplier { get { return Endurance.EnergyRegenerationMultiplier.Value; } }
        public float NegativeEventChanceMultiplier { get { return Fate.NegativeEventChanceMultiplier.Value; } }
        public float EnergyConsumptionMultiplier { get { return Fortitude.EnergyConsumptionMultiplier.Value; } }
        public float PositiveEventChanceMultiplier { get { return Fortune.PositiveEventChanceMultiplier.Value; } }
        public float ExperienceMultiplier { get { return Intellect.ExperienceMultiplier.Value; } }
        public float LevelExperienceMaxMultiplier { get { return Knowledge.LevelExperienceMaxMultiplier.Value; } }
        public float DamageMultiplier { get { return Might.DamageMultiplier.Value; } }
        public float RangeMultiplier { get { return Mind.RangeMultiplier.Value; } }
        public float ProjectileSpeedMultiplier { get { return Personality.ProjectileSpeedMultiplier.Value; } }
        public float KnockbackMultiplier { get { return Power.KnockbackMultiplier.Value; } }
        //public float UNDEFINED { get { return Presence.UNDEFINED.Value; } }
        //public float UNDEFINED { get { return Psyche.UNDEFINED.Value; } }
        public float AttackDelayMultiplier { get { return Quickness.AttackDelayMultiplier.Value; } }
        public float HealthRegenrationMultiplier { get { return Recovery.HealthRegenrationMultiplier.Value; } }
        public float ConsecutiveProjectileDelayMultiplier { get { return Reflexes.ConsecutiveProjectileDelayMultiplier.Value; } }
        public int ShieldStrengthIncrease { get { return Resilience.ShieldStrengthIncrease.Value; } }
        public int DefenseIncrease { get { return Resistance.DefenseIncrease.Value; } }
        public int PiercingIncrease { get { return Resolve.PiercingIncrease.Value; } }
        public float ProjectileSizeMultiplier { get { return Sanity.ProjectileSizeMultiplier.Value; } }
        //public float UNDEFINED { get { return Sense.UNDEFINED.Value; } }
        //public float UNDEFINED { get { return Social.UNDEFINED.Value; } }
        //public float UNDEFINED { get { return Spirit.UNDEFINED.Value; } }
        public float DurationMultiplier { get { return Stamina.DurationMultiplier.Value; } }
        public float HealthMultiplier { get { return Vitality.HealthMultiplier.Value; } }
        //public float UNDEFINED { get { return Wits.UNDEFINED.Value; } }

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

        public void Cheat()
        {
            Agility.Level.Value = Agility.MaxLevel.Value;
            Alertness.Level.Value = Alertness.MaxLevel.Value;
            Awareness.Level.Value = Awareness.MaxLevel.Value;
            Body.Level.Value = Body.MaxLevel.Value;
            Brawn.Level.Value = Brawn.MaxLevel.Value;
            Cautiousness.Level.Value = Cautiousness.MaxLevel.Value;
            Chance.Level.Value = Chance.MaxLevel.Value;
            Charm.Level.Value = Charm.MaxLevel.Value;
            Ego.Level.Value = Ego.MaxLevel.Value;
            Endurance.Level.Value = Endurance.MaxLevel.Value;
            Fate.Level.Value = Fate.MaxLevel.Value;
            Fortitude.Level.Value = Fortitude.MaxLevel.Value;
            Fortune.Level.Value = Fortune.MaxLevel.Value;
            Intellect.Level.Value = Intellect.MaxLevel.Value;
            Knowledge.Level.Value = Knowledge.MaxLevel.Value;
            Might.Level.Value = Might.MaxLevel.Value;
            Mind.Level.Value = Mind.MaxLevel.Value;
            Personality.Level.Value = Personality.MaxLevel.Value;
            Power.Level.Value = Power.MaxLevel.Value;
            Presence.Level.Value = Presence.MaxLevel.Value;
            Psyche.Level.Value = Psyche.MaxLevel.Value;
            Quickness.Level.Value = Quickness.MaxLevel.Value;
            Recovery.Level.Value = Recovery.MaxLevel.Value;
            Reflexes.Level.Value = Reflexes.MaxLevel.Value;
            Resilience.Level.Value = Resilience.MaxLevel.Value;
            Resistance.Level.Value = Resistance.MaxLevel.Value;
            Resolve.Level.Value = Resolve.MaxLevel.Value;
            Sanity.Level.Value = Sanity.MaxLevel.Value;
            Sense.Level.Value = Sense.MaxLevel.Value;
            Social.Level.Value = Social.MaxLevel.Value;
            Spirit.Level.Value = Spirit.MaxLevel.Value;
            Stamina.Level.Value = Stamina.MaxLevel.Value;
            Vitality.Level.Value = Vitality.MaxLevel.Value;
            Wits.Level.Value = Wits.MaxLevel.Value;
        }

        public void Uncheat()
        {
            Agility.Level.Value = 0;
            Alertness.Level.Value = 0;
            Awareness.Level.Value = 0;
            Body.Level.Value = 0;
            Brawn.Level.Value = 0;
            Cautiousness.Level.Value = 0;
            Chance.Level.Value = 0;
            Charm.Level.Value = 0;
            Ego.Level.Value = 0;
            Endurance.Level.Value = 0;
            Fate.Level.Value = 0;
            Fortitude.Level.Value = 0;
            Fortune.Level.Value = 0;
            Intellect.Level.Value = 0;
            Knowledge.Level.Value = 0;
            Might.Level.Value = 0;
            Mind.Level.Value = 0;
            Personality.Level.Value = 0;
            Power.Level.Value = 0;
            Presence.Level.Value = 0;
            Psyche.Level.Value = 0;
            Quickness.Level.Value = 0;
            Recovery.Level.Value = 0;
            Reflexes.Level.Value = 0;
            Resilience.Level.Value = 0;
            Resistance.Level.Value = 0;
            Resolve.Level.Value = 0;
            Sanity.Level.Value = 0;
            Sense.Level.Value = 0;
            Social.Level.Value = 0;
            Spirit.Level.Value = 0;
            Stamina.Level.Value = 0;
            Vitality.Level.Value = 0;
            Wits.Level.Value = 0;
        }
    } 
}
