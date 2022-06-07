using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Attribute.Stat;
using LooCast.Currency;
using LooCast.UI.Panel;
using LooCast.UI.Value;

namespace LooCast.UI.Button
{
    public class StatSetButton : Button
    {
        public int statIncrement;
        private Stat stat;
        private CoinsValue coinsValue;
        private StatValue statListValue;
        private StatPanel statPanel;
        private StatsListPanel statsListPanel;

        //new, because StatSetButton.Initialize is called from somewhere else, whereas base.Initialize is just called on MonoBehaviour.Start.
        //This is okay, because base.Initialize only initializes basic functionality of the button (mostly initializing variables)
        //whereas this.Initialize has to be logically seperated from MonoBehaviour.Start and called seperately and controllably for hard to explain logical constructs in my god forsacken 95% weed fueled codebase
        new public virtual void Initialize()
        {
            statPanel = transform.parent.GetComponent<StatPanel>();
            stat = statPanel.GetStat();
            coinsValue = statPanel.coinsValue;
            statsListPanel = statPanel.statsListPanel;
            statListValue = statsListPanel.GetStatValue(stat.GetName());
        }

        public override void OnClick()
        {
            int currentLevel = stat.GetLevel();
            int targetLevel = currentLevel + statIncrement;
            int cost = stat.GetCost(targetLevel);
            int balance = Coins.GetBalance();
            int maxLevel = stat.GetMaxLevel();
            bool isValidPurchase = true;

            if (cost > balance || currentLevel == targetLevel || targetLevel < 0 || targetLevel > maxLevel)
            {
                isValidPurchase = false;
            }

            if (isValidPurchase)
            {
                Coins.SetBalance(balance - cost);
                stat.SetLevel(targetLevel);

                currentLevel = stat.GetLevel();
                targetLevel = currentLevel + statIncrement;
                cost = stat.GetCost(targetLevel);
                balance = Coins.GetBalance();
                maxLevel = stat.GetMaxLevel();

                if (cost > balance || currentLevel == targetLevel || targetLevel < 0 || targetLevel > maxLevel)
                {
                    isValidPurchase = false;
                }

                if (isValidPurchase)
                {
                    coinsValue.SetChange(-stat.GetCost(stat.GetLevel() + statIncrement));
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
            coinsValue.SetChange(-stat.GetCost(stat.GetLevel() + statIncrement));
            statListValue.SetChange(statIncrement);
        }

        public override void OnHoverStop()
        {
            coinsValue.SetChange(0);
            statListValue.SetChange(0);
        }
    } 
}
