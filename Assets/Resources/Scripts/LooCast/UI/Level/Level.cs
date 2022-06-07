using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LooCast.UI.Level
{
    public abstract class Level : MonoBehaviour
    {
        protected Text text;
        protected int value;
        protected int maxValue;

        /// <summary>
        /// Refresh after initializing!
        /// </summary>
        public virtual void Initialize(int value, int maxValue)
        {
            text = gameObject.GetComponent<Text>();
            this.value = value;
            this.maxValue = maxValue;
        }

        public virtual void SetValue(int value)
        {
            this.value = value;
        }

        public virtual void SetMaxValue(int maxValue)
        {
            this.maxValue = maxValue;
        }

        public virtual void Refresh()
        {
            text.text = $"{value}/{maxValue}";
        }
    } 
}
