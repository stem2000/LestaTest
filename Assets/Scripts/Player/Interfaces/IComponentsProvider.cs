using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerLogic
{
    public interface IComponentsProvider
    {
        public IInputProvider GetInputProvider();
        public IStatsManager GetStatsProvider();
        public IWorldInteractionsProvider GetWorldInteractionProvider();
    }
}
