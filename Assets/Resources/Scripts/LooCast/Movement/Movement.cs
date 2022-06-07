using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Util;
using UnityEngine.Events;

namespace LooCast.Movement
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public abstract class Movement : ExtendedMonoBehaviour, IMovement
    {
        public UnityEvent onMovementEnabled;
        public UnityEvent onMovementDisabled;
        protected float slownessMultiplier;
        protected bool isMovementEnabled;
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
                    onMovementEnabled.Invoke();
                }
                else
                {
                    onMovementDisabled.Invoke();
                }
                isMovementEnabled = value;
            }
        }
        protected float movementSpeed = 1.0f;
        protected new Rigidbody2D rigidbody;
        protected new Collider2D collider;

        private Vector3 PAUSE_currentVelocity;

        private void Start()
        {
            Initialize();
        }

        public virtual void Initialize()
        {
            onMovementEnabled = new UnityEvent();
            onMovementDisabled = new UnityEvent();
            slownessMultiplier = 1.0f;
            isMovementEnabled = true;
            rigidbody = GetComponent<Rigidbody2D>();
            collider = GetComponent<Collider2D>();
        }

        protected override void FixedCycle()
        {
            Accelerate();
        }

        public abstract void Accelerate();

        public virtual float GetSlownessMultiplier()
        {
            return slownessMultiplier;
        }

        public virtual void SetSlownessMultiplier(float slownessMultiplier)
        {
            this.slownessMultiplier = slownessMultiplier;
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
            return movementSpeed;
        }

        public void SetMovementSpeed(float movementSpeed)
        {
            this.movementSpeed = movementSpeed;
        }

        protected override void OnPause()
        {
            PAUSE_currentVelocity = rigidbody.velocity;
            rigidbody.velocity = Vector3.zero;
        }

        protected override void OnResume()
        {
            rigidbody.velocity = PAUSE_currentVelocity;
            PAUSE_currentVelocity = Vector3.zero;
        }
    } 
}
