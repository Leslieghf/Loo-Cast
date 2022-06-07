using System.Collections;
using System.Collections.Generic;
using LooCast.UI.Canvas;
using UnityEngine;

namespace LooCast.UI.Screen
{
    public class MainScreen : Screen
    {
        public override void Initialize(InterfaceCanvas canvas)
        {
            isInitiallyVisible = true;
            isHideable = false;
            base.Initialize(canvas);
        }
    } 
}
