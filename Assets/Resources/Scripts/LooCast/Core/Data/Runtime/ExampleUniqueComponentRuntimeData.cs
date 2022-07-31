using UnityEngine;

namespace LooCast.Core.Data.Runtime
{
    [CreateAssetMenu(fileName = "ExampleUniqueComponentRuntimeData", menuName = "Data/Example/Runtime/ExampleUniqueComponentRuntimeData", order = 0)]
    public sealed class ExampleUniqueComponentRuntimeData : UniqueComponentRuntimeData
    {
        public float RuntimeData1;
        public float RuntimeData2;
        public float RuntimeData3;
    } 
}