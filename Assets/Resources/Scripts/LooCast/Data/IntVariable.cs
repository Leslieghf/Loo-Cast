using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Data
{
    [CreateAssetMenu(fileName = "IntVariable", menuName = "Data/IntVariable", order = 0)]
    public class IntVariable : ScriptableObject
    {
        [SerializeField] private int value;
        public int Value
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
