using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Currency;

namespace LooCast.UI.Value
{
    public class TokensValue : Value
    {
        public Tokens Tokens;

        public override void Refresh()
        {
            if (Tokens.ProposedBalanceChange.Value == 0)
            {
                Text.text = $"{Tokens.Balance.Value}";
            }
            else if (Tokens.ProposedBalanceChange.Value < 0)
            {
                if (Tokens.Balance.Value + Tokens.ProposedBalanceChange.Value < 0)
                {
                    Text.text = $"{Tokens.Balance.Value}";
                }
                else
                {
                    Text.text = $"{Tokens.Balance.Value}<color=#EB3B5A>{Tokens.ProposedBalanceChange.Value}</color>";
                }
            }
            else if (Tokens.ProposedBalanceChange.Value > 0)
            {
                Text.text = $"{Tokens.Balance.Value}<color=#20BF6B>+{Tokens.ProposedBalanceChange.Value}</color>";
            }
        }
    } 
}
