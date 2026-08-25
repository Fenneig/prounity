using System.Collections.Generic;
using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    [BlackboardAPI]
    public static class BlackboardAPI
    {
        public static readonly BlackboardValueKey<GameObject> Character = new(nameof(Character));
        public static readonly BlackboardValueKey<List<GameObject>> EnemiesInRange = new(nameof(EnemiesInRange));
        public static readonly BlackboardValueKey<GameObject> Target = new(nameof(Target));
        public static readonly BlackboardValueKey<float> FollowStoppingDistance = new(nameof(FollowStoppingDistance));
        public static readonly BlackboardValueKey<Vector3> TargetPosition = new(nameof(TargetPosition));
        public static readonly BlackboardValueKey<float> MoveStoppingDistance = new(nameof(MoveStoppingDistance));
        public static readonly BlackboardValueKey<Vector3> HoldPosition = new(nameof(HoldPosition));
        public static readonly BlackboardValueKey<float> MoveToTargetStoppingDistance = new(nameof(MoveToTargetStoppingDistance));
        public static readonly BlackboardValueKey<float> TargetStoppingAngle = new(nameof(TargetStoppingAngle));
        public static readonly BlackboardValueKey<Weapon> Weapon = new(nameof(Weapon));
        public static readonly BlackboardValueKey<float> AttackPreferredPositionOffset = new(nameof(AttackPreferredPositionOffset));
    }
}