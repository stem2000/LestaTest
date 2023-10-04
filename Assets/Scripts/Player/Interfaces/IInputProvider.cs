using UnityEngine;

namespace Player
{
    public interface IInputProvider
    {
        public Vector3 GetDirectionInput();
        public bool GetJumpInput();
        public Vector3 GetRotationInput();
    }
}

