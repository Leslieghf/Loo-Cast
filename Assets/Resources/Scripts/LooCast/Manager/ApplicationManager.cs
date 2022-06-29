using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Attribute;
using LooCast.UI.Screen;

namespace LooCast.Manager
{
    public class ApplicationManager : Manager
    {
        public static ApplicationManager Instance { get; private set; }

        [SerializeField] private LoadingScreen loadingScreen;
        [SerializeField] private InitializationSceneManager initializationSceneManager;

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

        private void Initialize()
        {
            DontDestroyOnLoad(this);

            //Initialize Initialization Scene
            initializationSceneManager.Initialize();

            //Load MainMenu Scene
            LoadScene("MainMenu");
        }

        private void LoadScene(string sceneIndex)
        {
            StartCoroutine(loadingScreen.LoadSceneAsynchronously(sceneIndex));
        }
    }
}
