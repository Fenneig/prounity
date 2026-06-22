using DG.Tweening;
using Game.GameObjects.Components;
using UnityEngine;

namespace Game.UI
{
    public sealed class ShipVisual : MonoBehaviour
    {
        [SerializeField] private ShipVisualConfig _shipConfig;
        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Transform _viewTransform;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ParticleSystem _fireVFX;
        [SerializeField] private AudioClip _fireSFX;
        [SerializeField] private AudioClip _damageSFX;
        
        private Material _material;
        private Tweener _damageAnimation;
        private VfxPool _vfxPool;

        public void Construct(VfxPool vfxPool) => 
            _vfxPool = vfxPool;

        private void Fire()
        {
            if (_fireSFX)
                _audioSource.PlayOneShot(_fireSFX);
            
            if (_fireVFX)
                _fireVFX.Play();
        }

        private void Damaged(int oldHealth, int newHealth, int maxHealth)
        {
            if (_damageSFX)
                _audioSource.PlayOneShot(_damageSFX);
            
            if (_damageAnimation.IsActive())
                _damageAnimation.Kill();

            _damageAnimation = DOVirtual.Float(
                0f,
                1f,
                _shipConfig.HitDuration,
                progress => _material?.SetFloat(_shipConfig.HitPropertyName,
                    _shipConfig.HitAnimationCurve.Evaluate(progress))
            ).SetLink(_renderer.gameObject);
        }

        private void Dead(GameObjects.Ships.Ship _)
        {
            ParticleSystem prefab = _shipConfig.DestroyEffectPrefab;
            _vfxPool.Get(prefab.gameObject, _viewTransform.position, prefab.transform.rotation);
        }

        private void AnimateMovement()
        {
            Vector3 shipAngles = _viewTransform.localEulerAngles;
            shipAngles.x = _shipConfig.MoveRotationAngle * _moveComponent.Direction.y;
            shipAngles.y = _shipConfig.MoveRotationAngle / 2 * _moveComponent.Direction.x * -1f;
            
            Quaternion shipRotation = Quaternion.Euler(shipAngles);
            float t = _moveComponent.Speed * Time.deltaTime;
            _viewTransform.localRotation = Quaternion.Lerp(_viewTransform.localRotation, shipRotation, t);
        }

        private void Start()
        {
            _renderer.material = _shipConfig.MaterialPrefab;
            _material = _renderer.material;
        }
        
        private void LateUpdate() => 
            AnimateMovement();

        private void OnEnable()
        {
            _weaponComponent.OnFire += Fire;
            _healthComponent.OnDamaged += Damaged;
            _healthComponent.OnDead += Dead;
        }

        private void OnDisable()
        {
            _weaponComponent.OnFire -= Fire;
            _healthComponent.OnDamaged -= Damaged;
            _healthComponent.OnDead -= Dead;
        }
    }
}