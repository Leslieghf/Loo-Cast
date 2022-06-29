using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Attribute;

namespace LooCast.UI.Level
{
    public class AttributeLevel : Level
    {
        private Attribute.Attribute attribute;

        public virtual void Initialize(Attribute.Attribute attribute, int value, int maxValue)
        {
            base.Initialize(value, maxValue);
            this.attribute = attribute;
            attribute.Level.OnValueChanged.AddListener(Refresh);
            attribute.MaxLevel.OnValueChanged.AddListener(Refresh);
            Refresh();
        }

        public override void Refresh()
        {
            base.SetValue(attribute.Level.Value);
            base.SetMaxValue(attribute.MaxLevel.Value);
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
