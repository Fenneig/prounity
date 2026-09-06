using Game.GameEntities.Content;
using Unity.Entities;
using UnityEngine;

namespace Game.GameEntities.Core
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public partial class MoveViewSystem : SystemBase
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        
        protected override void OnUpdate()
        {
            foreach (var (animator, moveDirection) in 
                     SystemAPI.Query<AnimatorReference, 
                         EnabledRefRO<MoveDestination>>()
                         .WithPresent<MoveDestination>()
                         .WithAll<Unit>()
                         .WithNone<Dead>())
            {
                animator.Value.SetBool(IsMoving, moveDirection.ValueRO);
            }
        }
    }
}