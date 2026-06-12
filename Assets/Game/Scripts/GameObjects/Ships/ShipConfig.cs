using Game.GameObjects.Bullets;
using Game.UI.Ship;
using Game.Utils;
using UnityEngine;

namespace Game.GameObjects.Ships
{
    public sealed class ShipConfig : ScriptableObject
    {
        [field: SerializeField] public AbstractShip Prefab { get; private set; }
        [field: Header("Core")]
        [field: SerializeField] public int Health { get; private set; } = 5;
        [field: SerializeField] public TeamType Team { get; private set; }
        [field: Header("Move")]
        [field: SerializeField] public float MoveSpeed { get; private set; } = 5;
        [field: Header("Weapon")]
        [field: SerializeField] public float FireCooldown { get; private set; } = 0.25f;
        [field: SerializeField] public BulletConfig BulletConfig { get; private set; }
        [field: Header("Visual")]
        [field: SerializeField] public ShipVisualConfig VisualConfig { get; private set; }
    }
}