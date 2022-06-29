using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Attribute.Stat;

namespace LooCast.UI.Level
{
    public class StatLevel : Level
    {
        protected Stat stat;

        public virtual void Initialize(Stat stat, int value, int maxValue)
        {
            base.Initialize(value, maxValue);
            this.stat = stat;
            stat.Level.OnValueChanged.AddListener(Refresh);
            stat.MaxLevel.OnValueChanged.AddListener(Refresh);
            Refresh();
        }

        public override void Refresh()
        {
            base.SetValue(stat.Level.Value);
            base.SetMaxValue(stat.MaxLevel.Value);
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
