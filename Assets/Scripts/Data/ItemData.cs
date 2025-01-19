using System;

namespace Orion.Data
{
    [Serializable]
    public class ItemData
    {
        public int Id;
        public int Price;
        public string Name;
        public ItemState State;

        public ItemData(int id,string name, int price, ItemState state)
        {
            Id = id;
            Name = name;
            Price = price;
            State = state;
        }
    }
}