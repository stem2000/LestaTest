using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerLogic
{
    public class SoundController : MonoBehaviour, IStateSwapHandler
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _runClip;
        [SerializeField] private AudioClip _JumpClip;

        private bool _wasStateChanged = false;
        private Type _currentStateType;

        public void HandleStateSwap(Type stateType)
        {
            if (stateType == typeof(RunState))
            {
                SetupRunClip();
                _currentStateType = typeof(RunState);
            }
            else if (stateType == typeof(JumpState))
            {
                SetupJumpClip();
                _currentStateType = typeof(JumpState);
            }
            else
            {
                if(_currentStateType == typeof(RunState))
                    _audioSource.Stop();
            }
        }

        private void SetupRunClip()
        {
            _audioSource.clip = _runClip;
            _audioSource.loop = true;
            _wasStateChanged = true;
        }

        private void SetupJumpClip()
        {
            _audioSource.clip = _JumpClip;
            _audioSource.loop = false;
            _wasStateChanged = true;
        }

        private void Update()
        {
            if (_wasStateChanged)
            {
                _audioSource.Play();
                _wasStateChanged = false;
            }
        }
    }
}
