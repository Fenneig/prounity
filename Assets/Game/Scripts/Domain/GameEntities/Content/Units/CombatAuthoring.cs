using Game.GameEntities.Core;
using Unity.Entities;
using UnityEngine;

namespace Game.GameEntities.Content
{
    public class CombatAuthoring : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _range;
        [SerializeField] private float _cooldown;
        [SerializeField] private float _animationAnticipation;
        
        
        private class Baker : Baker<CombatAuthoring>
        {
            public override void Bake(CombatAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.None);
                
                AddComponent(entity, new AttackDamage{ Value =  authoring._damage });
                AddComponent(entity, new Range{ Value =  authoring._range });
                AddComponent(entity, new AttackCooldown{ Duration =  authoring._cooldown, Remaining = 0f });
                AddComponent(entity, new AttackAnticipation{ Duration =  authoring._animationAnticipation, Remaining = 0f });
                AddComponent(entity, new AttackStateComponent{ Value = AttackState.Ready });
            }
        }
    }
}