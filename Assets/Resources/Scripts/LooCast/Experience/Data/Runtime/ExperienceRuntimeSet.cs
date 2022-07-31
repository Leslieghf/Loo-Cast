using UnityEngine;

namespace LooCast.Core.Data.Runtime
{
    using LooCast.Experience;

    [CreateAssetMenu(fileName = "ExampleComponentRuntimeSet", menuName = "Data/Runtime/ExampleComponentRuntimeSet", order = 0)]
    public class ExperienceRuntimeSet<T> : ComponentRuntimeSet<T> where T : Experience
    {

    } 
}