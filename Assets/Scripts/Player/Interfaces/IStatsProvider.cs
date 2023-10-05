using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public interface IStatsProvider
    {
        public float GetFriction();
        public float GetRunSpeed();
        public float GetJumpForce();
    }
}

