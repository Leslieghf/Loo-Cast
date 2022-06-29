using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Movement
{
    using Manager;
    using UI.Bar;
    using Util;
    using Attribute.Stat;

    public class PlayerMovement : Movement
    {
        public Stats Stats;

        public UnityEvent onStartAccelerating;
        public UnityEvent onStopAccelerating;
        public EnergyBar energyBar;


        public float baseEnergy { get; protected set; }
        public float energy 
        { 
            get
            {
                return energyBar.GetValue();
            }
            set
            {
                energyBar.SetValue(value);
            }
        }


        public float maxEnergy 
        {
            get
            {
                return energyBar.GetMaxValue();
            }
            protected set
            {
                energyBar.SetMaxValue(value);
            }
        }


        public float baseEnergyConsumption { get; protected set; }
        public float energyConsumption { get; protected set; }


        public float baseEnergyGeneration { get; protected set; }
        public float energyGeneration { get; protected set; }


        private bool isUsingEnergy;
        private bool isEnergyDepleted;

        public override void Initialize()
        {
            base.Initialize();

            baseEnergy = 500.0f;
            baseEnergyConsumption = 1.0f;
            baseEnergyGeneration = 1.0f;

            energyBar = FindObjectOfType<EnergyBar>();
            energyBar.Initialize(baseEnergy * Stats.EnergyMultiplier);
            energyConsumption = baseEnergyConsumption * Stats.EnergyConsumptionMultiplier;
            energyGeneration = baseEnergyGeneration * Stats.EnergyRegenerationMultiplier;

            isUsingEnergy = false;
        }

        protected override void Cycle()
        {
            base.Cycle();
            if (!isUsingEnergy)
            {
                if (energy + energyGeneration >= maxEnergy)
                {
                    energy = maxEnergy;
                    isEnergyDepleted = false;
                    energyBar.isDepleted = false;
                }
                else
                {
                    energy += energyGeneration;
                }
            }
            if (isUsingEnergy && !isEnergyDepleted)
            {
                energyBar.sliderImage.color = Color.green;
                if (energy - energyConsumption <= 0.0f)
                {
                    energy = 0.0f;
                    isEnergyDepleted = true;
                    energyBar.isDepleted = true;
                    GameSceneManager.Instance.SoundHandler.SoundCooldown();
                }
                else
                {
                    energy -= energyConsumption;
                }
            }
        }

        public override void Accelerate()
        {
            isUsingEnergy = false;
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

            if ((axis[0] == 0 && axis[1] == 0) || isEnergyDepleted)
            {
                onStopAccelerating.Invoke();
            }
            else
            {
                onStartAccelerating.Invoke();
                if (!isEnergyDepleted)
                {
                    isUsingEnergy = true;
                }
            }

            if (!isEnergyDepleted)
            {
                rigidbody.AddForce(new Vector2(axis[0], axis[1]).normalized * movementSpeed * Stats.MovementSpeedMultiplier * Constants.INERTIAL_COEFFICIENT); 
            }
        }
    } 
}
