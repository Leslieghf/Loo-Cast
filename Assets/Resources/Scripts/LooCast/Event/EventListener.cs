using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Event
{
    public class EventListener : MonoBehaviour
    {
        public Event Event;
        public UnityEvent Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    } 
}
