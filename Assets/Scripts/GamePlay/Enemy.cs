using UnityEngine;

namespace Orion.GamePlay
{
    public class Enemy : MonoBehaviour, IFactoryObject
    {
        private Factory<Enemy> _factory;
        public void SetFactory<T>(Factory<T> factory) where T : MonoBehaviour, IFactoryObject
        {
            if (factory is Factory<Enemy>)
            {
                _factory = factory as Factory<Enemy>;
            }
        }

        public void Recycle() => _factory.Recycle(this);
    }
}