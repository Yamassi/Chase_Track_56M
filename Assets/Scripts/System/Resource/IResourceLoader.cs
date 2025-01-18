using UnityEngine;

namespace Orion.System.Resource
{
    public interface IResourceLoader
    {
        T Load<T>(string path) where T : Object;
    }
}