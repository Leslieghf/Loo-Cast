using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.UI.Canvas;

namespace LooCast.Manager
{
    public class InitializationSceneManager : SceneManager
    {
        [SerializeField]
        private MainMenuCanvas canvas;

        public void Initialize()
        {
            canvas.Initialize();
        }
    } 
}
