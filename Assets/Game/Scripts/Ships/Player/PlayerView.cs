using Modules.UI;
using Modules.Utils;
using UnityEngine;

namespace Game.Ships.Player
{
    public sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private PlayerShip _playerShip;
        private HealthView _healthView;
        private CameraShaker _cameraShaker;
        
        public void Construct(HealthView healthView, CameraShaker cameraShaker)
        {
            _healthView = healthView;
            _cameraShaker = cameraShaker;
        }
        
        private void UpdateHealth(int oldHealth, int newHealth, int maxHealth)
        {
            _healthView.SetHealth(newHealth, maxHealth);
            _cameraShaker.Shake();
        }

        private void OnEnable()
        {
            _playerShip.OnDamaged += UpdateHealth;
        }

        private void OnDisable()
        {
            _playerShip.OnDamaged -= UpdateHealth;
        }
    }
}