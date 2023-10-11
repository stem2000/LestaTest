using System;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerLogic
{
    public class WorldInteractionsBus : IWorldInteractionsProvider, IStateSwapHandler
    {
        public event UnityAction OnPlayerDeath;
        public bool IsOnGround { get { return GetOnGround(); } }

        private IWorldInteractionsProvider _worldInteractionsProvider;

        public WorldInteractionsBus(IWorldInteractionsProvider worldInteractionsProvider)
        {
            _worldInteractionsProvider = worldInteractionsProvider;
        }

        private bool GetOnGround()
        {
            if(_worldInteractionsProvider != null)
                return _worldInteractionsProvider.IsOnGround;
            return true;
        }

        public void HandleStateSwap(Type stateType)
        {
            if (stateType == typeof(DeathState))
                OnPlayerDeath?.Invoke();
        }
    }
}

