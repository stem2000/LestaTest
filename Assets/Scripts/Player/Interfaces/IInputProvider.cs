using UnityEngine;

namespace PlayerLogic
{
    public interface IInputProvider
    {
        public Vector3 GetDirectionInput();
        public bool GetJumpInput();
        public Vector2 GetMouseDeltaInput();
    }
}

