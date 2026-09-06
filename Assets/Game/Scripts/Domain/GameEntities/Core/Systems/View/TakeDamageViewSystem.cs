using Game.GameEntities.Content;
using Unity.Entities;
using UnityEngine;

namespace Game.GameEntities.Core
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public partial class TakeDamageViewSystem : SystemBase
    {
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");
        
        protected override void OnUpdate()
        {
            foreach (var (animator, request) in SystemAPI.Query<AnimatorReference, EnabledRefRW<IsTakeDamage>>()
                         .WithAll<Unit>()
                         .WithNone<Dead>())
            {
                animator.Value.SetTrigger(TakeDamage);
                request.ValueRW = false;
            }
        }
    }
}