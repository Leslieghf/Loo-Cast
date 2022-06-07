using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Sound;

namespace LooCast.UI.Slider
{
    public abstract class VolumeSlider : Slider
    {
        protected LooCast.Sound.Sound.Soundtype soundtype;
        protected SoundHandler soundHandler;
        public float volume
        {
            get
            {
                float volume;
                if (!PlayerPrefs.HasKey(soundtype.ToStringID()))
                {
                    PlayerPrefs.SetFloat(soundtype.ToStringID(), -5.0f);
                }
                volume = PlayerPrefs.GetFloat(soundtype.ToStringID());
                return volume;
            }

            set
            {
                PlayerPrefs.SetFloat(soundtype.ToStringID(), value);
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            soundHandler = GameObject.FindObjectOfType<SoundHandler>();
            Refresh();
        }

        protected override void OnValueChanged(float value)
        {
            base.OnValueChanged(value);
            SetValue(value);
        }

        public override void Refresh()
        {
            SetValue(volume);
            slider.minValue = -80.0f;
            slider.maxValue = 0.0f;
        }

        public override void SetValue(float value)
        {
            base.SetValue(value);
            volume = value;
            soundHandler.SetVolume(value, soundtype);
        }
    } 
}
