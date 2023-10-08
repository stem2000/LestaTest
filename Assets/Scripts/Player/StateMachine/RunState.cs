using UnityEngine;

namespace PlayerLogic
{
    [CreateAssetMenu(menuName = "Scriptables/StateMachine/States/RunState")]
    public class RunState : State
    {
        private IInputProvider _inputProvider;

        public override void Initialize(IComponentsProvider componentsProvider)
        {
            _inputProvider = componentsProvider.GetInputProvider();
        }

        public override bool WantSwapDown()
        {
            if (_inputProvider.GetDirectionInput() == Vector3.zero)
                return true;
            return false;
        }

        public override bool WantSwapUp()
        {
            if(_inputProvider.GetDirectionInput() != Vector3.zero)
                return true;
            return false;
        }
    }
}

