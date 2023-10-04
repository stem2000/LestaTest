using UnityEngine;

namespace Player
{
    public interface IInitializedComponent
    {
        public void Initialize(IComponentsProvider componentsProvider);
    }
}
