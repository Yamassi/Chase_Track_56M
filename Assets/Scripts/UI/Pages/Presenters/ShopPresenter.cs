using System.Collections.Generic;
using Orion.Data;
using Orion.System.Resource;
using Orion.UI.Pages.View;
using Orion.UI.Pages.View.GamePlayUI;
using Orion.UI.Pages.View.Shop;
using UnityEngine;
using Zenject;

namespace Orion.UI.Pages.Presenters
{
    public class ShopPresenter : IPresenter<ShopView>
    {
        private const string ItemPrefabPath = "Prefabs/ShopItem";
        private const string ItemsPath = "Images/Items/Item";
        private readonly Dictionary<int, ShopItem> _items = new();
        private IResourceFactory _resourceFactory;
        private IResourceLoader _resourceLoader;
        private int _currentItem;
        private DataService _dataService;
        private ShopView _view;

        [Inject]
        public void Construct(DataService dataService, IResourceLoader resourceLoader, IResourceFactory resourceFactory)
        {
            _dataService = dataService;
            _resourceLoader = resourceLoader;
            _resourceFactory = resourceFactory;
        }

        public void Initialize(IView<ShopView> view)
        {
            _view = view.GetView();
            
            var itemsData = _dataService.PlayerData.Items.Items;
            for (var i = 0; i < itemsData.Count; i++)
            {
                var character = CreateItem(itemsData[i]);
                _items.Add(itemsData[i].Id, character);
            }
        }
        public void Clear()
        {
            
        }
        private ShopItem CreateItem(ItemData itemData)
        {
            ShopItem item = _resourceFactory.Instantiate<ShopItem>(ItemPrefabPath, _view.Content);
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
            int price = _dataService.PlayerData.Items.Items[id].Price;

            if (_dataService.PlayerData.Coins.Value >= price)
            {
                _dataService.PlayerData.Coins.Remove(price);
                _dataService.PlayerData.Items.Purchased(id);

                _items[id].SetPurchased();
            }
        }

        private void Select(int id)
        {
            _dataService.PlayerData.Items.Select(id);

            _items[_currentItem].SetPurchased();

            _currentItem = id;
            _items[_currentItem].SetInUse();
        }
    }
}