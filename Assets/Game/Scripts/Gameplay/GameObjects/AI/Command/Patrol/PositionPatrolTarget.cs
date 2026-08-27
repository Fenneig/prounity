using UnityEngine;

namespace Game.Gameplay
{
    public sealed class PositionPatrolTarget : IPatrolTarget
    {
        public Vector3 Position { get; }
        
        public PositionPatrolTarget(Vector3 position) => Position = position;
    }
}