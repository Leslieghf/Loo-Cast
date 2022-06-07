using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Currency
{
    public static class Coins
    {
        public static UnityEvent onBalanceChanged = new UnityEvent();
        public static readonly string name = "Coins";

        public static void SetBalance(int balance)
        { 
            PlayerPrefs.SetInt($"{name}.balance", balance);
            onBalanceChanged.Invoke();
        }

        public static int GetBalance()
        {
            int balance;
            if (!PlayerPrefs.HasKey($"{name}.balance"))
            {
                SetBalance(0);
            }
            balance = PlayerPrefs.GetInt($"{name}.balance");
            return balance;
        }
    } 
}
