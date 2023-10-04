using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class InputBus : IInputProvider
    {
        private IInputProvider _inputProvider;

        public InputBus(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        public Vector3 GetDirectionInput()
        {
            if (_inputProvider != null)
                return _inputProvider.GetDirectionInput();
            else
                return Vector3.zero;
        }

        public bool GetJumpInput()
        {
            if (_inputProvider != null)
                return _inputProvider.GetJumpInput();
            else
                return false;
        }

        public Vector3 GetRotationInput()
        {
            if (_inputProvider != null)
                return _inputProvider.GetRotationInput();
            else
                return Vector3.zero;
        }
    }
}
