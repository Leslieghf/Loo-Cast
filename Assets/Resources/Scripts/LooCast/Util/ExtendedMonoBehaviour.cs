using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Util
{
    public abstract class ExtendedMonoBehaviour : MonoBehaviour
    {
        private bool isPaused = false;
        protected bool isVisible = false;

        private void Update()
        {
            if (!isPaused)
            {
                Cycle();
            }
            UninterruptedCycle();
        }

        private void FixedUpdate()
        {
            if (!isPaused)
            {
                FixedCycle();
            }
        }

        private void OnBecameInvisible()
        {
            isVisible = false;
        }

        private void OnBecameVisible()
        {
            isVisible = true;
        }

        protected virtual void Cycle()
        {

        }

        protected virtual void UninterruptedCycle()
        {

        }

        protected virtual void FixedCycle()
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
            isPaused = true;
        }

        public void Resume()
        {
            OnResume();
            isPaused = false;
        }

        public bool IsPaused()
        {
            return isPaused;
        }
    } 
}
