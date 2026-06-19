using Modules;
using UnityEngine;
using Zenject;

namespace GameObjects.Coins
{
    public sealed class CoinsInstaller : MonoInstaller
    {
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private Transform _coinContainer;

        public override void InstallBindings()
        {
            Container
                .BindMemoryPool<Coin, CoinPool>()
                .FromComponentInNewPrefab(_coinPrefab)
                .UnderTransform(_coinContainer)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<CoinsWorld>()
                .FromNew()
                .AsSingle();
        }
    }
}