using UnityEngine;

namespace LooCast.Core.Data.Runtime
{
    [CreateAssetMenu(fileName = "ExampleUniqueObjectRuntimeData", menuName = "Data/Runtime/ExampleUniqueObjectRuntimeData", order = 0)]
    public class ExampleUniqueObjectRuntimeData : UniqueObjectRuntimeData
    {
        public float RuntimeData1;
        public float RuntimeData2;
        public float RuntimeData3;
    } 
}