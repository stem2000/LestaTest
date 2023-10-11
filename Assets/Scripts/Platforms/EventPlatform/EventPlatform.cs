using UnityEngine;
using UnityEngine.Events;
using PlayerLogic;

public class EventPlatform : MonoBehaviour
{
    [SerializeField] private UnityEvent _onLineTriggered;

    private bool _wasLineTriggered = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (!_wasLineTriggered)
            ReactToTrigger();
    }

    private void ReactToTrigger()
    {
        _wasLineTriggered = true;
        _onLineTriggered?.Invoke();
    }
}
