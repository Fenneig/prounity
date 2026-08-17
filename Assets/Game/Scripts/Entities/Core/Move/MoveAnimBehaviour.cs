using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public sealed class MoveAnimBehaviour : IEntityInit, IEntityTick
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private Animator _animator;
        
        public void Init(IEntity entity)
        {
            _animator = entity.GetAnimator();
        }

        public void Tick(IEntity entity, float deltaTime)
        {
            _animator.SetBool(IsMoving, entity.IsMoving());
        }
    }
}