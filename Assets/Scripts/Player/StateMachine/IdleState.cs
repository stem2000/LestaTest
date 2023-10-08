using UnityEngine;

namespace PlayerLogic
{
    [CreateAssetMenu(menuName = "Scriptables/StateMachine/States/IdleState")]
    public class IdleState : State
    {
        public override void Initialize(IComponentsProvider componentsProvider)
        {
            return;
        }

        public override bool WantSwapDown()
        {
            return false;
        }

        public override bool WantSwapUp()
        {
            return true;
        }
    }
}


