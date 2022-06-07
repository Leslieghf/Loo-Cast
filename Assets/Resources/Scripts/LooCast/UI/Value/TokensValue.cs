using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Currency;

namespace LooCast.UI.Value
{
    public class TokensValue : Value
    {
        public override void Initialize(int value, int minValue = 0)
        {
            base.Initialize(value, minValue);
            Tokens.onBalanceChanged.AddListener(Refresh);
            Refresh();
        }

        public override void Refresh()
        {
            base.SetValue(Tokens.GetBalance());
            base.Refresh();
        }

        public override void SetChange(int change)
        {
            base.SetChange(change);
            Refresh();
        }

        public override void SetValue(int value)
        {
            base.SetValue(value);
            Refresh();
        }
    } 
}
