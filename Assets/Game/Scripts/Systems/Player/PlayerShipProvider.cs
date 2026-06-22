using Game.GameObjects.Ships;
using UnityEngine;

namespace Game.Systems
{
    public sealed class PlayerShipProvider : MonoBehaviour
    {
        public Ship Player { get; set; }
    }
}