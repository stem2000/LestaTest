using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerLogic 
{ 
    public class InputController : MonoBehaviour, IInputProvider
    {
        protected PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.Enable();
        }


        public Vector3 GetDirectionInput()
        {
            var inputDirection2D = _playerInput.Gameplay.Move.ReadValue<Vector2>();
            var inputDirection3D = new Vector3(inputDirection2D.x, 0f, inputDirection2D.y);

            return inputDirection3D;
        }

        public bool GetJumpInput()
        {
            return _playerInput.Gameplay.Jump.IsPressed();
        }

        public Vector2 GetMouseDeltaInput()
        {
            var rotation = _playerInput.Gameplay.Rotate.ReadValue<Vector2>();
            return rotation;
        }
    }
}

