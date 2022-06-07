using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LooCast.UI.Screen;

namespace LooCast.UI.Button
{
    public class LoadSceneButton : Button
    {
        public string sceneName;

        public override void OnClick()
        {
            GameObject.FindObjectOfType<LoadingScreen>().LoadScene(sceneName);
        }
    } 
}
