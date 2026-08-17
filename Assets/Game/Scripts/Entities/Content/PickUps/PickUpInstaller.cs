using Atomic.Entities;
using UnityEngine;

namespace Game.Entities
{
    public class PickUpInstaller : SceneEntityInstaller
    {
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private InteractableInstaller _interactableInstaller;
        
        public override void Install(IEntity entity)
        {
            _transformInstaller.Install(entity);
            _interactableInstaller.Install(entity);
        }
    }
}