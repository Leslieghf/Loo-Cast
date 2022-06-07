using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.UI.Button
{
    public class ApplicationQuitButton : Button
    {
        public override void OnClick()
        {
            Application.Quit();
        }
    } 
}
