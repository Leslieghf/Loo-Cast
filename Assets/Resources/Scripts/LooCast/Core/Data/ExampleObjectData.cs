using UnityEngine;

namespace LooCast.Core.Data
{
    using LooCast.Data;

    [CreateAssetMenu(fileName = "ExampleObjectData", menuName = "Data/ExampleObjectData", order = 0)]
    public class ExampleObjectData : ObjectData
    {
        public FloatReference Data1;
        public FloatReference Data2;
        public FloatReference Data3;
    } 
}