using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventPlatform : MonoBehaviour
{
    [SerializeField] private UnityEvent _onLineTriggered;

    private bool _wasLineTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!_wasLineTriggered)
            ReactToTrigger();
    }

    private void ReactToTrigger()
    {
        _wasLineTriggered = true;
        _onLineTriggered.Invoke();
    }
}
