using UnityEngine;

namespace PlayerLogic
{
    public class WorldInteractionsBus : IWorldInteractionsProvider
    {
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
    }
}

