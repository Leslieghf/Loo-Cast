using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LooCast.Indicator
{
    using Util;

    public class DamageIndicator : ExtendedMonoBehaviour
    {
        [SerializeField]
        private Text text;
        private float timer = 0.0f;
        private float animationTime;
        private Vector2 initialPosition;
        public Vector2 animationOffset;

        public void Initialize(float damage)
        {
            text.text = $"{(int)damage}";
            animationTime = Resources.Load<AnimationClip>("Animations/DamageIndicatorPopup").length;
            initialPosition = (transform as RectTransform).anchoredPosition;
        }

        protected override void Cycle()
        {
            timer += Time.deltaTime;
            if (timer >= animationTime)
            {
                Kill();
            }

            (transform as RectTransform).anchoredPosition = initialPosition + animationOffset;
        }

        private void Kill()
        {
            Destroy(gameObject);
        }
    } 
}
