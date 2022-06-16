using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Event
{
    [CreateAssetMenu(fileName = "Event", menuName = "Data/Event", order = 0)]
    public class Event : ScriptableObject
    {
        private List<EventListener> listeners = new List<EventListener>();

        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(EventListener listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void UnregisterListener(EventListener listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }
    } 
}
