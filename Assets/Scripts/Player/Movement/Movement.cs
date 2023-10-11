using System;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerLogic
{
    [RequireComponent(typeof(Rigidbody), typeof(IInitializableComponent))]
    public class Movement : MonoBehaviour, IStateSwapHandler, IInitializableComponent
    {
        [SerializeField] private float _groundDrag;
        [SerializeField] private float _runSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _flySpeed;
        [SerializeField] private float _downForce;

        private IInputProvider _inputProvider;
        private IWorldInteractionsProvider _worldInteractor;
        private Rigidbody _rb;
        private UnityAction _currentMove;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            UpdateDrag();
        }

        private void FixedUpdate()
        {
            _currentMove?.Invoke();
        }

        private void UpdateDrag()
        {
            if(_worldInteractor.IsOnGround)
                _rb.drag = _groundDrag;
            else
                _rb.drag = 0;
        }

        private void Idle()
        {
            Run();
        }

        private void Jump()
        {
            _rb.AddRelativeForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        private void Run()
        {
            var velocity = _inputProvider.GetDirectionInput() * _runSpeed;

            _rb.AddRelativeForce(velocity, ForceMode.VelocityChange);
            ControlHorizontalSpeed(_runSpeed);
        }

        private void ControlHorizontalSpeed(float maxSpeed)
        {
            var velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

            if(velocity.magnitude > maxSpeed)
            {
                var limVelocity = velocity.normalized * maxSpeed;
                _rb.velocity = new Vector3(limVelocity.x, _rb.velocity.y, limVelocity.z);
            }
        }

        private void Fly()
        {
            var velocity = _inputProvider.GetDirectionInput() * _flySpeed;
            
            velocity.y = -_downForce;

            _rb.AddRelativeForce(velocity, ForceMode.VelocityChange);
            ControlHorizontalSpeed(_flySpeed);
        }

        private void MoveInertial()
        {
            return;
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
            if(stateType == typeof(DeathState))
                _currentMove = MoveInertial;
        }

        public void Initialize(IComponentsProvider componentsProvider)
        {
            _inputProvider = componentsProvider.GetInputProvider();
            _worldInteractor = componentsProvider.GetWorldInteractionProvider();
        }
    }

}
