using GeneralLogic;
using UnityEngine;

namespace PlayerLogic
{
    [RequireComponent(typeof(PlayerBus))]
    public class Player : MonoBehaviour, IDamageable
    {
        public void GetDamage(float damage)
        {

        }
    }
}

