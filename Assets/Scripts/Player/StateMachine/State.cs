using PlayerLogic;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
{
    [SerializeField] protected List<State> _upperStates;
    protected IComponentsProvider _componentsProvider;

    public Type GetStateType()
    {
        return GetType();
    }

    public bool CanSwap(State countenderState)
    {
        foreach (var state in _upperStates)
            if (state.GetStateType() == countenderState.GetStateType())
                return false;
        return true;
    }

    public abstract bool WantSwapUp();
    public abstract bool WantSwapDown();
    public abstract void Initialize(IComponentsProvider componentsProvider);
}
