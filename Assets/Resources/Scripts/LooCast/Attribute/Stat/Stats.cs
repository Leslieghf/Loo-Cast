using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute.Stat
{
    public static class Stats
    {
        public static readonly Dictionary<string, Stat> stats = new Dictionary<string, Stat>();
        public static float EnergyMultiplier { get { return ((BodyStat)GetStat("BodyStat")).EnergyMultiplier; } }
        public static float DamageMultiplier { get { return ((MightStat)GetStat("MightStat")).DamageMultiplier; } }
        public static int ArmorPenetrationIncrease { get { return ((BrawnStat)GetStat("BrawnStat")).ArmorPenetrationIncrease; } }
        public static float KnockbackMultiplier { get { return ((PowerStat)GetStat("PowerStat")).KnockbackMultiplier; } }
        public static float DurationMultiplier { get { return ((StaminaStat)GetStat("StaminaStat")).DurationMultiplier; } }
        public static float EnergyRegenerationMultiplier { get { return ((EnduranceStat)GetStat("EnduranceStat")).EnergyRegenerationMultiplier; } }
        public static float HealthMultiplier { get { return ((VitalityStat)GetStat("VitalityStat")).HealthMultiplier; } }
        public static float HealthRegenrationMultiplier { get { return ((RecoveryStat)GetStat("RecoveryStat")).HealthRegenrationMultiplier; } }
        public static int DefenseIncrease { get { return ((ResistanceStat)GetStat("ResistanceStat")).DefenseIncrease; } }
        public static float EnergyConsumptionMultiplier { get { return ((FortitudeStat)GetStat("FortitudeStat")).EnergyConsumptionMultiplier; } }
        public static int ShieldStrengthIncrease { get { return ((ResilienceStat)GetStat("ResilienceStat")).ShieldStrengthIncrease; } }
        public static float MovementSpeedMultiplier { get { return ((AgilityStat)GetStat("AgilityStat")).MovementSpeedMultiplier; } }
        public static float ConsecutiveProjectileDelayMultiplier { get { return ((ReflexesStat)GetStat("ReflexesStat")).ConsecutiveProjectileDelayMultiplier; } }
        public static float AttackDelayMultiplier { get { return ((QuicknessStat)GetStat("QuicknessStat")).AttackDelayMultiplier; } }
        public static float ExperienceMultiplier { get { return ((IntellectStat)GetStat("IntellectStat")).ExperienceMultiplier; } }
        public static float RangeMultiplier { get { return ((MindStat)GetStat("MigMindStathtStat")).RangeMultiplier; } }
        public static float LevelExperienceMaxMultiplier { get { return ((KnowledgeStat)GetStat("KnowledgeStat")).LevelExperienceMaxMultiplier; } }
        public static float ProjectileSizeMultiplier { get { return ((SanityStat)GetStat("SanityStat")).ProjectileSizeMultiplier; } }
        public static float ProjectileSpeedMultiplier { get { return ((PersonalityStat)GetStat("PersonalityStat")).ProjectileSpeedMultiplier; } }
        public static float DamageReflection { get { return ((EgoStat)GetStat("EgoStat")).DamageReflection; } }
        public static int PiercingIncrease { get { return ((ResolveStat)GetStat("ResolveStat")).PiercingIncrease; } }
        public static float NegativeEventChanceMultiplier { get { return ((FateStat)GetStat("FateStat")).NegativeEventChanceMultiplier; } }
        public static float RandomChanceMultiplier { get { return ((ChanceStat)GetStat("ChanceStat")).RandomChanceMultiplier; } }
        public static float PositiveEventChanceMultiplier { get { return ((FortuneStat)GetStat("FortuneStat")).PositiveEventChanceMultiplier; } }

        public static Stat GetStat(string statClassName)
        {
            return stats.TryGetValue(statClassName, out Stat stat) ? stat : null;
        }

        public static bool TryAdd(string name, Stat stat)
        {
            return stats.TryAdd(name, stat);
        }

        public static void Cheat()
        {
            foreach (Stat stat in stats.Values)
            {
                stat.SetLevel(10);
            }
        }
    }
}
