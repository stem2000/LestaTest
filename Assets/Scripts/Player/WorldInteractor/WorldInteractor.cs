using UnityEngine;
using GeneralLogic;
using UnityEngine.Events;

namespace PlayerLogic
{
    [RequireComponent(typeof(IComponentsProvider))]
    public class WorldInteractor : MonoBehaviour, IWorldInteractionsProvider, IInitializableComponent, IDamageable
    {
        bool IWorldInteractionsProvider.IsOnGround { get { return _grounded;} }

        private bool _grounded;


        private void OnCollisionExit(Collision collision)
        {
            _grounded = false;
        }

        private void OnCollisionStay(Collision collision)
        {
            foreach (var contact in collision.contacts)
                if (Vector3.Angle(contact.normal, Vector3.up) < 45)
                    _grounded = true;
        }

        public void Initialize(IComponentsProvider componentsProvider)
        {

        }

        public void GetDamage(float damage)
        {

        }

    }
}
