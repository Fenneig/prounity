using Atomic.Elements;
using Game.Entities;
using UnityEngine;

namespace Game
{
    public class ContextInstaller : GameContextInstaller
    {
        [SerializeField] private GameEntityPool _bulletPool;
        [SerializeField] private GameEntity _character;

        public override void Install(IGameContext entity)
        {
            entity.AddBulletPool(_bulletPool);
            entity.AddCharacter(_character);
            entity.AddScore(new ReactiveVariable<int>());
        }
    }
}