using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LooCast.UI.Value
{
    public abstract class Value : MonoBehaviour
    {
        public Text Text;

        private void Start()
        {
            Refresh();
        }

        private void OnBecameVisible()
        {
            Refresh();
        }

        private void OnEnable()
        {
            Refresh();
        }

        public abstract void Refresh();
    } 
}
