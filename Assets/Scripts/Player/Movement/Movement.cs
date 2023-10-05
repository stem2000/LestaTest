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
            _currentMove = Idle;
        }

        private void FixedUpdate()
        {
            _currentMove.Invoke();
        }

        private void Idle()
        {
            Run();
        }

        private void Run()
        {
            var velocity = _inputProvider.GetDirectionInput() * _statsProvider.GetRunSpeed();
            var friction = _statsProvider.GetFriction();

            _rigidbody.AddForce(velocity, ForceMode.VelocityChange);
            _rigidbody.AddForce(-_rigidbody.velocity.x * friction, 0f, -_rigidbody.velocity.z * friction, ForceMode.VelocityChange);
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
            _statsProvider = componentsProvider.GetStatsProvider();
        }
    }

}
