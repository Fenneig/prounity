using System.Collections.Generic;
using UnityEngine;

namespace Game.Systems
{
    public sealed class Pool : MonoBehaviour
    {
        [SerializeField] private Transform _prefab;
        [SerializeField] private int _preloadCount;
        [SerializeField] private Transform _container;
        
        private readonly Stack<Transform> _pool = new();

        private void Awake()
        {
            for (int i = 0; i < _preloadCount; i++)
            {
                var poolObject = Instantiate(_prefab, _container);
                poolObject.gameObject.SetActive(false);
                _pool.Push(poolObject);
            }
        }

        public Transform Get()
        {
            if (_pool.TryPop(out Transform poolObject))
                poolObject.gameObject.SetActive(true);
            else
                return Instantiate(_prefab, _container);
            
            return poolObject;
        }
        
        public void Return(Transform poolObject) 
        {
            poolObject.gameObject.SetActive(false);
            _pool.Push(poolObject);
        }
    }
}