using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Entities.Animations
{
    public class AnimationEventBehaviour : IEntityInit, IEntityDispose
    {
        private IEntity _self;
        private IValue<AnimationEvents> _animationEvents;
        
        public void Init(IEntity entity)
        {
            _self = entity;
            _animationEvents = entity.GetAnimationEvents();
            _animationEvents.Value.OnEvent += HandleEvent;
        }

        public void Dispose(IEntity entity)
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
                    _self.GetAttackSoundRequest().Invoke();
                    break;
                case "StartAttack":
                    _self.GetShoutSoundRequest().Invoke();
                    break;
                default:
                    Debug.Log($"Couldn't handle animation event {eventName}");
                    break;
            }
        }
    }
}