using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Attribute;
using LooCast.Attribute.Stat;

namespace LooCast.UI.Value
{
    public class StatValue : Value
    {
        protected Stat stat;

        public virtual void Initialize(Stat stat, int value, int minValue = 0)
        {
            base.Initialize(value, minValue);
            this.stat = stat;
            stat.onLevelChanged.AddListener(Refresh);
            stat.onMaxLevelChanged.AddListener(Refresh);
            Refresh();
        }

        public override void Refresh()
        {
            base.SetValue(stat.GetLevel());
            base.Refresh();
        }

        public override void SetChange(int change)
        {
            base.SetChange(change);
            Refresh();
        }

        public override void SetValue(int value)
        {
            base.SetValue(value);
            Refresh();
        }
    } 
}
