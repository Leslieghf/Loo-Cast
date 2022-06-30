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
        public Coins Coins;
        public int statIncrement;
        public Stat Stat;

        public override void OnClick()
        {
            int currentLevel = Stat.Level.Value;
            int targetLevel = currentLevel + statIncrement;
            int cost = Stat.GetCost(targetLevel);
            int balance = Coins.Balance.Value;
            int maxLevel = Stat.MaxLevel.Value;
            bool isValidPurchase = true;

            if (cost > balance || currentLevel == targetLevel || targetLevel < 0 || targetLevel > maxLevel)
            {
                isValidPurchase = false;
            }

            if (isValidPurchase)
            {
                Coins.Balance.Value = balance - cost;
                Stat.Level.Value = targetLevel;

                currentLevel = Stat.Level.Value;
                targetLevel = currentLevel + statIncrement;
                cost = Stat.GetCost(targetLevel);
                balance = Coins.Balance.Value;
                maxLevel = Stat.MaxLevel.Value;

                if (cost > balance || currentLevel == targetLevel || targetLevel < 0 || targetLevel > maxLevel)
                {
                    isValidPurchase = false;
                }

                if (isValidPurchase)
                {
                    Coins.ProposedBalanceChange.Value = -Stat.GetCost(Stat.Level.Value + statIncrement);
                    Stat.ProposedLevelChange.Value = statIncrement;
                }
                else
                {
                    Coins.ProposedBalanceChange.Value = 0;
                    Stat.ProposedLevelChange.Value = 0;
                }
            }
        }

        public override void OnHoverStart()
        {
            Coins.ProposedBalanceChange.Value = -Stat.GetCost(Stat.Level.Value + statIncrement);
            Stat.ProposedLevelChange.Value = statIncrement;
        }

        public override void OnHoverStop()
        {
            Coins.ProposedBalanceChange.Value = 0;
            Stat.ProposedLevelChange.Value = 0;
        }
    } 
}
