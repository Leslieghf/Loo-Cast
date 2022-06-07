using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LooCast.UI.Slider
{
    public abstract class Slider : MonoBehaviour
    {
        protected UnityEngine.UI.Slider slider;

        public virtual void Initialize()
        {
            slider = GetComponent<UnityEngine.UI.Slider>();
            slider.onValueChanged.AddListener(OnValueChanged);
        }

        protected virtual void OnValueChanged(float value)
        {
            SetValue(value);
        }

        public virtual float GetValue()
        {
            return slider.value;
        }

        public virtual void SetValue(float value)
        {
            slider.value = value;
        }

        public abstract void Refresh();
    } 
}
