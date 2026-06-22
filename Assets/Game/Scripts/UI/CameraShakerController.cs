using Game.GameObjects.Components;
using Game.Systems;
using Modules.Utils;
using UnityEngine;

namespace Game.UI
{
    public sealed class CameraShakerController : MonoBehaviour
    {
        [SerializeField] private CameraShaker _cameraShaker;
        [SerializeField] private PlayerShipProvider _playerShipProvider;

        private void ShakeOnDamaged(int oldHealth, int newHealth, int maxHealth)
        {
            if (newHealth < oldHealth)
                _cameraShaker.Shake();
        }

        private void Start()
        {
            _playerShipProvider.Player.GetComponent<HealthComponent>().OnDamaged += ShakeOnDamaged;
        }

        private void OnDestroy()
        {
            _playerShipProvider.Player.GetComponent<HealthComponent>().OnDamaged -= ShakeOnDamaged;
        }
    }
}