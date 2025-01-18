using UnityEngine;

namespace Orion.System.Resource
{
    public interface IResourceFactory
    {
        T Instantiate<T>(string path, Transform parent = null) where T : MonoBehaviour;
    }
}