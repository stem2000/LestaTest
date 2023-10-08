using UnityEngine;

namespace PlayerLogic
{
    public interface IInitializableComponent
    {
        public void Initialize(IComponentsProvider componentsProvider);
    }
}
