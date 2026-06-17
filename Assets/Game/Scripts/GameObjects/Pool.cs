using System.Collections.Generic;
using UnityEngine;

namespace Game.GameObjects
{
    public abstract class Pool<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private Factory<T> _factory;
        [SerializeField] private int _preloadCount;
        
        private readonly Stack<T> _pool = new();

        private void Awake()
        {
            for (int i = 0; i < _preloadCount; i++)
            {
                var poolObject = _factory.Create();
                poolObject.gameObject.SetActive(false);
                _pool.Push(poolObject);
            }
        }

        public T Get()
        {
            if (_pool.TryPop(out T poolObject))
                poolObject.gameObject.SetActive(true);
            else
                return _factory.Create();
            
            return poolObject;
        }
        
        public void Return(T poolObject) 
        {
            poolObject.gameObject.SetActive(false);
            _pool.Push(poolObject);
        }
    }
}