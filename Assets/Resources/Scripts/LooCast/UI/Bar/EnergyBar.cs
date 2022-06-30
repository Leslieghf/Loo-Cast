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

        private void Start()
        {
            sliderImage = transform.Find("SliderImage").GetComponent<Image>();
            borderImage = transform.Find("BorderImage").GetComponent<Image>();
        }

        public override void Refresh()
        {
            
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
                    sliderImage.color = Color.yellow;
                }
                else
                {
                    sliderImage.color = Color.green;
                }
            }
        }
        protected bool isDepleted = false;
    } 
}
