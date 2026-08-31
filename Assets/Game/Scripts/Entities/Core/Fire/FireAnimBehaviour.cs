using Atomic.Elements;
using UnityEngine;

namespace Game.Entities
{
    public class FireAnimBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private Animator _animator;
        private ICommand _fireCommand;
        
        public void Init(IGameEntity entity)
        {
            _animator = entity.GetAnimator();
            _fireCommand = entity.GetFireCommand();
            
            _fireCommand.Subscribe(OnFire);
        }

        public void Dispose(IGameEntity entity) => 
            _fireCommand.Unsubscribe(OnFire);

        private void OnFire() => 
            _animator.SetTrigger(Attack);
    }
}