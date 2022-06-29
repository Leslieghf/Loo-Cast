using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.UI.Tab
{
    public class Tab : MonoBehaviour
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    } 
}