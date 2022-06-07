using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LooCast.UI
{
    public class VersionInfo : MonoBehaviour
    {
        private Text text;
        void Start()
        {
            text = GetComponent<Text>();
            text.text = $"Version: {Application.version}";
        }
    } 
}
