using Game.GameObjects.Ships;
using Modules.UI;
using UnityEngine;

namespace Game.UI
{
    public sealed class PlayerHealthPresenter : MonoBehaviour
    {
        [SerializeField] private HealthComponent _playerHealthComponent;
        private HealthView _healthView;

        public void Construct(HealthView healthView) => _healthView = healthView;

        private void Start() => _healthView.SetHealth(_playerHealthComponent.CurrentHealth, _playerHealthComponent.CurrentHealth);

        private void UpdateHealth(int oldHealth, int newHealth, int maxHealth) => _healthView.SetHealth(newHealth, maxHealth);

        private void OnEnable() => _playerHealthComponent.OnDamaged += UpdateHealth;

        private void OnDisable() => _playerHealthComponent.OnDamaged -= UpdateHealth;
    }
}