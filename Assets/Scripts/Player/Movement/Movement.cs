using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(Rigidbody), typeof(IInitializedComponent))]
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

        private void Jump()
        {
            _rigidbody.AddForce(Vector3.up * _statsProvider.JumpForce, ForceMode.VelocityChange);
        }

        private void Run()
        {
            var velocity = _inputProvider.GetDirectionInput() * _statsProvider.RunSpeed;
            var friction = _statsProvider.Friction;

            _rigidbody.AddForce(velocity, ForceMode.VelocityChange);
            _rigidbody.AddForce(-_rigidbody.velocity.x * friction, 0f, -_rigidbody.velocity.z * friction, ForceMode.VelocityChange);
        }

        private void Fly()
        {
            var velocity = _inputProvider.GetDirectionInput() * _statsProvider.FlySpeed;
            var xzBodyVelocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
   
            if((xzBodyVelocity + velocity).magnitude < _statsProvider.MaxFlySpeed)
                _rigidbody.AddForce(velocity, ForceMode.VelocityChange);
        }
 
        public void HandleStateSwap(Type stateType)
        {
            if(stateType == typeof(IdleState))
                _currentMove = Idle;
            if(stateType == typeof(RunState))
                _currentMove = Run;
            if(stateType == typeof(JumpState))
                Jump();
            if(stateType == typeof(FlyState))
                _currentMove = Fly;
        }

        public void Initialize(IComponentsProvider componentsProvider)
        {
            _inputProvider = componentsProvider.GetInputProvider();
            _statsProvider = componentsProvider.GetStatsProvider();
        }
    }

}
