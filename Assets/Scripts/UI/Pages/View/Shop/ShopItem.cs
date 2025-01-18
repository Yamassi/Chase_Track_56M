using System;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Orion.UI.Pages.View.Shop
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private Image _frameActive, _frameInactive;
        [SerializeField] private Image _itemImage;
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _price;
        private Action<int> _onSelect;
        private Action<int> _onTryToBuy;
        private int _id;

        public void SetShopItem(Sprite itemImage, int id, int price, Action<int> onTryToBuy, Action<int> onSelect)
        {
            _id = id;
            _onTryToBuy = onTryToBuy;
            _onSelect = onSelect;
            _itemImage.sprite = itemImage;
            _price.text = price.ToString();
        }

        [Button]
        public void SetOnSale()
        {
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => _onTryToBuy?.Invoke(_id));
            _frameActive.gameObject.SetActive(false);
            _frameInactive.gameObject.SetActive(true);
            _itemImage.gameObject.SetActive(false);
            _price.gameObject.SetActive(true);
        }

        [Button]
        public void SetPurchased()
        {
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => _onSelect?.Invoke(_id));
            _frameActive.gameObject.SetActive(false);
            _frameInactive.gameObject.SetActive(true);
            _itemImage.gameObject.SetActive(true);
            _price.gameObject.SetActive(false);
        }

        [Button]
        public void SetInUse()
        {
            _button.onClick.RemoveAllListeners();
            _frameActive.gameObject.SetActive(true);
            _frameInactive.gameObject.SetActive(false);
            _itemImage.gameObject.SetActive(true);
            _price.gameObject.SetActive(false);
        }
    }
}