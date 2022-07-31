using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute.Stat
{
    public abstract class Stat : ScriptableObject
    {
        public IntReference Level;
        public IntReference MaxLevel;
        public IntReference ProposedLevelChange;

        public virtual int GetCost(int targetLevel)
        {
            int currentLevel = Level.Value;
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
                cost += i * 10;
            }

            if (isRefund)
            {
                cost *= -1;
            }
            return cost;
        }
    } 
}
