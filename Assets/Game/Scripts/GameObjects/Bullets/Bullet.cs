using System;
using Game.GameObjects.Components;
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
        
        private TransformBounds _levelBounds;

        public event Action<Bullet> OnDispose;

        public void Construct(TransformBounds levelBounds) => 
            _levelBounds = levelBounds;

        private void OnHit() =>
            EndLife(BulletEndReason.Hit);

        private void EndLife(BulletEndReason reason)
        {
            _bulletVisual.EndLife(reason);
            
            _damageComponent.OnDamageApplied -= OnHit;

            OnDispose?.Invoke(this);
        }

        private void FixedUpdate()
        {
            _moveComponent.Move(transform.forward);

            if (!_levelBounds.InBounds(transform.position))
                EndLife(BulletEndReason.OutOfBounds);
        }

        private void OnEnable()
        {
            _damageComponent.OnDamageApplied += OnHit;
        }

        private void OnDisable()
        {
            _damageComponent.OnDamageApplied -= OnHit;
        }
    }
}