using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerLogic
{
    public interface IStatsManager
    {
        public event UnityAction<float> OnHpChanged;
        public void ReduceHp(float damage);
        public void AddHp(float hp);
        public float Hp { get;}
    }
}

