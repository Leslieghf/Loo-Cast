using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.UI.Slider
{
    public class DifficultySlider : Slider
    {
        public float difficulty
        {
            get
            {
                float difficulty;
                if (!PlayerPrefs.HasKey("Difficulty"))
                {
                    PlayerPrefs.SetFloat("Difficulty", 1.0f);
                }
                difficulty = PlayerPrefs.GetFloat("Difficulty");
                return difficulty;
            }

            set
            {
                PlayerPrefs.SetFloat("Difficulty", value);
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            Refresh();
        }

        protected override void OnValueChanged(float value)
        {
            base.OnValueChanged(value);
        }

        public override void Refresh()
        {
            SetValue(difficulty);
            slider.minValue = 0.01f;
            slider.maxValue = 5;
        }

        public override void SetValue(float value)
        {
            base.SetValue(value);
            difficulty = value;
        }
    } 
}
