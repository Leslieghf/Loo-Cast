using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Manager;
using LooCast.Util;
using LooCast.UI.Canvas;

namespace LooCast.UI.Screen
{
    public abstract class Screen : ExtendedMonoBehaviour
    {
        protected bool isHideable;
        protected bool isInitiallyVisible;
        protected List<GameObject> hideableObjects;
        protected InterfaceCanvas canvas;
        public int priority = -1;

        public virtual void Initialize(InterfaceCanvas canvas)
        {
            isVisible = isInitiallyVisible;
            this.canvas = canvas;

            if (!isHideable)
            {
                if (!isInitiallyVisible)
                {
                    throw new System.Exception("Screen is initialized as initially invisible and unhideable!");
                }
            }

            if (isInitiallyVisible)
            {
                transform.SetAsLastSibling();
                if (canvas.screenStack.Count > 0)
                {
                    throw new System.Exception("More than one screen initially visible!");
                }
                canvas.screenStack.Push(this);
            }

            if (isHideable)
            {
                hideableObjects = new List<GameObject>();
                for (int i = 0; i < transform.childCount; i++)
                {
                    hideableObjects.Add(transform.GetChild(i).gameObject);
                }
            }
        }

        public virtual void Refresh()
        {

        }

        public virtual void SetVisibility(bool show)
        {
            if (!show)
            {
                if (!isHideable)
                {
                    return;
                }

                if (canvas.screenStack.Peek().Equals(this))
                {
                    canvas.screenStack.Pop();
                    if (canvas.screenStack.Count == 0)
                    {
                        GameSceneManager.Resume();
                    }
                }
                else
                {
                    return;
                }
            }

            if (show)
            {
                if (priority == -1)
                {
                    throw new System.Exception("Priority is not set!");
                }

                foreach (Screen screen in canvas.screenStack)
                {
                    if (priority < screen.priority)
                    {
                        return;
                    }
                }
                canvas.screenStack.Push(this);
                transform.SetAsLastSibling();
            }

            isVisible = show;
            foreach (GameObject obj in hideableObjects)
            {
                obj.SetActive(show);
            }

            if (isVisible)
            {
                Refresh();
            }
        }

        public virtual Stack<Screen> GetScreenStack()
        {
            return canvas.screenStack;
        }

        public virtual bool GetVisibility()
        {
            return isVisible;
        }

        public virtual void ToggleVisibility()
        {
            SetVisibility(!isVisible);
        }
    } 
}
