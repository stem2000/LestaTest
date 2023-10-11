using UnityEngine;

namespace PlayerLogic
{
    [CreateAssetMenu(menuName = "Scriptables/Stats/PlayerStats")]
    public class PlayerStats : ScriptableObject
    {
        [SerializeField] private Stat<float> _hp;

        public float Hp { get { return _hp.CurrentValue;} set { _hp.CurrentValue = value;} }

        public void Initialize()
        {
            _hp.Reset();
        }
    }
}
