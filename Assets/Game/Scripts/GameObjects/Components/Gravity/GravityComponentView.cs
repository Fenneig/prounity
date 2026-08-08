using UnityEngine;

namespace Game
{
    public sealed class GravityComponentView : MonoBehaviour
    {
        private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
        private static readonly int IsFalling = Animator.StringToHash("IsFalling");
        private const float FALLING_THRESHOLD = -.1f;

        [SerializeField] private GroundedComponent _groundedComponent;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Animator _animator;

        private void OnEnable() => _groundedComponent.OnGrounded += OnGrounded;

        private void OnDisable() => _groundedComponent.OnGrounded -= OnGrounded;

        private void OnGrounded(bool isGround) => _animator.SetBool(IsGrounded, isGround);

        private void FixedUpdate()
        {
            _animator.SetBool(
                IsFalling,
                !_groundedComponent.IsGrounded &&
                _rigidbody.linearVelocity.y < FALLING_THRESHOLD);
        }
    }
}