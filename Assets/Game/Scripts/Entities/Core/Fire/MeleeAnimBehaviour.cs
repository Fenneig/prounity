using UnityEngine;

namespace Game.Entities
{
    public class MeleeAnimBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private Animator _animator;

        public void Init(IGameEntity entity)
        {
            _animator = entity.GetAnimator();
            
            entity.GetWantsToFire().OnEvent += HandleWantsToFire;
        }

        private void HandleWantsToFire(bool wantToAttack)
        {
            if (wantToAttack)
                _animator.SetTrigger(Attack);
        }

        public void Dispose(IGameEntity entity)
        {
            entity.GetWantsToFire().OnEvent -= HandleWantsToFire;
        }
    }
}