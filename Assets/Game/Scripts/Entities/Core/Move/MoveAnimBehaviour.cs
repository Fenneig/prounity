using UnityEngine;

namespace Game.Entities
{
    public sealed class MoveAnimBehaviour : IGameEntityInit, IGameEntityTick
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private Animator _animator;
        
        public void Init(IGameEntity entity)
        {
            _animator = entity.GetAnimator();
        }

        public void Tick(IGameEntity entity, float deltaTime)
        {
            _animator.SetBool(IsMoving, entity.IsMoving());
        }
    }
}