using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.UI.Canvas
{
    public class InterfaceCanvas : Canvas
    {
        public Stack<Screen.Screen> screenStack = new Stack<Screen.Screen>();
        public Screen.Screen[] screens { get; private set; }

        public override void Initialize()
        {
            base.Initialize();
            screens = GetComponentsInChildren<Screen.Screen>();
            foreach (Screen.Screen screen in screens)
            {
                screen.Initialize(this);
            }
        }
    } 
}
