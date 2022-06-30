using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Currency;

namespace LooCast.UI.Value
{
    public class CoinsValue : Value
    {
        public Coins Coins;

        public override void Refresh()
        {
            if (Coins.ProposedBalanceChange.Value == 0)
            {
                Text.text = $"{Coins.Balance.Value}";
            }
            else if (Coins.ProposedBalanceChange.Value < 0)
            {
                if (Coins.Balance.Value + Coins.ProposedBalanceChange.Value < 0)
                {
                    Text.text = $"{Coins.Balance.Value}";
                }
                else
                {
                    Text.text = $"{Coins.Balance.Value}<color=#EB3B5A>{Coins.ProposedBalanceChange.Value}</color>";
                }
            }
            else if (Coins.ProposedBalanceChange.Value > 0)
            {
                Text.text = $"{Coins.Balance.Value}<color=#20BF6B>+{Coins.ProposedBalanceChange.Value}</color>";
            }
        }
    } 
}
