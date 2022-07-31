using UnityEngine;

namespace LooCast.Core.Data
{
    [CreateAssetMenu(fileName = "ExampleUniqueComponentData", menuName = "Data/Example/ExampleUniqueComponentData", order = 0)]
    public class ExampleUniqueComponentData : UniqueComponentData
    {
        public FloatReference Data1;
        public FloatReference Data2;
        public FloatReference Data3;
    } 
}