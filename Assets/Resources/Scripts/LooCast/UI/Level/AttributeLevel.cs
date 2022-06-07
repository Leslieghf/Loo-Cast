using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Attribute;

namespace LooCast.UI.Level
{
    public class AttributeLevel : Level
    {
        protected LooCast.Attribute.Attribute attribute;

        public virtual void Initialize(LooCast.Attribute.Attribute attribute, int value, int maxValue)
        {
            base.Initialize(value, maxValue);
            this.attribute = attribute;
            attribute.onLevelChanged.AddListener(Refresh);
            attribute.onMaxLevelChanged.AddListener(Refresh);
            Refresh();
        }

        public override void Refresh()
        {
            base.SetValue(attribute.GetLevel());
            base.SetMaxValue(attribute.GetMaxLevel());
            base.Refresh();
        }

        public override void SetValue(int value)
        {
            base.SetValue(value);
            Refresh();
        }

        public override void SetMaxValue(int maxValue)
        {
            base.SetMaxValue(maxValue);
            Refresh();
        }
    } 
}
