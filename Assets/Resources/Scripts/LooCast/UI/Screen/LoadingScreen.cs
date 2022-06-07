using System.Collections;
using System.Collections.Generic;
using LooCast.UI.Canvas;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LooCast.UI.Screen
{
    public class LoadingScreen : Screen
    {
        public UnityEngine.UI.Slider loadingBar;
        [HideInInspector]
        public bool loading = false;

        public override void Initialize(InterfaceCanvas canvas)
        {
            isInitiallyVisible = false;
            isHideable = true;
            base.Initialize(canvas);
        }

        public void LoadScene(string sceneIndex)
        {
            if (!loading)
            {
                loading = true;
                SetVisibility(true);
                canvas.screenStack.Clear();
                StartCoroutine(LoadAsynchronously(sceneIndex));
            }
        }

        public IEnumerator LoadSceneAsynchronously(string sceneIndex)
        {
            if (!loading)
            {
                loading = true;
                SetVisibility(true);
                canvas.screenStack.Clear();
                yield return StartCoroutine(LoadAsynchronously(sceneIndex));
            }
        }

        private IEnumerator LoadAsynchronously(string sceneIndex)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                loadingBar.value = progress;
                yield return null;
            }
        }
    } 
}
