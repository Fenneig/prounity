using UnityEngine;

namespace Game.Entities
{
    public class PickUpInstaller : GameEntityInstaller
    {
        [SerializeField] private GameObject _visual;
        [SerializeField] private GameObject _collider;
        
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private InteractableInstaller _interactableInstaller;
        
        public override void Install(IGameEntity entity)
        {
            _transformInstaller.Install(entity);
            _interactableInstaller.Install(entity);
            
            entity.GetInteractCommand()
                .AddAction(_ => _collider.GetComponent<Collider>().enabled = false)
                .AddAction(_ => _visual.SetActive(false));
        }
    }
}