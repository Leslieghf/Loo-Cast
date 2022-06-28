using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Data
{
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "Data/BoolVariable", order = 0)]
    public class BoolVariable : ScriptableObject
    {
        [SerializeField] private bool value;
        public bool Value
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
