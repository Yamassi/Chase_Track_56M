using UnityEngine;

namespace Orion.GamePlay
{
    public class Coin : MonoBehaviour, IFactoryObject
    {
        private Factory<Coin> _factory;
        public void SetFactory<T>(Factory<T> factory) where T : MonoBehaviour, IFactoryObject
        {
            if (factory is Factory<Coin>)
            {
                _factory = factory as Factory<Coin>;
            }
        }

        public void Recycle() => _factory.Recycle(this);
    }
}