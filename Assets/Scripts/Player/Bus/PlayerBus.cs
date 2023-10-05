using System;
using UnityEngine;

namespace Player
{
    public class PlayerBus : MonoBehaviour, IComponentsProvider
    {
        [SerializeField] private StateMachine _stateMachine;
        [SerializeField] private PlayerStats _stats;

        private IInputProvider _inputProvider;
        private IStatsProvider _statsProvider;
        private IWorldInteractionsProvider _worldInteractionsProvider;


        private void Awake()
        {
            InitializeComponents();
            SubscribeComponentsToStateMachine();
        }

        private void Update()
        {
            _stateMachine.SwapState();
        }

        private void InitializeComponents()
        {
            _inputProvider = new InputBus(GetComponent<IInputProvider>());
            _statsProvider = new StatsBus(_stats);
            _worldInteractionsProvider = new WorldInteractionsBus(GetComponent<IWorldInteractionsProvider>());

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

        public IStatsProvider GetStatsProvider()
        {
            return _statsProvider;
        }

        public IWorldInteractionsProvider GetWorldInteractionProvider()
        {
            return _worldInteractionsProvider;
        }
    }
}

