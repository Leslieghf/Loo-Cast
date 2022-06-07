using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute.Stat
{
    public static class Stats
    {
        public static readonly Dictionary<string, Stat> stats = new Dictionary<string, Stat>();
        public static float energyMultiplier { get { return ((BodyStat)GetStat("BodyStat")).energyMultiplier; } }
        public static float damageMultiplier { get { return ((MightStat)GetStat("MightStat")).damageMultiplier; } }
        public static int armorPenetrationIncrease { get { return ((BrawnStat)GetStat("BrawnStat")).armorPenetrationIncrease; } }
        public static float knockbackMultiplier { get { return ((PowerStat)GetStat("PowerStat")).knockbackMultiplier; } }
        public static float durationMultiplier { get { return ((StaminaStat)GetStat("StaminaStat")).durationMultiplier; } }
        public static float energyRegenerationMultiplier { get { return ((EnduranceStat)GetStat("EnduranceStat")).energyRegenerationMultiplier; } }
        public static float healthMultiplier { get { return ((VitalityStat)GetStat("VitalityStat")).healthMultiplier; } }
        public static float healthRegenrationMultiplier { get { return ((RecoveryStat)GetStat("RecoveryStat")).healthRegenrationMultiplier; } }
        public static int defenseIncrease { get { return ((ResistanceStat)GetStat("ResistanceStat")).defenseIncrease; } }
        public static float energyConsumptionMultiplier { get { return ((FortitudeStat)GetStat("FortitudeStat")).energyConsumptionMultiplier; } }
        public static int shieldStrengthIncrease { get { return ((ResilienceStat)GetStat("ResilienceStat")).shieldStrengthIncrease; } }
        public static float movementSpeedMultiplier { get { return ((AgilityStat)GetStat("AgilityStat")).movementSpeedMultiplier; } }
        public static float consecutiveProjectileDelayMultiplier { get { return ((ReflexesStat)GetStat("ReflexesStat")).consecutiveProjectileDelayMultiplier; } }
        public static float attackDelayMultiplier { get { return ((QuicknessStat)GetStat("QuicknessStat")).attackDelayMultiplier; } }
        public static float experienceMultiplier { get { return ((IntellectStat)GetStat("IntellectStat")).experienceMultiplier; } }
        public static float rangeMultiplier { get { return ((MindStat)GetStat("MigMindStathtStat")).rangeMultiplier; } }
        public static float levelExperienceMaxMultiplier { get { return ((KnowledgeStat)GetStat("KnowledgeStat")).levelExperienceMaxMultiplier; } }
        public static float projectileSizeMultiplier { get { return ((SanityStat)GetStat("SanityStat")).projectileSizeMultiplier; } }
        public static float projectileSpeedMultiplier { get { return ((PersonalityStat)GetStat("PersonalityStat")).projectileSpeedMultiplier; } }
        public static float damageReflection { get { return ((EgoStat)GetStat("EgoStat")).damageReflection; } }
        public static int piercingIncrease { get { return ((ResolveStat)GetStat("ResolveStat")).piercingIncrease; } }
        public static float negativeEventChanceMultiplier { get { return ((FateStat)GetStat("FateStat")).negativeEventChanceMultiplier; } }
        public static float randomChanceMultiplier { get { return ((ChanceStat)GetStat("ChanceStat")).randomChanceMultiplier; } }
        public static float positiveEventChanceMultiplier { get { return ((FortuneStat)GetStat("FortuneStat")).positiveEventChanceMultiplier; } }

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
