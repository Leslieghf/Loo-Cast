using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.UI.Canvas;
using LooCast.Sound;

namespace LooCast.Manager
{
    public class MainMenuSceneManager : SceneManager
    {
        public static MainMenuSceneManager Instance { get; private set; }

        [SerializeField]
        private MainMenuCanvas canvas;
        public MainMenuCanvas Canvas { get { return canvas; } }

        [SerializeField]
        private MenuSoundHandler soundHandler;
        public MenuSoundHandler SoundHandler { get { return soundHandler; } }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            Initialize();
        }


        public void Initialize()
        {
            canvas.Initialize();
            soundHandler.Initialize();
        }
    }
}
