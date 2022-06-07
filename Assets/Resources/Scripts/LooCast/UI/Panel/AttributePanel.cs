using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Attribute;
using LooCast.UI.Button;
using LooCast.UI.Level;
using LooCast.UI.Value;

namespace LooCast.UI.Panel
{
    public class AttributePanel : Panel
    {
        [SerializeField]
        private string attributeClassName;
        private LooCast.Attribute.Attribute attribute;
        [SerializeField]
        private AttributeLevel attributeLevel;
        [HideInInspector]
        public TokensValue tokensValue;
        private AttributeSetButton[] attributeSetButtons;

        public override void Initialize()
        {
            GetAttribute();
            attributeLevel.Initialize(attribute, attribute.GetLevel(), attribute.GetMaxLevel());
            attributeSetButtons = GetComponentsInChildren<AttributeSetButton>(true);
            foreach (AttributeSetButton attributeSetButton in attributeSetButtons)
            {
                attributeSetButton.Initialize();
            }
        }

        public LooCast.Attribute.Attribute GetAttribute()
        {
            if (attribute == null)
            {
                attribute = Attributes.GetAttribute(attributeClassName);
                if (attribute == null)
                {
                    throw new System.Exception("Could not get Attribute Class by Class Name");
                }
            }
            return attribute;
        }

        public override void Refresh()
        {
            attributeLevel.Refresh();
        }
    } 
}
