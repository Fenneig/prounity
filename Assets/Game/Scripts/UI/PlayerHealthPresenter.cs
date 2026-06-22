using Game.GameObjects.Components;
using Game.Systems;
using Modules.UI;
using UnityEngine;

namespace Game.UI
{
    public sealed class PlayerHealthPresenter : MonoBehaviour
    {
        [SerializeField] private PlayerShipProvider _playerShipProvider;
        [SerializeField] private HealthView _healthView;
        
        private HealthComponent _playerHealthComponent;

        private void Start()
        {
            _playerHealthComponent = _playerShipProvider.Player.GetComponent<HealthComponent>();

            _healthView.SetHealth(_playerHealthComponent.CurrentHealth, _playerHealthComponent.CurrentHealth);
            _playerHealthComponent.OnDamaged += UpdateHealth;
        }
        
        private void UpdateHealth(int oldHealth, int newHealth, int maxHealth) =>
            _healthView.SetHealth(newHealth, maxHealth);

        private void OnDestroy() =>
            _playerHealthComponent.OnDamaged -= UpdateHealth;
    }
}