using Game.GameObjects.Components;
using Game.GameObjects.Ships;
using UnityEngine;

namespace Game.Systems
{
    public class GameOverController : MonoBehaviour
    {
        [SerializeField] private PlayerShipProvider _playerShipProvider;
        [SerializeField] private GameCycle _gameCycle;

        private void Start() => 
            _playerShipProvider.Player.GetComponent<HealthComponent>().OnDead += GameOver;

        private void OnDestroy()
        {
            if (_playerShipProvider.Player == null) 
                return;
            
            _playerShipProvider.Player.GetComponent<HealthComponent>().OnDead -= GameOver;
        }
        
        private void GameOver(Ship ship)
        {
            Destroy(ship.gameObject);
            _gameCycle.EndGame();
        }
    }
}