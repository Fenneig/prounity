using System.Collections;
using UnityEngine;

namespace Game.Visual
{
    public class AutoReturnToPool : MonoBehaviour
    {
        [SerializeField, Tooltip("Particle lifetime — if the particle loops, leave this field at zero.")] private float _vfxLifeTime;
        private GameObject _prefab;
        private VfxPool _pool;
        
        public void Construct(GameObject prefab, VfxPool pool)
        {
            _prefab = prefab;
            _pool = pool;
        }

        private IEnumerator ReturnWhenDone()
        {
            yield return new WaitForSeconds(_vfxLifeTime);
            _pool.Release(_prefab, gameObject);
        }

        private void OnEnable()
        {
            if (_vfxLifeTime == 0)  
                return;
            
            StartCoroutine(ReturnWhenDone());
        }

        private void OnParticleSystemStopped()
        {
            _pool.Release(_prefab, gameObject);
        }
    }
}