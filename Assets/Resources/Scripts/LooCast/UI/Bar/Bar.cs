using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.UI.Bar
{
    public class Bar : MonoBehaviour
    {
        public UnityEngine.UI.Slider slider;

        public virtual void Initialize(float value, float maxValue)
        {
            SetMaxValue(maxValue);
            SetValue(value);
        }

        public virtual void SetValue(float value)
        {
            slider.value = value;
        }

        public virtual void SetMaxValue(float maxValue)
        {
            slider.maxValue = maxValue;
        }

        public virtual float GetValue()
        {
            return slider.value;
        }
        public virtual float GetMaxValue()
        {
            return slider.maxValue;
        }

    } 
}
