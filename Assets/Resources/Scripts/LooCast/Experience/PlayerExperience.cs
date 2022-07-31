using UnityEngine;

namespace LooCast.Experience
{
    using Data;
    using Data.Runtime;
    using Attribute.Stat;
    using Currency;
    using Sound;

    public sealed class PlayerExperience : Experience
    {
        public PlayerExperienceData Data;
        public PlayerExperienceRuntimeData RuntimeData;
        public Stats Stats;
        public Coins Coins;
        public Tokens Tokens;

        private float experienceMultiplier;
        private float levelExperienceMultiplier;

        private GameSoundHandler soundHandler;

        private void Start()
        {
            RuntimeData.CurrentExperience = Data.InitialExperience.Value;   //0.0f
            RuntimeData.LevelExperienceMax = Data.InitialLevelExperienceMax.Value; //10.0f
            RuntimeData.CurrentLevel = Data.InitialLevel.Value;             //0
            experienceMultiplier = Stats.ExperienceMultiplier;
            levelExperienceMultiplier = Stats.LevelExperienceMaxMultiplier;
            soundHandler = FindObjectOfType<GameSoundHandler>();
        }

        public override void AddExperience(float xp)
        {
            Coins.Balance.Value = Coins.Balance.Value + Mathf.RoundToInt(xp);
            RuntimeData.CurrentExperience += xp * experienceMultiplier;

            UpdateLevelProgress(RuntimeData.CurrentExperience);
        }

        protected override void UpdateLevelProgress(float overflowXP)
        {
            if (overflowXP == RuntimeData.LevelExperienceMax)
            {
                IncreaseLevel();
                RuntimeData.CurrentExperience = 0;
                return;
            }

            if (overflowXP > RuntimeData.LevelExperienceMax)
            {
                UpdateLevelProgress(overflowXP - RuntimeData.LevelExperienceMax);
                IncreaseLevel();
                return;
            }

            if (overflowXP < RuntimeData.LevelExperienceMax)
            {
                RuntimeData.CurrentExperience = overflowXP;
                return;
            }
        }

        protected override void IncreaseLevel()
        {
            RuntimeData.CurrentLevel++;
            RuntimeData.LevelExperienceMax = RuntimeData.LevelExperienceMax * levelExperienceMultiplier;
            Tokens.Balance.Value = Tokens.Balance.Value + 1;
            soundHandler.SoundUpgrade();
        }
    } 
}