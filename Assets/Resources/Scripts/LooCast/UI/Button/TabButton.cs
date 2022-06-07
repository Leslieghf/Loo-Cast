using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using LooCast.UI.Tab;

namespace LooCast.UI.Button
{
    public class TabButton : Button
    {
        public TabGroup tabGroup;

        public UnityEvent onTabSelected;
        public UnityEvent onTabDeselected;

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnClick()
        {
            tabGroup.OnTabSelected(this);
            Select();
        }

        public override void Select()
        {
            base.Select();
            if (onTabSelected != null)
            {
                onTabSelected.Invoke();
            }
        }

        public virtual void Deselect()
        {
            if (onTabDeselected != null)
            {
                onTabDeselected.Invoke();
            }
        }
    } 
}
