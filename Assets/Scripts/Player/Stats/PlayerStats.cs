using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Scriptables/Stats/PlayerStats")]
    public class PlayerStats : ScriptableObject
    {
        [SerializeField] [Range(0,1)] private float _friction = 1f;
        [SerializeField] private float _runSpeed = 10f;
        [SerializeField] private float _jumpForce = 20f;

        public float Friction { get { return _friction; } }
        public float MoveSpeed { get { return _runSpeed; } }
        public float JumpForce { get { return _jumpForce; } }
    }
}
