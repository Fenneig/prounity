using Game.GameEntities.Content;
using Unity.Entities;
using UnityEngine;

namespace Game.GameEntities.Core
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public partial class AttackViewSystem : SystemBase
    {
        private static readonly int Fire = Animator.StringToHash("Fire");
        
        protected override void OnUpdate()
        {
            foreach (var (animatorReference, request) in SystemAPI.Query<AnimatorReference, EnabledRefRW<AttackAnimationRequest>>()
                         .WithAll<Unit>()
                         .WithNone<Dead>())
            {
                animatorReference.Value.SetTrigger(Fire);
                request.ValueRW = false;
            }
        }
    }
}