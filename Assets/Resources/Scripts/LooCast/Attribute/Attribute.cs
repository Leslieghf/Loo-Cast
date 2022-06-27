using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using LooCast.Currency;

namespace LooCast.Attribute
{
    using Stat;

    public abstract class Attribute
    {
        public UnityEvent onLevelChanged;
        public UnityEvent onMaxLevelChanged;
        protected string name;
        protected Stat.Stat[] stats;

        public virtual void Initialize()
        {
            name = GetType().Name;
            onLevelChanged = new UnityEvent();
            onMaxLevelChanged = new UnityEvent();
        }

        public virtual void SetLevel(int level)
        {
            PlayerPrefs.SetInt($"{name}.level", level);
            for (int i = 0; i < stats.Length; i++)
            {
                stats[i].SetMaxLevel(level);
            }
            onLevelChanged.Invoke();
        }

        public virtual void SetMaxLevel(int maxLevel)
        {
            PlayerPrefs.SetInt($"{name}.maxLevel", maxLevel);
            onMaxLevelChanged.Invoke();
        }

        public int GetLevel()
        {
            int level;
            if (!PlayerPrefs.HasKey($"{name}.level"))
            {
                SetLevel(0);
            }
            level = PlayerPrefs.GetInt($"{name}.level");
            return level;
        }

        public int GetMaxLevel()
        {
            int maxLevel;
            if (!PlayerPrefs.HasKey($"{name}.maxLevel"))
            {
                SetMaxLevel(10);
            }
            maxLevel = PlayerPrefs.GetInt($"{name}.maxLevel");
            return maxLevel;
        }

        public string GetName()
        {
            return name;
        }

        public int GetCost(int targetLevel)
        {
            int currentLevel = GetLevel();
            int cost = 0;
            int start;
            int end;
            bool isRefund = false;

            if (targetLevel < currentLevel)
            {
                start = targetLevel + 1;
                end = currentLevel;
                isRefund = true;
            }
            else if (targetLevel > currentLevel)
            {
                start = currentLevel + 1;
                end = targetLevel;
            }
            else
            {
                return 0;
            }

            for (int i = start; i <= end; i++)
            {
                cost += i;
            }

            if (isRefund)
            {
                cost *= -1;
            }
            return cost;
        }
    } 
}
