using System;
using Game.Damage;
using Game.Movement;
using Game.Utils;
using Game.Visual;
using Modules.Utils;
using UnityEngine;

namespace Game.Bullets
{
    [RequireComponent(typeof(DamageComponent))]
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private DamageComponent _damageComponent;
        [SerializeField] private Transform _vfxContainer;
        [SerializeField] private BulletVisual _bulletVisual;
        
        private float _speed;
        private IMoveComponent _moveComponent;
        private TransformBounds _levelBounds;

        private Action<Bullet> _returnAction;

        public void Construct(TransformBounds levelBounds, VfxPool vfxPool)
        {
            _levelBounds = levelBounds;
            _bulletVisual.Construct(vfxPool);
            _moveComponent = new TransformMoveComponent(transform);
        }

        public void Initialize(BulletConfig config, TeamType team)
        {
            _speed = config.Speed;
            _bulletVisual.Initialize(config, team);
            _damageComponent.Init(config.Damage, team);
            _damageComponent.OnDamageApplied += OnHit;
            _moveComponent.UpdateSpeed(_speed);
        }

        public void SetTransform(Vector2 position, Vector2 direction)
        {
            transform.position = position;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
        }

        public void SetLifeEndAction(Action<Bullet> returnAction) =>
            _returnAction = returnAction;
        
        private void OnHit() =>
            EndLife(BulletEndReason.Hit);

        private void EndLife(BulletEndReason reason)
        {
            _bulletVisual.EndLife(reason);

            _damageComponent.OnDamageApplied -= OnHit;

            _returnAction?.Invoke(this);
        }

        private void FixedUpdate()
        {
            _moveComponent.Move(transform.forward);

            if (!_levelBounds.InBounds(transform.position))
                EndLife(BulletEndReason.OutOfBounds);
        }
    }
}