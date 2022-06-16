using UnityEngine;

namespace LooCast.Data
{
    [CreateAssetMenu(fileName = "StringVariable", menuName = "Data/StringVariable", order = 0)]
    public class StringVariable : ScriptableObject
    {
        public string Value;
    } 
}
