using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Scriptables/Stats/PlayerStats")]
    public class PlayerStats : ScriptableObject
    {
        [SerializeField] private float _friction = 1f;
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _jumpForce = 20f;

        public float Friction { get { return _friction; } }
        public float MoveSpeed { get { return _moveSpeed; } }
        public float JumpForce { get { return _jumpForce; } }
    }
}
