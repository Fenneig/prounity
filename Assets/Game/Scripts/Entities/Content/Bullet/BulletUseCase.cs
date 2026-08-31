using UnityEngine;

namespace Game.Entities
{
    public static class BulletUseCase
    {
        public static void SpawnBullet(this IGameContext gameContext, Vector3 position, Quaternion rotation, IGameEntity owner)
        {
            var pool = gameContext.GetBulletPool();
            IGameEntity bullet = pool.Rent();
            bullet.GetPosition().Value = position;
            bullet.GetRotation().Value = rotation; 
            bullet.GetRespawnAction().Invoke();
            bullet.GetOwner().Value = owner;
        }
        
        public static void DespawnBullet(this IGameContext gameContext, IGameEntity bullet)
        {
            var pool = gameContext.GetBulletPool();
            pool.Return(bullet);
        }
    }
}