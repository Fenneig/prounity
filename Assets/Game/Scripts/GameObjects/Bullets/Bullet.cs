using System;
using Game.GameObjects.Movement;
using Game.Systems.Damage;
using Modules.Utils;
using UnityEngine;

namespace Game.GameObjects.Bullets
{
    [RequireComponent(typeof(DamageComponent))]
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private DamageComponent _damageComponent;
        [SerializeField] private Transform _vfxContainer;
        [SerializeField] private BulletVisual _bulletVisual;
        [SerializeField] private MoveComponent _moveComponent;
        
        private float _speed;
        private TransformBounds _levelBounds;

        private Action<Bullet> _returnAction;

        public void Initialize(float speed, TransformBounds levelBounds)
        {
            _speed = speed;

            _damageComponent.OnDamageApplied += OnHit;

            _moveComponent.UpdateSpeed(_speed);

            _levelBounds = levelBounds;
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