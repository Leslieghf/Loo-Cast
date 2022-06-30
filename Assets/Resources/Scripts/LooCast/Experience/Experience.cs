using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Attribute.Stat;
using LooCast.Currency;
using LooCast.Sound;
using LooCast.UI.Bar;

namespace LooCast.Experience
{
    public class Experience : MonoBehaviour
    {
        public Stats Stats;
        public Coins Coins;
        public Tokens Tokens;
        
        public float experience = 0;
        public float levelExperienceMax = 10;
        public int level = 0;
        private float experienceMultiplier;
        private float levelExperienceMultiplier;

        public ExperienceBar experienceBar;
        public ExperienceLevelCounter levelCounter;
        protected GameSoundHandler soundHandler;

        private void Start()
        {
            soundHandler = GameObject.FindObjectOfType<GameSoundHandler>();
        }

        public virtual void Initialize()
        {
            experienceBar.Initialize(0, levelExperienceMax);
            experienceMultiplier = Stats.ExperienceMultiplier;
            levelExperienceMultiplier = Stats.LevelExperienceMaxMultiplier;
        }

        public void AddExperience(float xp)
        {
            Coins.Balance.Value = Coins.Balance.Value + Mathf.RoundToInt(xp);
            experience += xp * experienceMultiplier;

            UpdateLevelProgress(experience);

            experienceBar.SetValue(experience);
        }

        public void UpdateLevelProgress(float overflowXP)
        {
            if (overflowXP == levelExperienceMax)
            {
                IncreaseLevel();
                experience = 0;
                return;
            }

            if (overflowXP > levelExperienceMax)
            {
                UpdateLevelProgress(overflowXP - levelExperienceMax);
                IncreaseLevel();
                return;
            }

            if (overflowXP < levelExperienceMax)
            {
                experience = overflowXP;
                return;
            }
        }

        public void IncreaseLevel()
        {
            level++;
            levelCounter.SetLevel(level);
            levelExperienceMax = levelExperienceMax * levelExperienceMultiplier;
            Tokens.Balance.Value = Tokens.Balance.Value + 1;
            experienceBar.SetMaxValue(levelExperienceMax);
            soundHandler.SoundUpgrade();
        }
    } 
}
