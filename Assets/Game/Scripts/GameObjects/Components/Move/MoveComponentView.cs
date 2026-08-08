using UnityEngine;

namespace Game
{
    public sealed class MoveComponentView : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        [SerializeField] private MoveRequestComponent _moveRequestComponent;
        [SerializeField] private Animator _animator;

        private void Update() => _animator.SetBool(IsMoving, _moveRequestComponent.IsMoving);
    }
}