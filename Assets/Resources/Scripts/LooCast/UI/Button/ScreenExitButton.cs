using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.UI.Screen;

namespace LooCast.UI.Button
{
    public class ScreenExitButton : Button
    {
        public LooCast.UI.Screen.Screen screen;

        public override void OnClick()
        {
            screen.SetVisibility(false);
        }
    } 
}
