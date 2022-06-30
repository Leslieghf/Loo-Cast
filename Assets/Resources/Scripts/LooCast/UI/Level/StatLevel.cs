using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LooCast.UI.Level
{
    using Attribute.Stat;

    public class StatLevel : Level
    {
        public Stat Stat;

        public override void Refresh()
        {
            Text.text = $"{Stat.Level.Value}/{Stat.MaxLevel.Value}";
        }
    } 
}
