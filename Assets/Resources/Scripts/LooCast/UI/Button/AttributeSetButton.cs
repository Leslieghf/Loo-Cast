using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Attribute;
using LooCast.Currency;
using LooCast.UI.Panel;
using LooCast.UI.Value;

namespace LooCast.UI.Button
{
    public class AttributeSetButton : Button
    {
        public int attributeIncrement;
        private LooCast.Attribute.Attribute attribute;
        private TokensValue tokensValue;
        private AttributePanel attributePanel;

        //new, because StatSetButton.Initialize is called from somewhere else, whereas base.Initialize is just called on MonoBehaviour.Start.
        //This is okay, because base.Initialize only initializes basic functionality of the button (mostly initializing variables)
        //whereas this.Initialize has to be logically seperated from MonoBehaviour.Start and called seperately and controllably
        new public virtual void Initialize()
        {
            attributePanel = transform.parent.GetComponent<AttributePanel>();
            attribute = attributePanel.GetAttribute();
            tokensValue = attributePanel.tokensValue;
        }

        public override void OnClick()
        {
            int currentLevel = attribute.GetLevel();
            int targetLevel = currentLevel + attributeIncrement;
            int cost = attribute.GetCost(targetLevel);
            int balance = Tokens.GetBalance();
            int maxLevel = attribute.GetMaxLevel();
            bool isValidPurchase = true;

            if (cost > balance || currentLevel == targetLevel || targetLevel < 0 || targetLevel > maxLevel)
            {
                isValidPurchase = false;
            }

            if (isValidPurchase)
            {
                Tokens.SetBalance(balance - cost);
                attribute.SetLevel(targetLevel);

                currentLevel = attribute.GetLevel();
                targetLevel = currentLevel + attributeIncrement;
                cost = attribute.GetCost(targetLevel);
                balance = Tokens.GetBalance();
                maxLevel = attribute.GetMaxLevel();

                if (cost > balance || currentLevel == targetLevel || targetLevel < 0 || targetLevel > maxLevel)
                {
                    isValidPurchase = false;
                }

                if (isValidPurchase)
                {
                    tokensValue.SetChange(-attribute.GetCost(attribute.GetLevel() + attributeIncrement));
                }
                else
                {
                    tokensValue.SetChange(0);
                }
            }
        }

        public override void OnHoverStart()
        {
            int currentLevel = attribute.GetLevel();
            int maxLevel = attribute.GetMaxLevel();
            if (currentLevel < maxLevel)
            {
                tokensValue.SetChange(-attribute.GetCost(attribute.GetLevel() + attributeIncrement));
            }
        }

        public override void OnHoverStop()
        {
            tokensValue.SetChange(0);
        }
    } 
}
