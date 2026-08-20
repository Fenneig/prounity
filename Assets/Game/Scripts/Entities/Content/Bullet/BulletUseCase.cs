using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public static class BulletUseCase
    {
        public static void SpawnBullet(this GameContext gameContext, Vector3 position, Quaternion rotation, IEntity owner)
        {
            SceneEntityPool pool = gameContext.GetBulletPool();
            IEntity bullet = pool.Rent();
            bullet.GetPosition().Value = position;
            bullet.GetRotation().Value = rotation; 
            bullet.GetRespawnAction().Invoke();
            bullet.GetOwner().Value = owner;
        }
        
        public static void DespawnBullet(this GameContext gameContext, IEntity bullet)
        {
            SceneEntityPool pool = gameContext.GetBulletPool();
            pool.Return(bullet);
        }
    }
}