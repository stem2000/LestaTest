using Player;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/StateMachine/States/FlyState")]
public class FlyState : State
{
    IWorldInteractionsProvider _worldInteractionsProvider;
    public override void Initialize(IComponentsProvider componentsProvider)
    {
        _worldInteractionsProvider = componentsProvider.GetWorldInteractionProvider();
    }

    public override bool WantSwapDown()
    {
        return _worldInteractionsProvider.IsOnGround;
    }

    public override bool WantSwapUp()
    {
        return !_worldInteractionsProvider.IsOnGround;
    }
}
