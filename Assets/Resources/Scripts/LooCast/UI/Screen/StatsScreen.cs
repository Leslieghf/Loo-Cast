using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.UI.Panel;
using LooCast.UI.Tab;
using LooCast.UI.Canvas;

namespace LooCast.UI.Screen
{
    public class StatsScreen : Screen
    {
        [SerializeField]
        private StatsTab[] statsTabs;
        public StatsListPanel statsListPanel;
        [SerializeField]
        private TabGroup tabGroup;

        public override void Initialize(InterfaceCanvas canvas)
        {
            isInitiallyVisible = false;
            isHideable = true;
            base.Initialize(canvas);
            foreach (StatsTab statsTab in statsTabs)
            {
                statsTab.statsListPanel = statsListPanel;
                statsTab.Initialize();
            }
            statsListPanel.Initialize();
            tabGroup.Initialize();
        }
    } 
}
