using UnityEngine;

namespace Game
{
    public sealed class GravityComponentView : MonoBehaviour
    {
        private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
        private static readonly int IsFalling = Animator.StringToHash("IsFalling");
        
        private Animator _animator;
        
        private GroundedComponent _groundedComponent;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            
            _groundedComponent = GetComponentInChildren<GroundedComponent>();
        }
        private void OnEnable() => _groundedComponent.OnGrounded += OnGrounded;

        private void OnDisable() => _groundedComponent.OnGrounded -= OnGrounded;

        private void OnGrounded(bool isGround)
        {
            _animator.SetBool(IsGrounded, isGround);
            _animator.SetBool(IsFalling, !isGround);    
        }
    }
}