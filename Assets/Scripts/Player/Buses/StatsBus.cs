using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerLogic
{
    public class StatsBus : IStatsManager
    {
        private PlayerStats _stats;

        public event UnityAction<float> OnHpChanged;

        public float Hp { get { return _stats.Hp; } }

        public StatsBus(PlayerStats stats) 
        {
            _stats = stats;
            _stats.Initialize();
        }

        public void ReduceHp(float damage)
        {
            _stats.Hp -= damage;
            OnHpChanged?.Invoke(_stats.Hp);
        }

        public void AddHp(float hp)
        {
            _stats.Hp += hp;
            OnHpChanged?.Invoke(_stats.Hp);
        }
    }
}