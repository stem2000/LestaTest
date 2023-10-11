using UnityEngine.Events;

namespace PlayerLogic
{
    public interface IWorldInteractionsProvider
    {
        public event UnityAction OnPlayerDeath;
        public bool IsOnGround { get;}
    }
}
