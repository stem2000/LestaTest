using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class StatsBus : IStatsProvider
    {
        private PlayerStats _stats;

        public StatsBus(PlayerStats stats) 
        {
            _stats = stats;
        }

        public float GetFriction()
        {
            return _stats.Friction;
        }

        public float GetJumpForce()
        {
            return _stats.JumpForce;
        }

        public float GetRunSpeed()
        {
            return _stats.MoveSpeed;
        }
    }
}