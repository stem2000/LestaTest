using Player;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/StateMachine/States/JumpState")]
public class JumpState : State
{
    private IInputProvider _inputProvider;
    private IWorldInteractionsProvider _worldInterationsProvider;
    public override void Initialize(IComponentsProvider componentsProvider)
    {
        _inputProvider = componentsProvider.GetInputProvider();
        _worldInterationsProvider = componentsProvider.GetWorldInteractionProvider();
    }

    public override bool WantSwapDown()
    {
        return !_inputProvider.GetJumpInput();
    }

    public override bool WantSwapUp()
    {       
        return _inputProvider.GetJumpInput() && _worldInterationsProvider.IsOnGround;
    }
}
