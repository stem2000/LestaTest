using UnityEngine;
using System;

namespace Player
{
    public interface IStateSwapHandler 
    {
        public void HandleStateSwap(Type stateType);
    }
}

