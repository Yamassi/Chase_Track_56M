using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Orion.GamePlay
{
    public class Factory<T> where T : MonoBehaviour, IFactoryObject
    {
        private ObjectPool<T> _objectPool;
        private GameObject _pool;

        public Factory(T prefab, int initialSize, DiContainer diContainer = null)
        {
            _pool = new GameObject($"Pool {typeof(T)}");
            _pool.transform.position = Vector3.zero;
            _objectPool = new ObjectPool<T>(prefab, initialSize, _pool.transform, diContainer);
        }

        public T Create()
        {
            T factoryObject = _objectPool.Get();
            factoryObject.SetFactory(this);
            return factoryObject;
        }

        public void Recycle(T obj)
        {
            _objectPool.ReturnToPool(obj);
        }

        public void ClearFactory()
        {
            _objectPool.ClearPool();
            if (_pool != null) GameObject.Destroy(_pool.gameObject);
        }

        public List<T> GetActiveObjects()
        {
            return _objectPool.GetActiveObjects();
        }

        public List<T> GetInactiveObjects()
        {
            return _objectPool.GetInactiveObjects();
        }

        public List<T> GetAllObjects()
        {
            return _objectPool.GetAllObjects();
        }
    }
}