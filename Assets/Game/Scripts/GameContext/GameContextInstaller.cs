using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public class GameContextInstaller : SceneEntityInstaller
    {
        [SerializeField] private SceneEntityPool _bulletPool;
        
        public override void Install(IEntity entity)
        {
            entity.AddBulletPool(_bulletPool);
        }
    }
}