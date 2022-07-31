using UnityEngine;

namespace LooCast.Core
{
    public abstract class ExtendedMonoBehaviour : MonoBehaviour
    {
        public bool IsPaused { get; private set; }
        public bool IsVisible;

        private void Awake()
        {
            IsPaused = false;
            IsVisible = false;
        }
        private void Update()
        {
            if (!IsPaused)
            {
                OnPauseableUpdate();
            }
        }
        private void FixedUpdate()
        {
            if (!IsPaused)
            {
                OnPauseableFixedUpdate();
            }
        }
        private void OnBecameInvisible()
        {
            IsVisible = false;
        }
        private void OnBecameVisible()
        {
            IsVisible = true;
        }

        protected virtual void OnPauseableUpdate()
        {

        }
        protected virtual void OnPauseableFixedUpdate()
        {

        }
        protected virtual void OnPause()
        {

        }
        protected virtual void OnResume()
        {

        }

        public void Pause()
        {
            OnPause();
            IsPaused = true;
        }
        public void Resume()
        {
            OnResume();
            IsPaused = false;
        }
    } 
}
