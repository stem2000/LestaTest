using UnityEngine;

namespace PlayerLogic
{
    [CreateAssetMenu(menuName = "Scriptables/Stats/PlayerStats")]
    public class PlayerStats : ScriptableObject, IStatsProvider
    {
        [SerializeField] private Stat<float> _hp;

        public float Hp { get { return _hp.CurrentValue;} }

        public void Initialize()
        {
            _hp.Reset();
        }

        public void ReduceHp(float damage)
        {
            _hp.CurrentValue -= damage;
        }

        public void AddHp(float hp)
        {
            _hp.CurrentValue += hp;
        }
    }
}
