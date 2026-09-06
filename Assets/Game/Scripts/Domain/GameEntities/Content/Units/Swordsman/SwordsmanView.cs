using Unity.Entities;
using Unity.Entities.HybridViews;
using UnityEngine;

namespace Game.GameEntities.Content
{
    public class SwordsmanView : EntityView
    {
        private static readonly int Death = Animator.StringToHash("Death");
        [SerializeField] private Animator _animator;

        public void PlayDeath() => _animator.SetTrigger(Death);

        protected override void Show(Entity entity, EntityCommandBuffer ecb)
        {
            ecb.AddComponent(entity, new TransformReference { Value = transformHandle });
            ecb.AddComponent(entity, new AnimatorReference { Value = _animator });
        }

        protected override void Hide(Entity entity, EntityCommandBuffer ecb)
        { }
    }
}