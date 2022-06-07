using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Currency;
using LooCast.UI.Panel;
using LooCast.UI.Value;

namespace LooCast.UI.Tab
{
    public class StatsTab : Tab
    {
        [SerializeField]
        private AttributePanel attributePanel;
        [SerializeField]
        private StatPanel[] statPanels;
        [SerializeField]
        private TokensValue tokensValue;
        [SerializeField]
        private CoinsValue coinsValue;
        [SerializeField]
        private InfoPanel infoPanel;
        [HideInInspector]
        public StatsListPanel statsListPanel;

        public void Initialize()
        {
            attributePanel.tokensValue = tokensValue;
            attributePanel.Initialize();
            foreach (StatPanel statPanel in statPanels)
            {
                statPanel.statsListPanel = statsListPanel;
                statPanel.coinsValue = coinsValue;
                statPanel.Initialize();
            }
            tokensValue.Initialize(Tokens.GetBalance());
            coinsValue.Initialize(Coins.GetBalance());
            infoPanel.Initialize();
        }

        public override void Show()
        {
            base.Show();
            Refresh();
        }

        public override void Hide()
        {
            base.Hide();
        }

        public void Refresh()
        {
            attributePanel.Refresh();
            foreach (StatPanel statPanel in statPanels)
            {
                statPanel.Refresh();
            }
            tokensValue.SetValue(Tokens.GetBalance());
            coinsValue.SetValue(Coins.GetBalance());
            infoPanel.Refresh();
        }
    } 
}
