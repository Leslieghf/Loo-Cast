using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.UI.Canvas;
using LooCast.UI.Slider;

namespace LooCast.UI.Screen
{
    public class SettingsScreen : Screen
    {
        [SerializeField]
        protected MasterVolumeSlider masterVolumeSlider;
        [SerializeField]
        protected EffectVolumeSlider effectsVolumeSlider;
        [SerializeField]
        protected MusicVolumeSlider musicVolumeSlider;
        [SerializeField]
        protected UIVolumeSlider UIVolumeSlider;
        [SerializeField]
        protected DifficultySlider difficultySlider;

        public override void Initialize(InterfaceCanvas canvas)
        {
            isInitiallyVisible = false;
            isHideable = true;
            base.Initialize(canvas);

            masterVolumeSlider.Initialize();
            effectsVolumeSlider.Initialize();
            musicVolumeSlider.Initialize();
            UIVolumeSlider.Initialize();
            difficultySlider.Initialize();
        }

        public override void Refresh()
        {
            base.Refresh();
            masterVolumeSlider.Refresh();
            effectsVolumeSlider.Refresh();
            musicVolumeSlider.Refresh();
            UIVolumeSlider.Refresh();
            difficultySlider.Refresh();
        }
    } 
}
