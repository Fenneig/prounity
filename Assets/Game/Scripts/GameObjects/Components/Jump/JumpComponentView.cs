using UnityEngine;

namespace Game
{
    public sealed class JumpComponentView : MonoBehaviour
    {
        private static readonly int IsJump = Animator.StringToHash("Jump");

        private JumpRequestComponent _jumpRequestComponent;
        private Animator _animator;

        private void Awake()
        {
            _jumpRequestComponent = GetComponent<JumpRequestComponent>();
            _animator = GetComponentInChildren<Animator>();
        }
        
        private void OnEnable() => _jumpRequestComponent.OnJump += Jump;
        
        private void OnDisable() => _jumpRequestComponent.OnJump -= Jump;
        
        private void Jump() => _animator.SetTrigger(IsJump);
    }
}