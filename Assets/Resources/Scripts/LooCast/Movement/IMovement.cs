using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Movement
{
    public interface IMovement
    {
        public abstract void Accelerate();

        public abstract float GetSlownessMultiplier();

        public abstract void SetSlownessMultiplier(float slownessMultiplier);

        public abstract bool GetMovementEnabled();

        public abstract void SetMovementEnabled(bool isMovementEnabled);

        public abstract float GetMovementSpeed();

        public abstract void SetMovementSpeed(float movementSpeed);
    } 
}
