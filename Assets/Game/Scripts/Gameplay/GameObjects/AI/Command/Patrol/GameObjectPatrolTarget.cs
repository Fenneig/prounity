using UnityEngine;

namespace Game.Gameplay
{
    public sealed class GameObjectPatrolTarget : IPatrolTarget
    {
        private readonly GameObject _target;
        public Vector3 Position => _target.transform.position;
        public GameObject Target => _target;

        public GameObjectPatrolTarget(GameObject target) => _target = target;
    }
}