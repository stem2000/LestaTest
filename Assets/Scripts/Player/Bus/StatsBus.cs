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
    }
}