using UnityEngine;
using GeneralLogic;
using UnityEngine.Events;
using System;
using System.Collections;

namespace PlayerLogic
{
    [RequireComponent(typeof(IComponentsProvider))]
    public class WorldInteractor : MonoBehaviour, IWorldInteractionsProvider, IInitializableComponent, IDamageable, IStateSwapHandler
    {
        public event UnityAction OnPlayerDeath;
        bool IWorldInteractionsProvider.IsOnGround { get { return _grounded;} }

        private IStatsManager _statsProvider;
        private bool _grounded;


        private void OnCollisionExit(Collision collision)
        {
            _grounded = false;
        }

        private void OnCollisionStay(Collision collision)
        {
            foreach(var contact in collision.contacts)
                if (Vector3.Angle(contact.normal, Vector3.up) < 45)
                    _grounded = true;
        }

        public void Initialize(IComponentsProvider componentsProvider)
        {
            _statsProvider = componentsProvider.GetStatsProvider();
        }

        public void MakeDamage(float damage)
        {
            _statsProvider.ReduceHp(damage);
        }

        public void HandleStateSwap(Type stateType)
        {
            if(stateType == typeof(DeathState))
                OnPlayerDeath?.Invoke();
        }
    }
}
