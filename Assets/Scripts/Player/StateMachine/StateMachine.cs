using UnityEngine.Events;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerLogic
{
    [CreateAssetMenu(menuName = "Scriptables/StateMachine/StateMachine")]
    public class StateMachine : ScriptableObject
    {
        private UnityEvent<Type> OnStateWasSwapped;

        [SerializeField] List<State> _states;

        private State _currentState;
        private bool _stateWasSwapped = false;

        public void Initialize(IComponentsProvider componentsProvider)
        {
            InitializeStates(componentsProvider);
            _currentState = CreateInstance<IdleState>();
            OnStateWasSwapped = new UnityEvent<Type>();
        }

        private void InitializeStates(IComponentsProvider componentsProvider)
        {
            foreach(var state in _states)
            {
                state.Initialize(componentsProvider);
            }
        }

        public void SwapState()
        {
            for (int i = 0; i < _states.Count; i++)
            {
                if (CanSwapStates(_states[i], _currentState))
                {
                    _currentState = _states[i];
                    _stateWasSwapped = true;                  
                }
            }

            if (_stateWasSwapped)
                OnStateWasSwapped?.Invoke(_currentState.GetStateType());
            _stateWasSwapped = false;
        }

        private bool CanSwapStates(State downState, State upState)
        {
            if(downState.CanSwap(upState) && downState.WantSwapUp() || downState.WantSwapUp() && upState.WantSwapDown())
                return true;
            return false;
        }

        public void AddStateSwapHandler(IStateSwapHandler handler)
        {
            OnStateWasSwapped.AddListener(handler.HandleStateSwap);
        }

    }
}