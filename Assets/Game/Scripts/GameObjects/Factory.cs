using UnityEngine;

namespace Game.GameObjects
{
    public abstract class Factory<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private T _prefab;

        public T Create()
        {
            T newObject = Instantiate(_prefab, _container);
            OnCreate(newObject);
            return newObject;
        }
        
        protected virtual void OnCreate(T obj){}
    }
}