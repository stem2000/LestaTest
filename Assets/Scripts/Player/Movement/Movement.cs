using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(PlayerBus), typeof(Rigidbody))]
    public class Movement : MonoBehaviour, IStateSwapHandler, IInitializedComponent
    {
        private IInputProvider _inputProvider;
        private Rigidbody _rigidbody;
        private UnityAction _currentMove;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _currentMove = Idle;
        }

        private void FixedUpdate()
        {
            _currentMove.Invoke();
        }

        private void Idle()
        {
            _rigidbody.velocity = Vector3.zero;
        }

        private void Run()
        {
            var velocity = _inputProvider.GetDirectionInput() * 5;

            velocity.y = _rigidbody.velocity.y;
            _rigidbody.AddForce(velocity, ForceMode.VelocityChange);
        }

        private void Jump()
        {
            _rigidbody.AddForce(_inputProvider.GetDirectionInput() * 10, ForceMode.Impulse);
        }

        public void HandleStateSwap(Type stateType)
        {
            if(stateType == typeof(IdleState))
                _currentMove = Idle;
            if(stateType == typeof(RunState))
                _currentMove = Run;
            if(stateType == typeof(JumpState))
                _currentMove = Jump;
        }

        public void Initialize(IComponentsProvider componentsProvider)
        {
            _inputProvider = componentsProvider.GetInputProvider();
        }
    }

}
