using System;
using UnityEngine;

namespace Orion.Data
{
    [Serializable]
    public class LimitedResourceData
    {
        public int Value;
        public int Limit;
        public event Action<int,int> OnAdd;
        public event Action<int,int> OnRemove;
        public event Action OnChanged;

        public LimitedResourceData(int value,int limit)
        {
            Limit = limit;
            Value = value;
        }

        public void Add(int value)
        {
            Value += value;
            Value = Mathf.Clamp(Value, 0, Limit);
            OnAdd?.Invoke(Value,Limit);
        }

        public void Remove(int value)
        {
            Value = Mathf.Abs(Value - value);

            OnRemove?.Invoke(Value,Limit);
        }
    }
}