using UnityEngine;
using System;

namespace PlayerLogic
{
    public interface IStateSwapHandler 
    {
        public void HandleStateSwap(Type stateType);
    }
}

