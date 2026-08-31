using System;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public class MeleeAiInstaller : IGameEntityInstaller
    {
        [SerializeField] private float _wantToFireAttackDistance;

        public void Install(IGameEntity entity)
        {
            entity.GetMoveCommand()
                .AddCondition(_ => entity.HasValidTarget())
                .AddCondition(_ => !entity.IsReachTarget(_wantToFireAttackDistance))
                .AddCondition(_ => !entity.GetWantsToFire().Value);

            entity.GetFireCommand()
                .AddCondition(entity.HasValidTarget);
        }
    }
}