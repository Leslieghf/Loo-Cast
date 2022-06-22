using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Util;
using LooCast.Movement;
using LooCast.Attribute.Stat;

namespace LooCast.AOE
{
    public class FreezeZone : ExtendedMonoBehaviour
    {
        private Animator animator;
        private Vector2 targetPos;
        private float movementSpeed = 100.0f;
        private bool isMovingToTarget = true;
        private bool isDeploying = false;
        private bool isDeployed = false;
        private bool isRetracting = false;
        private bool isRetracted = false;
        private float deployTimer = 0.0f;
        private float deployTime;
        private float lifetime = 0.0f;
        private float maxLifetime;
        private float retractTimer = 0.0f;
        private float retractTime;
        private float freezeAmount;
        private float freezeRadiusMultiplier;
        private Vector3 baseScale = new Vector3(10.0f, 10.0f, 10.0f);
        [HideInInspector]
        public float animationScale;

        public void Initialize(Vector2 targetPos, float freezeAmount, float freezeRadiusMultiplier, float freezeLifetime)
        {
            this.targetPos = targetPos;
            this.freezeAmount = freezeAmount;
            this.freezeRadiusMultiplier = freezeRadiusMultiplier;
            maxLifetime = freezeLifetime;

            animator = GetComponent<Animator>();

            deployTime = Resources.Load<AnimationClip>("Animations/AOEZonePopup").length;
            retractTime = Resources.Load<AnimationClip>("Animations/AOEZoneDisappear").length;

            baseScale *= Stats.ProjectileSizeMultiplier;
            movementSpeed *= Stats.ProjectileSpeedMultiplier;
            
            transform.localScale = baseScale * 0.1f; 
        }

        protected override void Cycle()
        {
            if (isMovingToTarget)
            {
                float step = movementSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPos, step);

                if (Vector3.Distance(transform.position, targetPos) <= step)
                {
                    isMovingToTarget = false;
                    isDeploying = true;
                    Deploy();
                }
            }

            if (isDeploying)
            {
                transform.localScale = baseScale * (animationScale * freezeRadiusMultiplier);
                deployTimer += Time.deltaTime;
                if (deployTimer >= deployTime)
                {
                    isDeploying = false;
                    isDeployed = true;
                }
            }

            if (isDeployed)
            {
                lifetime += Time.deltaTime;
                if (lifetime >= maxLifetime)
                {
                    isDeployed = false;
                    isRetracting = true;
                    Retract();
                }
            }

            if (isRetracting)
            {
                transform.localScale = baseScale * (animationScale * freezeRadiusMultiplier);
                retractTimer += Time.deltaTime;
                if (retractTimer >= retractTime)
                {
                    isRetracting = false;
                    isRetracted = true;
                }
            }

            if (isRetracted)
            {
                Kill();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.GetComponent<Movement.Movement>().SetSlownessMultiplier(freezeAmount);
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.GetComponent<Movement.Movement>().SetSlownessMultiplier(freezeAmount);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.GetComponent<Movement.Movement>().SetSlownessMultiplier(1.0f);
            }
        }

        private void Deploy()
        {
            animator.Play("AOEZonePopup");
        }

        private void Retract()
        {
            animator.Play("AOEZoneDisappear");
        }

        private void Kill()
        {
            Destroy(gameObject);
        }
    } 
}
