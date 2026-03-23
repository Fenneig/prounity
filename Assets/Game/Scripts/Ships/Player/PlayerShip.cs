using Game.Bullets;
using Game.Visual;
using Modules.Utils;
using UnityEngine;

namespace Game.Ships.Player
{
    [RequireComponent(typeof(InputHandler))]
    [RequireComponent(typeof(PlayerHealthPresenter))]
    [RequireComponent(typeof(PlayerView))]
    public sealed class PlayerShip : AbstractShip
    {
        [SerializeField] private InputHandler _inputHandler;
        private TransformBounds _playerArea;

        private Vector2 _moveDirection;

        public void Construct(ShipConfig config, BulletPool bulletPool, VfxPool vfxPool, TransformBounds playerArea)
        {
            base.Construct(config, bulletPool, vfxPool);
            _playerArea = playerArea;
        }

        private void UpdateMovement(Vector2 moveDirection) => 
            _moveDirection = moveDirection;

        private void Fire()
        {
            if (FireCooldown.IsFinished)
            {
                Fire(transform.up);
                FireCooldown.Reset();
            }
        }

        protected override Vector3 GetMoveDirection() => 
            _moveDirection;

        protected override void LateUpdate()
        {
            base.LateUpdate();
            transform.position = _playerArea.ClampInBounds(transform.position);
        }
        
        private void OnEnable()
        {
            _inputHandler.OnFire += Fire;
            _inputHandler.OnMove += UpdateMovement;
        }

        private void OnDisable()
        {
            _inputHandler.OnFire -= Fire;
            _inputHandler.OnMove -= UpdateMovement;
        }
    }
}