using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.UI.Slider
{
    public class MasterVolumeSlider : VolumeSlider
    {
        public override void Initialize()
        {
            soundtype = LooCast.Sound.Sound.Soundtype.Master;
            base.Initialize();
        }
    } 
}
