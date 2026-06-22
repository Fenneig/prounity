using Game.GameObjects.Components;
using UnityEngine;

namespace Game.GameObjects.Ships
{
    public sealed class Ship : MonoBehaviour
    {
        [SerializeField] private Transform _viewTransform;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private ShipConfig _shipConfig;
        [SerializeField] private WeaponComponent _weaponComponent;

        public void Initialize()
        {
            GetComponent<HealthComponent>().Initialize(_shipConfig);
            _weaponComponent.Initialize(_shipConfig);
            _moveComponent.Initialize(_shipConfig.MoveSpeed);
        }
    }
}