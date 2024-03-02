using UnityEngine;
using UnityEngine.Events;

namespace GameEventSystem
{
    [System.Serializable]
    public class CustomGameEvent : UnityEvent<Component, object> { }
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public CustomGameEvent Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(Component component, object score)
        {
            Response.Invoke(component, score);
        }

    }
}