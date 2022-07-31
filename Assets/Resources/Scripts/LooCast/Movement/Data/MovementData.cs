using UnityEngine;

namespace LooCast.Movement.Data
{
    using LooCast.Core.Data;
    using LooCast.Data;

    public abstract class MovementData : Data
    {
        public FloatReference SlownessMultiplier;
        public BoolReference IsMovementEnabled;
        public FloatReference MovementSpeed;
    } 
}
