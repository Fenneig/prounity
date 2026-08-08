using UnityEngine;

namespace Game
{
    public sealed class JumpComponentView : MonoBehaviour
    {
        private static readonly int IsJump = Animator.StringToHash("Jump");

        [SerializeField] private JumpComponent _jumpComponent;
        [SerializeField] private Animator _animator;
        
        private void OnEnable() => _jumpComponent.OnJump += Jump;
        
        private void OnDisable() => _jumpComponent.OnJump -= Jump;
        
        private void Jump() => _animator.SetTrigger(IsJump);
    }
}