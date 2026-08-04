using UnityEngine;

namespace Game
{
    public sealed class MoveComponentView : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        
        private Animator _animator;

        private MoveRequestComponent _moveRequestComponent;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            
            _moveRequestComponent = GetComponentInChildren<MoveRequestComponent>();
        }
        
        private void Update() => _animator.SetBool(IsMoving, _moveRequestComponent.IsMoving);
    }
}