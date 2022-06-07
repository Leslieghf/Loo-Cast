using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LooCast.UI.Bar
{
    public class EnergyBar : Bar
    {
        public Image sliderImage { get; protected set; }
        public Image borderImage { get; protected set; }

        public override void Initialize(float value, float maxValue)
        {
            base.Initialize(value, maxValue);
            sliderImage = transform.Find("SliderImage").GetComponent<Image>();
            borderImage = transform.Find("BorderImage").GetComponent<Image>();
        }

        public virtual void Initialize(float maxValue)
        {
            Initialize(maxValue, maxValue);
        }

        public bool isDepleted
        {
            get
            {
                return _isDepleted;
            }

            set
            {
                _isDepleted = value;
                if (_isDepleted)
                {
                    sliderImage.color = Color.yellow;
                }
                else
                {
                    sliderImage.color = Color.green;
                }
            }
        }
        protected bool _isDepleted = false;
    } 
}
