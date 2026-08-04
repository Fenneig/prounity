using UnityEngine;

namespace Game
{
    public sealed class JumpComponent : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 12f;
        private Rigidbody2D _rigidbody2D;

        private void Awake() => _rigidbody2D = GetComponent<Rigidbody2D>();

        public void Jump() => _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}