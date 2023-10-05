using Player;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/StateMachine/States/JumpState")]
public class JumpState : State
{
    private IInputProvider _inputProvider;
    public override void Initialize(IComponentsProvider componentsProvider)
    {
        _inputProvider = componentsProvider.GetInputProvider();
    }

    public override bool WantSwapDown()
    {
        return !_inputProvider.GetJumpInput();
    }

    public override bool WantSwapUp()
    {       
        return _inputProvider.GetJumpInput();
    }
}
