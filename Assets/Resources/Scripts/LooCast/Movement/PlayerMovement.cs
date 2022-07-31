using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Movement
{
    using Manager;
    using Data;
    using Data.Runtime;
    using Util;
    using Attribute.Stat;

    public class PlayerMovement : Movement
    {
        public Stats Stats;

        public UnityEvent OnStartAccelerating;
        public UnityEvent OnStopAccelerating;

        public PlayerMovementData Data; //Incorrectly hides stuff
        public PlayerMovementRuntimeData RuntimeData;

        private void Start()
        {
            BaseEnergy = 500.0f;
            BaseEnergyConsumption = 1.0f;
            BaseEnergyGeneration = 1.0f;

            EnergyConsumption = BaseEnergyConsumption * Stats.EnergyConsumptionMultiplier;
            EnergyGeneration = BaseEnergyGeneration * Stats.EnergyRegenerationMultiplier;

            IsUsingEnergy = false;
        }

        protected override void OnPauseableUpdate()
        {
            base.OnPauseableUpdate();
            if (!IsUsingEnergy)
            {
                if (CurrentEnergy + EnergyGeneration >= MaxEnergy)
                {
                    CurrentEnergy = MaxEnergy;
                    IsEnergyDepleted = false;
                }
                else
                {
                    CurrentEnergy += EnergyGeneration;
                }
            }
            if (IsUsingEnergy && !IsEnergyDepleted)
            {
                if (CurrentEnergy - EnergyConsumption <= 0.0f)
                {
                    CurrentEnergy = 0.0f;
                    IsEnergyDepleted = true;
                    GameSceneManager.Instance.SoundHandler.SoundCooldown();
                }
                else
                {
                    CurrentEnergy -= EnergyConsumption;
                }
            }
        }

        public override void Accelerate()
        {
            IsUsingEnergy = false;
            float[] axis = new float[2];
            if (Input.touchCount > 0)
            {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position, Camera.MonoOrStereoscopicEye.Mono);
                Vector2 direction = touchPosition - (Vector2)transform.position;
                axis[0] = direction.x;
                axis[1] = direction.y;
            }
            else if (Input.GetMouseButton(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
                Vector2 direction = mousePosition - (Vector2)transform.position;
                axis[0] = direction.x;
                axis[1] = direction.y;
            }
            else
            {
                axis[0] = Input.GetAxis("Horizontal");
                axis[1] = Input.GetAxis("Vertical");
            }

            if ((axis[0] == 0 && axis[1] == 0) || IsEnergyDepleted)
            {
                OnStopAccelerating.Invoke();
            }
            else
            {
                OnStartAccelerating.Invoke();
                if (!IsEnergyDepleted)
                {
                    IsUsingEnergy = true;
                }
            }

            if (!IsEnergyDepleted)
            {
                Rigidbody.AddForce(new Vector2(axis[0], axis[1]).normalized * MovementSpeed * Stats.MovementSpeedMultiplier * Constants.INERTIAL_COEFFICIENT); 
            }
        }
    } 
}
