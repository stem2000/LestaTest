using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Scriptables/Stats/PlayerStats")]
    public class PlayerStats : ScriptableObject
    {
        [SerializeField] [Range(0,1)] private float _friction;
        [SerializeField] private float _runSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _flySpeed;
        [SerializeField] private float _maxFlySpeed;

        public float Friction { get { return _friction; } }
        public float RunSpeed { get { return _runSpeed; } }
        public float JumpForce { get { return _jumpForce; } }
        public float FlySpeed { get { return _flySpeed; } }
        public float FlyMaxSpeed { get { return _maxFlySpeed; } }
    }
}
