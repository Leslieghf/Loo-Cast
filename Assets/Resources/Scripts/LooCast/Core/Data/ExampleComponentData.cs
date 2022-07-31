using UnityEngine;

namespace LooCast.Core.Data
{
    [CreateAssetMenu(fileName = "ExampleComponentData", menuName = "Data/ExampleComponentData", order = 0)]
    public class ExampleComponentData : ComponentData
    {
        public FloatReference Data1;
        public FloatReference Data2;
        public FloatReference Data3;
    } 
}