using Modules.Utils;
using UnityEngine;

namespace Game.GameObjects.Ships.Player
{
    public sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private HealthComponent _playerHealthComponent;
        private CameraShaker _cameraShaker;

        public void Construct(CameraShaker cameraShaker)
        {
            _cameraShaker = cameraShaker;
        }

        private void UpdateHealth(int oldHealth, int newHealth, int maxHealth)
        {
            if (newHealth < oldHealth)
                _cameraShaker.Shake();
        }

        private void OnEnable()
        {
            _playerHealthComponent.OnDamaged += UpdateHealth;
        }

        private void OnDisable()
        {
            _playerHealthComponent.OnDamaged -= UpdateHealth;
        }
    }
}