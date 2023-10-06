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

        float IStatsProvider.Friction { get {return _stats.Friction;} }
        float IStatsProvider.RunSpeed { get { return _stats.RunSpeed; } }
        float IStatsProvider.JumpForce { get { return _stats.JumpForce; } }
        float IStatsProvider.FlySpeed { get { return _stats.FlySpeed;} }
        float IStatsProvider.MaxFlySpeed { get { return _stats.FlyMaxSpeed; } }
    }
}