using PlayerLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/StateMachine/States/DeathState")]
public class DeathState : State
{
    private IStatsManager _statsManager;
    public override void Initialize(IComponentsProvider componentsProvider)
    {
        _statsManager = componentsProvider.GetStatsProvider();
    }

    public override bool WantSwapDown()
    {
        return false;
    }

    public override bool WantSwapUp()
    {
        if (_statsManager.Hp <= 0)
            return true;
        return false;
    }
}
