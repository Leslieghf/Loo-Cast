using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Attribute.Stat;
using LooCast.Currency;
using LooCast.UI.Value;

namespace LooCast.UI.Button
{
    public class StatSetButton : Button
    {
        public int statIncrement;
        public Stat stat;
        public CoinsValue coinsValue;
        public StatValue statListValue;

        public override void OnClick()
        {
            int currentLevel = stat.Level.Value;
            int targetLevel = currentLevel + statIncrement;
            int cost = stat.GetCost(targetLevel);
            int balance = Coins.GetBalance();
            int maxLevel = stat.MaxLevel.Value;
            bool isValidPurchase = true;

            if (cost > balance || currentLevel == targetLevel || targetLevel < 0 || targetLevel > maxLevel)
            {
                isValidPurchase = false;
            }

            if (isValidPurchase)
            {
                Coins.SetBalance(balance - cost);
                stat.Level.Value = targetLevel;

                currentLevel = stat.Level.Value;
                targetLevel = currentLevel + statIncrement;
                cost = stat.GetCost(targetLevel);
                balance = Coins.GetBalance();
                maxLevel = stat.MaxLevel.Value;

                if (cost > balance || currentLevel == targetLevel || targetLevel < 0 || targetLevel > maxLevel)
                {
                    isValidPurchase = false;
                }

                if (isValidPurchase)
                {
                    coinsValue.SetChange(-stat.GetCost(stat.Level.Value + statIncrement));
                    statListValue.SetChange(statIncrement);
                }
                else
                {
                    coinsValue.SetChange(0);
                    statListValue.SetChange(0);
                }
            }
        }

        public override void OnHoverStart()
        {
            coinsValue.SetChange(-stat.GetCost(stat.Level.Value + statIncrement));
            statListValue.SetChange(statIncrement);
        }

        public override void OnHoverStop()
        {
            coinsValue.SetChange(0);
            statListValue.SetChange(0);
        }
    } 
}
