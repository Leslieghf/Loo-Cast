using UnityEngine;

namespace LooCast.Data
{
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "Data/BoolVariable", order = 0)]
    public class BoolVariable : ScriptableObject
    {
        public bool Value;
    } 
}
