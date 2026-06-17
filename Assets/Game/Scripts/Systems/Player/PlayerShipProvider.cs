using Game.GameObjects.Ships;
using UnityEngine;

namespace Game.Systems.Player
{
    public sealed class PlayerShipProvider : MonoBehaviour
    {
        public Ship Player { get; set; }
    }
}