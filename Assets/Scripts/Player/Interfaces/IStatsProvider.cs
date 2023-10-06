using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public interface IStatsProvider
    {
        public float Friction { get;}
        public float RunSpeed { get;}
        public float JumpForce { get;}
        public float FlySpeed { get;}
        public float MaxFlySpeed { get; }
    }
}

