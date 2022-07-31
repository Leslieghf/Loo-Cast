using UnityEngine;

namespace LooCast.Movement.Data.Runtime
{
    using LooCast.Core.Data.Runtime;

    [CreateAssetMenu(fileName = "PlayerMovementRuntimeData", menuName = "Data/Movement/PlayerMovementRuntimeData", order = 0)]
    public sealed class PlayerMovementRuntimeData : UniqueComponentRuntimeData
    {
        public float CurrentEnergy;
        public float EnergyConsumption;
        public float EnergyGeneration;
        public bool IsUsingEnergy;
        public bool IsEnergyDepleted;
    }
}
