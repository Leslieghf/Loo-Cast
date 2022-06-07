using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.UI.Slider
{
    public class UIVolumeSlider : VolumeSlider
    {
        public override void Initialize()
        {
            soundtype = LooCast.Sound.Sound.Soundtype.UI;
            base.Initialize();
        }
    } 
}
