using DG.Tweening;
using Game.Visual;
using UnityEngine;

namespace Game.Ships.Visual
{
    public sealed class ShipVisual : MonoBehaviour
    {
        [SerializeField] private AbstractShip _ship;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Transform _viewTransform;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ParticleSystem _fireVFX;
        [SerializeField] private AudioClip _fireSFX;
        [SerializeField] private AudioClip _damageSFX;
        
        private Material _material;
        private Tweener _damageAnimation;
        private VfxPool _vfxPool;
        
        public void Construct(VfxPool vfxPool)
        {
            _vfxPool = vfxPool;
        }
        
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
                _ship.ShipConfig.VisualConfig.HitDuration,
                progress => _material?.SetFloat(_ship.ShipConfig.VisualConfig.HitPropertyName,
                    _ship.ShipConfig.VisualConfig.HitAnimationCurve.Evaluate(progress))
            ).SetLink(_renderer.gameObject);
        }

        private void Dead(AbstractShip _)
        {
            ParticleSystem prefab = _ship.ShipConfig.VisualConfig.DestroyEffectPrefab;
            _vfxPool.Get(prefab.gameObject, _viewTransform.position, prefab.transform.rotation);
        }

        private void Start()
        {
            _renderer.material = _ship.ShipConfig.VisualConfig.MaterialPrefab;
            _material = _renderer.material;
        }

        private void OnEnable()
        {
            _ship.OnFire += Fire;
            _ship.OnDamaged += Damaged;
            _ship.OnDead += Dead;
        }

        private void OnDisable()
        {
            _ship.OnFire -= Fire;
            _ship.OnDamaged -= Damaged;
            _ship.OnDead -= Dead;
        }
    }
}