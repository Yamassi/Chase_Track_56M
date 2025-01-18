using System;
using UnityEngine;

namespace Orion.Data
{
    [Serializable]
    public class ResourceData
    {
        public int Value;
        public event Action<int> OnAdd;
        public event Action<int> OnRemove;
        public event Action OnChanged;

        public ResourceData(int value)
        {
            Value = value;
        }

        public void Add(int value)
        {
            Value += value;
            OnAdd?.Invoke(Value);
        }

        public void Remove(int value)
        {
            Value = Mathf.Abs(Value - value);

            OnRemove?.Invoke(Value);
        }
    }
}