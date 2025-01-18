using UnityEngine;

namespace Orion.System.Resource
{
    public class ResourceLoader : IResourceLoader
    {
        public T Load<T>(string path) where T : Object
        {
            T resource = Resources.Load<T>(path);
            if (resource == null)
            {
                Debug.LogError($"Resource not found on path: {path}");
            }
            return resource;
        }
    }
}