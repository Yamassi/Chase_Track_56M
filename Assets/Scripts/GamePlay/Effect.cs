using UnityEngine;

namespace Orion.GamePlay
{
    public class Effect : MonoBehaviour, IFactoryObject
    {
        private Factory<Effect> _factory;
        public void SetFactory<T>(Factory<T> factory) where T : MonoBehaviour, IFactoryObject
        {
            if (factory is Factory<Effect>)
            {
                _factory = factory as Factory<Effect>;
            }
        }

        public void Recycle() => _factory.Recycle(this);
    }
}