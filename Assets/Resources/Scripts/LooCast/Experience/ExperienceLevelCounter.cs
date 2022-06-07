using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LooCast.Experience
{
    public class ExperienceLevelCounter : MonoBehaviour
    {
        private Text levelCounter;

        private void Start()
        {
            levelCounter = GetComponent<Text>();
        }

        public void SetLevel(int level)
        {
            levelCounter.text = $"Lvl {level}";
        }
    } 
}
