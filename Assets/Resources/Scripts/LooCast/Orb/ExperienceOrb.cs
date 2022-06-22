using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Attribute.Stat;
using LooCast.Util;
using LooCast.Experience;
using LooCast.Sound;

namespace LooCast.Orb
{
    public class ExperienceOrb : ExtendedMonoBehaviour
    {
        public bool isMagnetized = false;
        public float magnetizedSpeedMultiplier;
        public float maxMagnetizedSpeed;
        [HideInInspector]
        public float magnetDuration;
        private float timerMagnetized = 0.0f;
        private float experience = 1.0f;
        private GameObject playerObject;
        private CircleCollider2D playerCollider;
        private Experience.Experience playerExperience;
        private GameSoundHandler soundHandler;
        private static float pickupRangeMultiplier;

        public void Magnetize(float duration)
        {
            isMagnetized = true;
            timerMagnetized = 0.0f;
            magnetDuration = duration;
        }

        public void Demagnetize()
        {
            isMagnetized = false;
            timerMagnetized = 0.0f;
        }

        public virtual void Initialize()
        {
            playerObject = GameObject.FindGameObjectWithTag("Player");
            playerExperience = playerObject.GetComponent<LooCast.Experience.Experience>();
            playerCollider = playerObject.GetComponent<CircleCollider2D>();
            soundHandler = GameObject.FindObjectOfType<GameSoundHandler>();
            pickupRangeMultiplier = ((MindStat)Stats.GetStat("MindStat")).RangeMultiplier;
            isVisible = true;
        }

        protected override void Cycle()
        {
            if (isVisible)
            {
                if (playerObject != null)
                {
                    if (isMagnetized)
                    {
                        timerMagnetized += Time.deltaTime;
                        if (timerMagnetized >= magnetDuration)
                        {
                            Demagnetize();
                        }
                    }

                    float dis = Vector3.Distance(playerObject.transform.position, transform.position);
                    if (dis <= playerCollider.radius)
                    {
                        playerExperience.AddExperience(GetExperience());
                        soundHandler.SoundExperience();
                        Kill();
                    }
                    else
                    {
                        float speed = 1 / Mathf.Pow(dis / pickupRangeMultiplier, 2) * Constants.INERTIAL_COEFFICIENT * 7.5f;
                        if (isMagnetized)
                        {
                            speed *= magnetizedSpeedMultiplier;
                            if (speed >= maxMagnetizedSpeed)
                            {
                                speed = maxMagnetizedSpeed;
                            }
                        }
                        speed = speed * Time.deltaTime * .5f;
                        transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, speed);
                    }
                }
            }
        }

        public void SetExperience(float experience)
        {
            this.experience = experience;
        }

        public float GetExperience()
        {
            return experience;
        }

        public void Kill()
        {
            Destroy(gameObject);
        }
    }  
}
