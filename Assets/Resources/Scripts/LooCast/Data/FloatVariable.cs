using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Data
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "Data/FloatVariable", order = 0)]
    public class FloatVariable : ScriptableObject
    {
        [SerializeField] private float value;
        public float Value
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
