using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.UI.Button;
using LooCast.UI.Canvas;

namespace LooCast.UI.Screen
{
    public class PauseScreen : Screen
    {
        protected PauseButton pauseButton;

        public override void Initialize(InterfaceCanvas canvas)
        {
            isInitiallyVisible = false;
            isHideable = true;
            base.Initialize(canvas);

            pauseButton = FindObjectOfType<PauseButton>();
        }

        public override void SetVisibility(bool show)
        {
            base.SetVisibility(show);
            pauseButton.transform.SetAsLastSibling();
        }
    } 
}
