using Game.UI;
using Modules.Utils;
using UnityEngine;

namespace Game.GameObjects.Ships.Player
{
    [RequireComponent(typeof(InputHandler))]
    [RequireComponent(typeof(PlayerHealthPresenter))]
    [RequireComponent(typeof(PlayerView))]
    public sealed class PlayerShip : AbstractShip
    {
        private TransformBounds _playerArea;
        
        public void Construct(TransformBounds playerArea) => 
            _playerArea = playerArea;

        public void Fire()
        {
            if (WeaponComponent.IsReady) 
                WeaponComponent.Fire(transform.up);
        }
        
        protected override void LateUpdate()
        {
            base.LateUpdate();
            transform.position = _playerArea.ClampInBounds(transform.position);
        }
    }
}