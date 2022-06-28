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
                onValueChanged.Invoke();
            }
        }
        [SerializeField] private UnityEvent onValueChanged;
    } 
}
