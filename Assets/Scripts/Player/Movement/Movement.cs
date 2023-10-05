using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(PlayerBus), typeof(Rigidbody))]
    public class Movement : MonoBehaviour, IStateSwapHandler, IInitializedComponent
    {
        private IInputProvider _inputProvider;
        private IStatsProvider _statsProvider;

        private Rigidbody _rigidbody;
        private UnityAction _currentMove;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _currentMove?.Invoke();
        }

        private void Idle()
        {
            Run();
        }

        private void Run()
        {
            var velocity = _inputProvider.GetDirectionInput() * _statsProvider.RunSpeed;
            var friction = _statsProvider.Friction;

            _rigidbody.AddForce(velocity, ForceMode.VelocityChange);
            _rigidbody.AddForce(-_rigidbody.velocity.x * friction, 0f, -_rigidbody.velocity.z * friction , ForceMode.VelocityChange);
        }

        private void Jump()
        {
            _rigidbody.AddForce(Vector3.up * _statsProvider.JumpForce, ForceMode.VelocityChange);
        }

        public void HandleStateSwap(Type stateType)
        {
            if(stateType == typeof(IdleState))
                _currentMove = Idle;
            if(stateType == typeof(RunState))
                _currentMove = Run;
            if(stateType == typeof(JumpState))
                Jump();
        }

        public void Initialize(IComponentsProvider componentsProvider)
        {
            _inputProvider = componentsProvider.GetInputProvider();
            _statsProvider = componentsProvider.GetStatsProvider();
        }
    }

}
