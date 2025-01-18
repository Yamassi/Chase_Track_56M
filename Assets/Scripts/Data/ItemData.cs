using System;

namespace Orion.Data
{
    [Serializable]
    public class ItemData
    {
        public int Id;
        public int Price;
        public ItemState State;

        public ItemData(int id, int price, ItemState state)
        {
            Id = id;
            Price = price;
            State = state;
        }
    }
}