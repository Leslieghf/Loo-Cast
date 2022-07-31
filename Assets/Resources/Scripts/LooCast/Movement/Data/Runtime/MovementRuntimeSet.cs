using UnityEngine;

namespace LooCast.Movement.Data.Runtime
{
    using LooCast.Core.Data.Runtime;

    [CreateAssetMenu(fileName = "MovementRuntimeSet", menuName = "Data/Runtime/MovementRuntimeSet", order = 0)]
    public class MovementRuntimeSet<T> : ComponentRuntimeSet<T> where T : Movement
    {

    } 
}