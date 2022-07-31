using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Orb
{
    using Core;
    using Attribute.Stat;
    using Util;
    using Sound;

    public class MagnetOrb : ExtendedMonoBehaviour
    {
        public Stats Stats;

        private GameObject playerObject;
        private CircleCollider2D playerCollider;
        private GameSoundHandler soundHandler;
        [SerializeField]
        private float magnetDuration;
        private static float pickupRangeMultiplier;

        public virtual void Initialize()
        {
            playerObject = GameObject.FindGameObjectWithTag("Player");
            playerCollider = playerObject.GetComponent<CircleCollider2D>();
            soundHandler = FindObjectOfType<GameSoundHandler>();
            pickupRangeMultiplier = Stats.RangeMultiplier;
        }

        protected override void OnPauseableUpdate()
        {
            if (playerObject.transform != null)
            {
                float dis = Vector3.Distance(playerObject.transform.position, transform.position);
                if (dis <= 50.0f)
                {
                    if (dis <= playerCollider.radius)
                    {
                        soundHandler.SoundExperience();
                        foreach (ExperienceOrb xpOrb in FindObjectsOfType<ExperienceOrb>())
                        {
                            xpOrb.Magnetize(magnetDuration);
                        }
                        Kill();
                    }
                    float speed = 1 / Mathf.Pow(dis / pickupRangeMultiplier, 2) * Constants.INERTIAL_COEFFICIENT * 7.5f;
                    speed = speed * Time.deltaTime * .5f;
                    transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, speed);
                }
            }
        }

        public void Kill()
        {
            Destroy(gameObject);
        }
    }  
}
