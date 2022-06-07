using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LooCast.UI.Value
{
    public abstract class Value : MonoBehaviour
    {
        protected Text text;
        protected int value;
        protected int minValue;
        protected int change;

        /// <summary>
        /// Refresh after initializing!
        /// </summary>
        public virtual void Initialize(int value, int minValue = 0)
        {
            text = gameObject.GetComponent<Text>();
            this.value = value;
            this.minValue = minValue;
        }

        public virtual void SetValue(int value)
        {
            this.value = value;
        }

        public virtual void SetChange(int change)
        {
            this.change = change;
        }

        public virtual void Refresh()
        {
            if (change == 0)
            {
                text.text = $"{value}";
            }
            else if (change < 0)
            {
                if (value + change < minValue)
                {
                    text.text = $"{value}";
                }
                else
                {
                    text.text = $"{value}<color=#EB3B5A>{change}</color>";
                }
            }
            else if (change > 0)
            {
                text.text = $"{value}<color=#20BF6B>+{change}</color>";
            }
        }
    } 
}
