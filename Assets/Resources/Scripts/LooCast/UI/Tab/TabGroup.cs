using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.UI.Button;

namespace LooCast.UI.Tab
{
    public class TabGroup : MonoBehaviour
    {
        public List<Button.TabButton> tabButtons;
        public Button.TabButton selectedTabButton;

        public virtual void Initialize()
        {
            foreach (Button.TabButton tabButton in tabButtons)
            {
                tabButton.Initialize();
            }
        }

        public void OnTabSelected(Button.TabButton button)
        {
            if (selectedTabButton != null)
            {
                selectedTabButton.Deselect();
            }

            button.Select();
            selectedTabButton = button;
            ResetTabs();
        }

        public void ResetTabs()
        {
            foreach (Button.TabButton tabButton in tabButtons)
            {
                if (selectedTabButton != null && tabButton == selectedTabButton)
                {
                    continue;
                }
                tabButton.Deselect();
            }
        }
    } 
}
