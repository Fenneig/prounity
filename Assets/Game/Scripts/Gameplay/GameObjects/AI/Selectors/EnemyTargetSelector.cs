using Game.Gameplay.Sensors;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class EnemyTargetSelector
    {
        private readonly EnemySensor _sensor;
        private readonly Transform _owner;

        public EnemyTargetSelector(EnemySensor sensor, Transform owner)
        {
            _sensor = sensor;
            _owner = owner;
        }

        public GameObject FindClosest()
        {
            GameObject closestEnemy = null;
            float closestSqrDistance = float.MaxValue;

            foreach (GameObject enemy in _sensor.Enemies)
            {
                float sqrDistance = (enemy.transform.position - _owner.position).sqrMagnitude;

                if (sqrDistance >= closestSqrDistance)
                    continue;

                closestSqrDistance = sqrDistance;
                closestEnemy = enemy;
            }

            return closestEnemy;
        }
    }
}