using UnityEngine;

namespace Player
{
    public class WorldInteractor : MonoBehaviour, IWorldInteractionsProvider
    {
        bool IWorldInteractionsProvider.IsOnGround { get { return _grounded;}  }

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
    }
}
