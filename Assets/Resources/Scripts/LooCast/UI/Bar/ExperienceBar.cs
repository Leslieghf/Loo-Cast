using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LooCast.UI.Bar
{
    using LooCast.Experience.Data.Runtime;

    public class ExperienceBar : Bar
    {
        public PlayerExperienceRuntimeData PlayerExperienceRuntimeData;

        private void Start()
        {
            PlayerExperienceRuntimeData.CurrentExperience.OnValueChanged.AddListener(() => { Refresh(); });
            PlayerExperienceRuntimeData.LevelExperienceMax.OnValueChanged.AddListener(() => { Refresh(); });
        }

        public override void Refresh()
        {
            Slider.minValue = 0.0f;
            Slider.maxValue = PlayerExperienceRuntimeData.LevelExperienceMax.Value;
            Slider.value = PlayerExperienceRuntimeData.CurrentExperience.Value;
        }
    }
}
