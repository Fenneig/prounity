using Atomic.Elements;
using UnityEngine;

namespace Game.Entities.Animations
{
    public class AnimationEventBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private IGameEntity _self;
        private IValue<AnimationEvents> _animationEvents;
        private IRequest _fireRequest;
        
        public void Init(IGameEntity entity)
        {
            _self = entity;
            _animationEvents = entity.GetAnimationEvents();
            _animationEvents.Value.OnEvent += HandleEvent;
            _fireRequest = entity.GetFireRequest();
        }

        public void Dispose(IGameEntity entity)
        {
            _animationEvents.Value.OnEvent -= HandleEvent;
        }

        private void HandleEvent(string eventName)
        {
            switch (eventName)
            {
                case "Death":
                    _self.GetBodyFallSoundRequest().Invoke();
                    break;
                case "Step":
                    _self.GetMoveSoundRequest().Invoke();
                    break;
                case "Attack":
                    HandleAttack();
                    break;
                case "StartAttack":
                    _self.GetShoutSoundRequest().Invoke();
                    break;
                default:
                    Debug.Log($"Couldn't handle animation event {eventName}");
                    break;
            }
        }

        private void HandleAttack()
        {
            _self.GetAttackSoundRequest().Invoke();
            bool wantToAttack = _self.GetWantsToFire().Value;
            if (wantToAttack)
            {
                _fireRequest.Invoke();
                _self.GetWantsToFire().Value = false;
            }
        }
    }
}