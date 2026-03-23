using System.Collections.Generic;
using UnityEngine;

namespace Game.Visual
{
    public class VfxPool : MonoBehaviour
    {
        [SerializeField] private Transform _vfxTransform;
        
        private readonly Dictionary<GameObject, Queue<GameObject>> _pool = new();

        public GameObject Get(GameObject prefab, Vector2 position, Quaternion rotation)
        {
            if (!_pool.TryGetValue(prefab, out var queue))
            {
                queue = new Queue<GameObject>();
                _pool[prefab] = queue;
            }
            
            if (queue.Count > 0)
            {
                var vfxObject = queue.Dequeue();
                vfxObject.transform.position = position;
                vfxObject.transform.rotation = rotation;
                vfxObject.gameObject.SetActive(true);
                return vfxObject;
            }
            else
            {
                var vfxObject = Instantiate(prefab, position, rotation, _vfxTransform);
                vfxObject.GetComponent<AutoReturnToPool>().Construct(prefab, this);
                return vfxObject;
            }
        }

        public void Release(GameObject prefab, GameObject vfx)
        {
            vfx.gameObject.SetActive(false);
            _pool[prefab].Enqueue(vfx);
        }
    }
}