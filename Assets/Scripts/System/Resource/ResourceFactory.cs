using UnityEngine;
using Zenject;

namespace Orion.System.Resource
{
    public class ResourceFactory : IResourceFactory
    {
        private DiContainer _diContainer;

        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public T Instantiate<T>(string path, Transform parent = null) where T: MonoBehaviour
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            if (prefab == null)
            {
                Debug.LogError($"Prefab not found on path: {path}");
                return null;
            }

            return _diContainer.InstantiatePrefab(prefab, parent).GetComponent<T>();
        }
    }
}