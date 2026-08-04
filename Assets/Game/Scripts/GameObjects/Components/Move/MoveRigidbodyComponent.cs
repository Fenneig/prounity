using UnityEngine;

namespace Game
{
    public class MoveRigidbodyComponent : MonoBehaviour, IMoveComponent
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _speed;

        public void Move(Vector2 direction)
        {
            float targetVelocityX = direction.x * _speed;

            _rigidbody.linearVelocityX = Mathf.MoveTowards(
                _rigidbody.linearVelocityX,
                targetVelocityX,
                _speed
            );
        }
    }
}