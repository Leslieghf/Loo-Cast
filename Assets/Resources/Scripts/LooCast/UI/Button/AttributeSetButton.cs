using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Currency;
using LooCast.UI.Value;

namespace LooCast.UI.Button
{
    using Attribute;

    public class AttributeSetButton : Button
    {
        public Tokens Tokens;
        public int attributeIncrement;
        public Attribute attribute;

        public override void OnClick()
        {
            int currentLevel = attribute.Level.Value;
            int targetLevel = currentLevel + attributeIncrement;
            int cost = attribute.GetCost(targetLevel);
            int balance = Tokens.Balance.Value;
            int maxLevel = attribute.MaxLevel.Value;
            bool isValidPurchase = true;

            if (cost > balance || currentLevel == targetLevel || targetLevel < 0 || targetLevel > maxLevel)
            {
                isValidPurchase = false;
            }

            if (isValidPurchase)
            {
                Tokens.Balance.Value = balance - cost;
                attribute.Level.Value = targetLevel;

                currentLevel = attribute.Level.Value;
                targetLevel = currentLevel + attributeIncrement;
                cost = attribute.GetCost(targetLevel);
                balance = Tokens.Balance.Value;
                maxLevel = attribute.MaxLevel.Value;

                if (cost > balance || currentLevel == targetLevel || targetLevel < 0 || targetLevel > maxLevel)
                {
                    isValidPurchase = false;
                }

                if (isValidPurchase)
                {
                    attribute.ProposedLevelChange.Value = -attribute.GetCost(attribute.Level.Value + attributeIncrement);
                }
                else
                {
                    attribute.ProposedLevelChange.Value = 0;
                }
            }
        }

        public override void OnHoverStart()
        {
            int currentLevel = attribute.Level.Value;
            int maxLevel = attribute.MaxLevel.Value;
            if (currentLevel < maxLevel)
            {
                attribute.ProposedLevelChange.Value = -attribute.GetCost(attribute.Level.Value + attributeIncrement);
            }
        }

        public override void OnHoverStop()
        {
            attribute.ProposedLevelChange.Value = 0;
        }
    } 
}
