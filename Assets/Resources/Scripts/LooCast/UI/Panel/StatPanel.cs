using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Attribute.Stat;
using LooCast.UI.Button;
using LooCast.UI.Level;
using LooCast.UI.Value;

namespace LooCast.UI.Panel
{
    public class StatPanel : Panel
    {
        [SerializeField]
        private string statClassName;
        private Stat stat;
        [SerializeField]
        private StatLevel statLevel;
        [HideInInspector]
        public CoinsValue coinsValue;
        [HideInInspector]
        public StatsListPanel statsListPanel;
        private StatSetButton[] statSetButtons;

        public override void Initialize()
        {
            GetStat();
            statLevel.Initialize(stat, stat.GetLevel(), stat.GetMaxLevel());
            statSetButtons = GetComponentsInChildren<StatSetButton>(true);
            foreach (StatSetButton statSetButton in statSetButtons)
            {
                statSetButton.Initialize();
            }
        }

        public Stat GetStat()
        {
            if (stat == null)
            {
                stat = Stats.GetStat(statClassName);
                if (stat == null)
                {
                    throw new System.Exception("Could not get Stat Class by Class Name");
                }
            }
            return stat;
        }

        public override void Refresh()
        {
            statLevel.Refresh();
        }
    } 
}
