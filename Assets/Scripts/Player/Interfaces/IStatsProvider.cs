using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerLogic
{
    public interface IStatsProvider
    {
        public void ReduceHp(float damage);
        public void AddHp(float hp);
        public float Hp { get;}
    }
}

