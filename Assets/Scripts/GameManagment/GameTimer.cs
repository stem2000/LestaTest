using System;
using UnityEngine;

[Serializable]
public class GameTimer : MonoBehaviour
{
    [SerializeField] private float _gameTime = 0f;
    public float GameTime { get{ return _gameTime; } }
    private bool _isCountingActivated = false;

    private void Update()
    {
        if(_isCountingActivated)
            _gameTime += Time.deltaTime;
    }

    public void StopTimer()
    {
        _isCountingActivated = false;
    }

    public void StartTimer()
    {
        _gameTime = 0f;
        _isCountingActivated = true;
    }
}
