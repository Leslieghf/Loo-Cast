using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Attribute;
using LooCast.Attribute.Stat;

namespace LooCast.UI.Value
{
    public class StatValue : Value
    {
        public Stat Stat;

        public override void Refresh()
        {
            if (Stat.ProposedLevelChange.Value == 0)
            {
                Text.text = $"{Stat.Level.Value}";
            }
            else if (Stat.ProposedLevelChange.Value < 0)
            {
                if (Stat.Level.Value + Stat.ProposedLevelChange.Value < 0)
                {
                    Text.text = $"{Stat.Level.Value}";
                }
                else
                {
                    Text.text = $"{Stat.Level.Value}<color=#EB3B5A>{Stat.ProposedLevelChange.Value}</color>";
                }
            }
            else if (Stat.ProposedLevelChange.Value > 0)
            {
                Text.text = $"{Stat.Level.Value}<color=#20BF6B>+{Stat.ProposedLevelChange.Value}</color>";
            }
        }
    } 
}
