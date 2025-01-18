using UnityEngine;

namespace Orion.GamePlay
{
    public interface IFactoryObject
    {
        void SetFactory<T>(Factory<T> factory) where T : MonoBehaviour, IFactoryObject;
        void Recycle();
    }
}