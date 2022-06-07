using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LooCast.Util
{
    public class ScreenShake : ExtendedMonoBehaviour
    {
        private float shakeTimer;

        private float targetShakePower;
        private float shakePower;

        private float shakePowerFadeIn;
        private float shakePowerFadeOut;

        private bool isShaking;
        private bool isFadingIn;
        private bool isFadingOut;

        public void Initialize()
        {

        }

        protected override void Cycle()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                ShakeOnce(1.0f, 0.0f, 0.15f, 0.15f);
            }
        }

        private void LateUpdate()
        {
            if (isShaking)
            {
                if (isFadingIn)
                {
                    shakePower = Mathf.MoveTowards(shakePower, targetShakePower, shakePowerFadeIn * Time.deltaTime);
                    if (shakePower == targetShakePower)
                    {
                        isFadingIn = false;
                    }
                }

                if (isFadingOut)
                {
                    shakePower = Mathf.MoveTowards(shakePower, 0.0f, shakePowerFadeOut * Time.deltaTime);
                    if (shakePower == 0.0f)
                    {
                        isFadingOut = false;
                        isShaking = false;
                    }
                }

                float xAmount = UnityEngine.Random.Range(-1.0f, 1.0f) * shakePower;
                float yAmount = UnityEngine.Random.Range(-1.0f, 1.0f) * shakePower;

                transform.position += new Vector3(xAmount, yAmount, 0.0f);

                if (shakeTimer <= 0.0f && !isFadingIn)
                {
                    isFadingOut = true;
                }

                if (!isFadingIn && !isFadingOut)
                {
                    shakeTimer -= Time.deltaTime;
                }
            }
        }

        public void ShakeOnce(float power, float duration, float fadeInDuration, float fadeOutDuration)
        {
            targetShakePower = power;
            shakePower = 0.0f;

            shakeTimer = duration;

            shakePowerFadeIn = power / fadeInDuration;
            shakePowerFadeOut = power / fadeOutDuration;

            isShaking = true;
            isFadingIn = true;
            isFadingOut = false;
        }
    }
}
