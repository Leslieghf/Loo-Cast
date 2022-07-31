using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.UI.Value
{
    using Attribute.Stat;

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
