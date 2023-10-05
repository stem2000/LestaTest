using UnityEngine;

namespace Player
{
    public class WorldInteractor : MonoBehaviour, IWorldInteractionsProvider
    {
        bool IWorldInteractionsProvider.IsOnGround { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        private void OnCollisionEnter(Collision collision)
        {

        }

        private void OnCollisionExit(Collision collision)
        {

        }

        private void OnCollisionStay(Collision collision)
        {

        }
    }
}
