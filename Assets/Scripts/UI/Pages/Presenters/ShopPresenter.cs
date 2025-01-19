using System.Collections.Generic;
using Orion.Data;
using Orion.System.Resource;
using Orion.UI.Pages.View;
using Orion.UI.Pages.View.Shop;
using UnityEngine;
using Zenject;

namespace Orion.UI.Pages.Presenters
{
    public class ShopPresenter : PagePresenter<ShopView>
    {
        private const string ItemPrefabPath = "Prefabs/ShopItem";
        private const string ItemsPath = "Images/Items/Item";
        private readonly Dictionary<int, ShopItem> _items = new();
        private IResourceFactory _resourceFactory;
        private IResourceLoader _resourceLoader;
        private int _currentItem;

        [Inject]
        public void Construct(IResourceLoader resourceLoader, IResourceFactory resourceFactory)
        {
            _resourceLoader = resourceLoader;
            _resourceFactory = resourceFactory;
        }

        public override void Initialize(IView<ShopView> view)
        {
            View = view.GetView();
            
            // var itemsData = DataService.PlayerData.Items.Items;
            // for (var i = 0; i < itemsData.Count; i++)
            // {
            //     var character = CreateItem(itemsData[i]);
            //     _items.Add(itemsData[i].Id, character);
            // }
        }
        public override void Clear()
        {
            
        }
        private ShopItem CreateItem(ItemData itemData)
        {
            ShopItem item = _resourceFactory.Instantiate<ShopItem>(ItemPrefabPath, View.Content);
            Sprite sprite = _resourceLoader.Load<Sprite>(ItemsPath + itemData.Id);

            item.SetShopItem(sprite, itemData.Id, itemData.Price, TryToBuy, Select);

            switch (itemData.State)
            {
                case ItemState.Purchased:
                    item.SetPurchased();
                    break;
                case ItemState.OnSale:
                    item.SetOnSale();
                    break;
                case ItemState.InUse:
                    item.SetInUse();
                    _currentItem = itemData.Id;
                    break;
            }

            return item;
        }

        private void TryToBuy(int id)
        {
            // int price = DataService.PlayerData.Items.Items[id].Price;
            //
            // if (DataService.PlayerData.Coins.Value >= price)
            // {
            //     DataService.PlayerData.Coins.Remove(price);
            //     DataService.PlayerData.Items.Purchased(id);
            //
            //     _items[id].SetPurchased();
            // }
        }

        private void Select(int id)
        {
            // DataService.PlayerData.Items.Select(id);
            //
            // _items[_currentItem].SetPurchased();
            //
            // _currentItem = id;
            // _items[_currentItem].SetInUse();
        }
    }
}