using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LooCast.UI.Bar
{
    using LooCast.Movement.Data;
    using LooCast.Movement.Data.Runtime;

    public class EnergyBar : Bar
    {
        public Image SliderImage { get; protected set; }
        public Image BorderImage { get; protected set; }
        public PlayerMovementData PlayerMovementData;
        public PlayerMovementRuntimeData PlayerMovementRuntimeData;

        private void Start()
        {
            SliderImage = transform.Find("SliderImage").GetComponent<Image>();
            BorderImage = transform.Find("BorderImage").GetComponent<Image>();
        }

        public override void Refresh()
        {
            Slider.minValue = 0.0f;
            Slider.maxValue = PlayerMovementData.MaxEnergy.Value;
            Slider.value = PlayerMovementRuntimeData.CurrentEnergy.Value;
        }

        public bool IsDepleted
        {
            get
            {
                return isDepleted;
            }

            set
            {
                isDepleted = value;
                if (isDepleted)
                {
                    SliderImage.color = Color.yellow;
                }
                else
                {
                    SliderImage.color = Color.green;
                }
            }
        }
        protected bool isDepleted = false;
    } 
}
