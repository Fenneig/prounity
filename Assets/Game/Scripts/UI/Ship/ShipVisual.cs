using DG.Tweening;
using Game.GameObjects.Ships;
using Game.UI.Visual;
using UnityEngine;

namespace Game.UI.Ship
{
    public sealed class ShipVisual : MonoBehaviour
    {
        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Transform _viewTransform;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ParticleSystem _fireVFX;
        [SerializeField] private AudioClip _fireSFX;
        [SerializeField] private AudioClip _damageSFX;
        
        private Material _material;
        private Tweener _damageAnimation;
        private VfxPool _vfxPool;
        private ShipConfig _shipConfig;
        
        public void SetConfig(ShipConfig shipConfig) => 
            _shipConfig = shipConfig;

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
                _shipConfig.VisualConfig.HitDuration,
                progress => _material?.SetFloat(_shipConfig.VisualConfig.HitPropertyName,
                    _shipConfig.VisualConfig.HitAnimationCurve.Evaluate(progress))
            ).SetLink(_renderer.gameObject);
        }

        private void Dead(AbstractShip _)
        {
            ParticleSystem prefab = _shipConfig.VisualConfig.DestroyEffectPrefab;
            _vfxPool.Get(prefab.gameObject, _viewTransform.position, prefab.transform.rotation);
        }

        private void Start()
        {
            _renderer.material = _shipConfig.VisualConfig.MaterialPrefab;
            _material = _renderer.material;
        }

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