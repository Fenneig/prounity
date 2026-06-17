using Game.GameObjects.Ships.Player;
using Game.Systems.Player;
using UnityEngine;

namespace Game.Systems
{
    public sealed class EntryPoint : MonoBehaviour
    {
        [Header("Scene entities")] 
        [SerializeField] private PlayerFactory _playerFactory;
        [Header("Systems")]
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private PlayerShipProvider _playerShipProvider; 
        
        private void Awake() => 
            _playerShipProvider.Player = _playerFactory.Get();

        private void Start() => 
            _gameCycle.StartGame();
    }
}