using System;
using System.Collections.Generic;
using System.Linq;

namespace Orion.Data
{
    [Serializable]
    public class ItemsData
    {
        public List<ItemData> Items;
        public int Current;
        public event Action OnChanged;
        public ItemsData(List<ItemData> items)
        {
            Items = items;
        }

        public void Select(int id)
        {
            var oldSelected = Items.Where(item => item.State == ItemState.InUse).FirstOrDefault();
            if (oldSelected != null)
            {
                oldSelected.State = ItemState.Purchased;
                Items[id].State = ItemState.InUse;
                Current = id;
            }
        }
        public void SelectWithRefresh(int id)
        {
            var oldSelected = Items.Where(item => item.State == ItemState.InUse).FirstOrDefault();
            if (oldSelected != null)
            {
                oldSelected.State = ItemState.Purchased;
                Items[id].State = ItemState.InUse;
                Current = id;
                OnChanged?.Invoke();
            }
        }

        public void Purchased(int id)
        {
            Items[id].State = ItemState.Purchased;
            OnChanged?.Invoke();
        }
    }
}