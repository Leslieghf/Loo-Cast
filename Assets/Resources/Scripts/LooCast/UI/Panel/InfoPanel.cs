using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LooCast.UI.Panel
{
    public class InfoPanel : Panel
    {
        [SerializeField]
        private Text infoText;

        public override void Initialize()
        {

        }

        public override void Refresh()
        {

        }

        public Text GetText()
        {
            return infoText;
        }
    } 
}
