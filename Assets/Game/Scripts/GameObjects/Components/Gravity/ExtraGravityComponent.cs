using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class ExtraGravityComponent : MonoBehaviour
    {
        private const float FALLING_THRESHOLD = -.1f;
        
        [SerializeField]
        private float _gravity = -7f;
        
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_rigidbody.linearVelocity.y < FALLING_THRESHOLD)
                _rigidbody.linearVelocity += new Vector2(0, _gravity * Time.fixedDeltaTime);
        }
    }
}