using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Movement
{
    using Core;
    using Data;

    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public abstract class Movement : Component, IMovement
    {
        public MovementData Data;

        public UnityEvent OnMovementEnabled { get; protected set; }
        public UnityEvent OnMovementDisabled { get; protected set; }
        public float SlownessMultiplier { get; protected set; }
        public bool IsMovementEnabled 
        { 
            get
            {
                return isMovementEnabled;
            }

            protected set
            {
                if (value)
                {
                    OnMovementEnabled.Invoke();
                }
                else
                {
                    OnMovementDisabled.Invoke();
                }
                isMovementEnabled = value;
            }
        }
        protected bool isMovementEnabled;
        public float MovementSpeed { get; protected set; }
        public Rigidbody2D Rigidbody { get; protected set; }
        public Collider2D Collider { get; protected set; }

        private Vector3 PAUSE_currentVelocity;

        private void Start()
        {
            Initialize(Data);
        }

        public void Initialize(MovementData data)
        {
            OnMovementEnabled = new UnityEvent();
            OnMovementDisabled = new UnityEvent();
            SlownessMultiplier = data.SlownessMultiplier.Value;
            IsMovementEnabled = data.IsMovementEnabled.Value;
            MovementSpeed = data.MovementSpeed.Value;
            Rigidbody = GetComponent<Rigidbody2D>();
            Collider = GetComponent<Collider2D>();
        }

        protected override void OnPauseableFixedUpdate()
        {
            Accelerate();
        }

        public abstract void Accelerate();

        public virtual float GetSlownessMultiplier()
        {
            return SlownessMultiplier;
        }

        public virtual void SetSlownessMultiplier(float slownessMultiplier)
        {
            this.SlownessMultiplier = slownessMultiplier;
        }

        public virtual bool GetMovementEnabled()
        {
            return isMovementEnabled;
        }

        public virtual void SetMovementEnabled(bool isMovementEnabled)
        {
            this.isMovementEnabled = isMovementEnabled;
        }

        public float GetMovementSpeed()
        {
            return MovementSpeed;
        }

        public void SetMovementSpeed(float movementSpeed)
        {
            this.MovementSpeed = movementSpeed;
        }

        protected override void OnPause()
        {
            PAUSE_currentVelocity = Rigidbody.velocity;
            Rigidbody.velocity = Vector3.zero;
        }

        protected override void OnResume()
        {
            Rigidbody.velocity = PAUSE_currentVelocity;
            PAUSE_currentVelocity = Vector3.zero;
        }
    } 
}
