using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public sealed class AnimationEventReceiver : MonoBehaviour
    {
        [SerializeField] private SceneEntity _mainEntity;
        
        public void ReceiveMoveEvent() => _mainEntity.GetMoveSoundRequest().Invoke();
        public void ReceiveBodyFallEvent() => _mainEntity.GetBodyFallSoundRequest().Invoke();
        public void ReceiveAttackAnticipationEvent() => Debug.Log("Anticipation sound");//_mainEntity.GetAttackAnticipationSoundRequest().Invoke();
        public void ReceiveAttackEvent() => _mainEntity.GetAttackSoundRequest().Invoke();
    }
}