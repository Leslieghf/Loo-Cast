using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Attribute;
using LooCast.Attribute.Stat;

namespace LooCast.UI.Value
{
    public class StatValue : Value
    {
        public Stat stat;

        public override void Refresh()
        {
            base.SetValue(stat.Level.Value);
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
