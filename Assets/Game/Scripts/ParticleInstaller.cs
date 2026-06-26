using Modules.UI;
using UnityEngine;
using Zenject;

namespace Game
{
    public class ParticleInstaller : MonoInstaller
    {
        [SerializeField] private ParticleAnimator _particle;
        
        public override void InstallBindings()
        {
            Container
                .Bind<ParticleAnimator>()
                .FromInstance(_particle)
                .AsSingle();
        }
    }
}