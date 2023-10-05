using UnityEngine;
using UnityEngine.InputSystem;

namespace Player 
{ 
    public class InputController : MonoBehaviour, IInputProvider
    {
        protected PlayerInput _playerInput;
        private bool _isJumpTriggered = false;

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
            return _playerInput.Gameplay.Jump.triggered;
        }

        public Vector2 GetRotationInput()
        {
            var rotation = _playerInput.Gameplay.Rotate.ReadValue<Vector2>();
            return new Vector3();
        }
    }
}

