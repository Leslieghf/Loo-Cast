using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.UI.Tab;
using LooCast.UI.Canvas;

namespace LooCast.UI.Screen
{
    public class StatsScreen : Screen
    {
        public override void Initialize(InterfaceCanvas canvas)
        {
            isInitiallyVisible = false;
            isHideable = true;
            base.Initialize(canvas);
        }
    } 
}
