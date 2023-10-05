using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public interface IComponentsProvider
    {
        public IInputProvider GetInputProvider();
        public IStatsProvider GetStatsProvider();
        public IWorldInteractionsProvider GetWorldInteractionProvider();
    }
}
