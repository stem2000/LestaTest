using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerLogic
{
    public class StatsBus : IStatsProvider
    {
        private PlayerStats _stats;
        public float Hp { get { return _stats.Hp; } }

        public StatsBus(PlayerStats stats) 
        {
            _stats = stats;
            _stats.Initialize();
        }

        public void ReduceHp(float damage)
        {
            _stats.ReduceHp(damage);
        }

        public void AddHp(float hp)
        {
            _stats.AddHp(hp);
        }
    }
}