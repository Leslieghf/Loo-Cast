using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Data
{
    [CreateAssetMenu(fileName = "StringVariable", menuName = "Data/StringVariable", order = 0)]
    public class StringVariable : ScriptableObject
    {
        [SerializeField] private string value;
        public string Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
                OnValueChanged.Invoke();
            }
        }
        public UnityEvent OnValueChanged;
    } 
}
