using Game.Common;
using Unity.Entities;
using UnityEngine;

namespace Game.GameEntities.Content
{
    public class TeamAuthoring : MonoBehaviour
    {
        [SerializeField] private TeamType _teamType;
        
        private class Baker : Baker<TeamAuthoring>
        {
            public override void Bake(TeamAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                
                AddComponent(entity, new Team { Value = authoring._teamType });
            }
        }
    }
}