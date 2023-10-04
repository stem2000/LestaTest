using System;
using UnityEngine;

namespace Player
{
    public class PlayerBus : MonoBehaviour, IComponentsProvider
    {
        [SerializeField] private StateMachine _stateMachine;
        private IInputProvider _inputProvider;

        private void Awake()
        {
            InitializeComponents();
            SubscribeComponentsToStateMachine();
        }

        private void Update()
        {
            _stateMachine.SwapState();
        }

        private void FixedUpdate()
        {

        }

        private void InitializeComponents()
        {
            _inputProvider = GetComponent<IInputProvider>();
            _stateMachine.Initialize(this);
            foreach(var component in GetComponents<IInitializedComponent>())
                component.Initialize(this);
        }

        private void SubscribeComponentsToStateMachine()
        {
            foreach(var handler in GetComponents<IStateSwapHandler>())
                _stateMachine.AddStateSwapHandler(handler);
                
        }

        public IInputProvider GetInputProvider()
        {
            return _inputProvider;
        }


    }
}

