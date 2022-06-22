using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Currency;
using UnityEngine.Events;

namespace LooCast.Attribute.Stat
{
    public abstract class Stat
    {
        public int Level { get { return GetLevel(); } }

        public UnityEvent onLevelChanged;
        public UnityEvent onMaxLevelChanged;
        protected string name;
        protected Attribute attribute;

        public virtual void Initialize(Attribute attribute)
        {
            this.attribute = attribute;
            name = this.GetType().Name;
            if (!Stats.TryAdd(name, this))
            {
                throw new System.Exception("Could not add Stat to Stats List!");
            }
            onLevelChanged = new UnityEvent();
            onMaxLevelChanged = new UnityEvent();
        }

        public virtual void SetLevel(int level)
        {
            PlayerPrefs.SetInt($"{name}.level", level);
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
                SetMaxLevel(attribute.GetLevel());
            }
            maxLevel = PlayerPrefs.GetInt($"{name}.maxLevel");
            return maxLevel;
        }

        public string GetName()
        {
            return name;
        }

        public Attribute GetAttribute()
        {
            return attribute;
        }

        public virtual int GetCost(int targetLevel)
        {
            int currentLevel = GetLevel();
            int cost = 0;
            int start;
            int bound;
            bool isRefund = false;

            if (targetLevel < currentLevel)
            {
                start = targetLevel + 1;
                bound = currentLevel;
                isRefund = true;
            }
            else if (targetLevel > currentLevel)
            {
                start = currentLevel + 1;
                bound = targetLevel;
            }
            else
            {
                return 0;
            }

            for (int i = start; i <= bound; i++)
            {
                cost += i*10;
            }

            if (isRefund)
            {
                cost *= -1;
            }
            return cost;
        }

        public abstract string ValueToString();
    } 
}
