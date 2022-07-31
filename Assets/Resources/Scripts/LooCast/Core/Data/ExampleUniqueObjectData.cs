using UnityEngine;

namespace LooCast.Core.Data
{
    [CreateAssetMenu(fileName = "ExampleUniqueObjectData", menuName = "Data/ExampleUniqueObjectData", order = 0)]
    public class ExampleUniqueObjectData : UniqueObjectData
    {
        public FloatReference Data1;
        public FloatReference Data2;
        public FloatReference Data3;
    } 
}