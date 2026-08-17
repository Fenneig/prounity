using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public class FireAnimBehaviour : IEntityInit, IEntityDispose
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private Animator _animator;
        private ICommand _fireCommand;
        
        public void Init(IEntity entity)
        {
            _animator = entity.GetAnimator();
            _fireCommand = entity.GetFireCommand();
            
            _fireCommand.Subscribe(OnFire);
        }

        public void Dispose(IEntity entity) => 
            _fireCommand.Unsubscribe(OnFire);

        private void OnFire() => 
            _animator.SetTrigger(Attack);
    }
}