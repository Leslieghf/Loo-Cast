using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.UI.Screen;

namespace LooCast.UI.Button
{
    public class ScreenEnterButton : Button
    {
        [SerializeField]
        protected Screen.Screen screen;

        public override void OnClick()
        {
            screen.SetVisibility(true);
        }
    } 
}
