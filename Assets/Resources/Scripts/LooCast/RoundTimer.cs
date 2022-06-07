using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LooCast.Util;

namespace LooCast
{
    public class RoundTimer : ExtendedMonoBehaviour
    {
        [HideInInspector]
        public Text text;

        private float timer = 0.0f;

        private void Start()
        {
            text = GetComponent<Text>();
        }

        protected override void Cycle()
        {
            timer += Time.deltaTime;

            float minutes = Mathf.FloorToInt(timer / 60);
            float seconds = Mathf.FloorToInt(timer % 60);
            float milliseconds = Mathf.FloorToInt((timer * 1000) % 1000);

            text.text = $"{Mathf.FloorToInt(minutes / 10)}{Mathf.FloorToInt(minutes % 10)}:{Mathf.FloorToInt(seconds / 10)}{Mathf.FloorToInt(seconds % 10)}.{Mathf.FloorToInt(milliseconds / 100)}{Mathf.FloorToInt((milliseconds % 100) / 10)}{Mathf.FloorToInt((milliseconds % 100) % 10)}";
        }
    }

}