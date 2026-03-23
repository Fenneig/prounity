using Modules.UI;
using UnityEngine;

namespace Game.Ships.Player
{
    public sealed class PlayerHealthPresenter : MonoBehaviour
    {
        [SerializeField] private PlayerShip _player;
        private HealthView _healthView;

        public void Construct(HealthView healthView) => 
            _healthView = healthView;
        
        private void UpdateHealth(int oldHealth, int newHealth, int maxHealth)
        {
            _healthView.SetHealth(newHealth, maxHealth);
        }

        private void OnEnable()
        {
            _player.OnDamaged += UpdateHealth;
        }

        private void OnDisable()
        {
            _player.OnDamaged -= UpdateHealth;
        }
    }
}