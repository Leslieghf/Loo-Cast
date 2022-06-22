using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LooCast.Manager
{
    using UI.Canvas;
    using Util;
    using Sound;
    using Spawner;
    using Background;
    using Player;
    using Station;
    using Generator;
    using Data.Runtime;

    public class GameSceneManager : SceneManager
    {
        public static GameSceneManager Instance { get; private set; }

        public static bool IsPaused { get; private set; }
        private static ExtendedMonoBehaviour[] pauseables;

        [SerializeField]
        private GameCanvas gameCanvas;
        public GameCanvas GameCanvas { get { return gameCanvas; } }

        [SerializeField]
        private WorldSpaceCanvas worldSpaceCanvas;
        public WorldSpaceCanvas WorldSpaceCanvas { get { return worldSpaceCanvas; } }

        [SerializeField]
        private Background background;
        public Background Background { get { return background; } }

        [SerializeField]
        private GameSoundHandler soundHandler;
        public GameSoundHandler SoundHandler { get { return soundHandler; } }

        [SerializeField]
        private Player player;
        public Player Player { get { return player; } }

        [SerializeField]
        private ScreenShake screenShake;
        public ScreenShake ScreenShake { get { return screenShake; } }

        [SerializeField]
        private Generators generators;
        public Generators Generators { get { return generators; } }

        [SerializeField]
        private StationRuntimeSet stationRuntimeSet;

        [SerializeField]
        private EnemyRuntimeSet enemyRuntimeSet;


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
            stationRuntimeSet.Items.Clear();
            enemyRuntimeSet.Items.Clear();

            IsPaused = false;
            worldSpaceCanvas.Initialize();
            background.Initialize();
            soundHandler.Initialize();
            screenShake.Initialize();
            gameCanvas.Initialize();
            generators.Initialize();

            Resume();
        }

        public static void Pause()
        {
            if (!IsPaused)
            {
                IsPaused = true;
                pauseables = FindObjectsOfType<ExtendedMonoBehaviour>();
                foreach (ExtendedMonoBehaviour pauseable in pauseables)
                {
                    pauseable.Pause();
                }
            }
        }

        public static void Resume()
        {
            if (IsPaused)
            {
                IsPaused = false;
                pauseables = FindObjectsOfType<ExtendedMonoBehaviour>();
                foreach (ExtendedMonoBehaviour pauseable in pauseables)
                {
                    pauseable.Resume();
                }
            }
        }

        public static void TogglePause()
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
