using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.UI.Panel
{
    public abstract class Panel : MonoBehaviour
    {
        public abstract void Initialize();

        public abstract void Refresh();
    } 
}
