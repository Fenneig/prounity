using Modules.AI;
using UnityEngine;

namespace Game.Gameplay
{
    [BlackboardAPI]
    public static class BlackboardAPI
    {
        public static readonly BlackboardValueKey<GameObject> Character = new(nameof(Character));
        
        public static readonly BlackboardValueKey<GameObject> FireTarget = new(nameof(FireTarget));
        public static readonly BlackboardValueKey<GameObject> MoveTarget = new(nameof(MoveTarget));
        public static readonly BlackboardValueKey<Vector3> TargetPosition = new(nameof(TargetPosition));
        
        public static readonly BlackboardValueKey<float> FollowStoppingDistance = new(nameof(FollowStoppingDistance));
        public static readonly BlackboardValueKey<float> MoveStoppingDistance = new(nameof(MoveStoppingDistance));
        public static readonly BlackboardValueKey<float> MoveToTargetStoppingDistance = new(nameof(MoveToTargetStoppingDistance));
        public static readonly BlackboardValueKey<float> TargetStoppingAngle = new(nameof(TargetStoppingAngle));

        public static readonly BlackboardValueKey<Weapon> Weapon = new(nameof(Weapon));
        public static readonly BlackboardValueKey<float> AttackPreferredPositionOffset = new(nameof(AttackPreferredPositionOffset));
        
        public static readonly BlackboardValueKey<AutoCombatBehaviour> AutoCombatBehaviour = new(nameof(AutoCombatBehaviour));
    }
}