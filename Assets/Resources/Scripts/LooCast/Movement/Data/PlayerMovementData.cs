using UnityEngine;

namespace LooCast.Movement.Data
{
    using LooCast.Data;

    public abstract class PlayerMovementData : MovementData
    {
        public FloatReference BaseEnergy;
        public FloatReference BaseEnergyConsumption;
        public FloatReference BaseEnergyGeneration;
    } 
}
