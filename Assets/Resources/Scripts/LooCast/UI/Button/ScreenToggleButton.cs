using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.UI.Button
{
    public class ScreenToggleButton : ScreenEnterButton
    {
        public override void OnClick()
        {
            ToggleVisibility();
        }

        public virtual void ToggleVisibility()
        {
            screen.ToggleVisibility();
        }
    } 
}
