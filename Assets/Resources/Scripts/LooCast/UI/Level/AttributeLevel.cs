using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LooCast.UI.Level
{
    using Attribute;

    public class AttributeLevel : Level
    {
        public Attribute Attribute;

        public override void Refresh()
        {
            Text.text = $"{Attribute.Level.Value}/{Attribute.MaxLevel.Value}";
        }
    } 
}
