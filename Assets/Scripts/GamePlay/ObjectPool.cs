using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Orion.GamePlay
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private Queue<T> _pool;
        private T _prefab;
        private Transform _parent;
        private List<T> _activeObjects;
        private readonly DiContainer _diContainer;

        public ObjectPool(T prefab, int initialSize, Transform parent = null, DiContainer diContainer = null)
        {
            _diContainer = diContainer;
            _pool = new Queue<T>();
            _activeObjects = new List<T>();
            _prefab = prefab;
            _parent = parent;

            for (int i = 0; i < initialSize; i++)
            {
                T obj;
                if (_diContainer != null) obj = _diContainer.InstantiatePrefabForComponent<T>(_prefab, _parent);
                else obj = GameObject.Instantiate(_prefab, _parent);
                obj.gameObject.SetActive(false);
                _pool.Enqueue(obj);
            }
        }

        public T Get()
        {
            T obj;
            if (_pool.Count > 0)
            {
                obj = _pool.Dequeue();
            }
            else
            {
                if (_diContainer != null) obj = _diContainer.InstantiatePrefabForComponent<T>(_prefab, _parent);
                else obj = GameObject.Instantiate(_prefab, _parent);
            }

            obj.gameObject.SetActive(true);
            _activeObjects.Add(obj);
            return obj;
        }

        public void ReturnToPool(T obj)
        {
            obj.gameObject.SetActive(false);
            _activeObjects.Remove(obj);
            _pool.Enqueue(obj);
        }

        public void ClearPool()
        {
            while (_pool.Count > 0)
            {
                T obj = _pool.Dequeue();
                if (obj != null && obj.gameObject != null)
                {
                    GameObject.Destroy(obj.gameObject);
                }
            }
            
            for (int i = _activeObjects.Count - 1; i >= 0; i--)
            {
                T obj = _activeObjects[i];
                if (obj != null && obj.gameObject != null)
                {
                    GameObject.Destroy(obj.gameObject);
                }
            }

            _activeObjects.Clear();
        }

        public List<T> GetActiveObjects()
        {
            return new List<T>(_activeObjects);
        }

        public List<T> GetInactiveObjects()
        {
            return new List<T>(_pool);
        }

        public List<T> GetAllObjects()
        {
            List<T> allObjects = new List<T>(_activeObjects);
            allObjects.AddRange(_pool);
            return allObjects;
        }
    }
}