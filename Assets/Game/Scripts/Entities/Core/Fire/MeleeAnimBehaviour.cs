using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public class MeleeAnimBehaviour : IEntityInit, IEntityDispose
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private Animator _animator;

        public void Init(IEntity entity)
        {
            _animator = entity.GetAnimator();
            
            entity.GetWantsToFire().OnEvent += HandleWantsToFire;
        }

        private void HandleWantsToFire(bool wantToAttack)
        {
            if (wantToAttack)
                _animator.SetTrigger(Attack);
        }

        public void Dispose(IEntity entity)
        {
            entity.GetWantsToFire().OnEvent -= HandleWantsToFire;
        }
    }
}