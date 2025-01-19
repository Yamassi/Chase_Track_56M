using System;
using System.Collections.Generic;
using System.Linq;
using Orion.Data;
using Orion.UI.Pages.View;
using UnityEngine;

namespace Orion.UI.Pages.Presenters
{
    public class CharactersPresenter : PagePresenter<CharactersView>
    {
        private int _currentCharacter;
        private const string ItemsPath = "Images/Characters/Character";
        public override void Initialize(IView<CharactersView> view)
        {
            base.Initialize(view);
            
            _currentCharacter = DataService.PlayerData.Characters.Current;

            RefreshCharacter();
            View.Prev.onClick.AddListener(Prev);
            View.Next.onClick.AddListener(Next);
            View.Buy.onClick.AddListener(TryToBuy);

            DataService.PlayerData.Characters.OnChanged += RefreshCharacter;
        }

        public override void Clear()
        {
            DataService.PlayerData.Characters.OnChanged -= RefreshCharacter;
        }

        private void TryToBuy()
        {
            if (_currentCharacter == 4)
            {
                return;
            }

            var coins = DataService.PlayerData.Coins;
            var price = DataService.PlayerData.Characters.Items[_currentCharacter].Price;
            if (coins.Value >= price)
            {
                coins.Remove(price);
                DataService.PlayerData.Characters.SelectWithRefresh(_currentCharacter);
            }
        }

        private void Next()
        {
            if (_currentCharacter < DataService.PlayerData.Characters.Items.Count - 1)
            {
                _currentCharacter++;
                RefreshCharacter();
            }
        }

        private void Prev()
        {
            if (_currentCharacter > 0)
            {
                _currentCharacter--;
                RefreshCharacter();
            }
        }

        public void RefreshCharacter()
        {
            var character = DataService.PlayerData.Characters.Items[_currentCharacter];
            View.Character.sprite = Resources.Load<Sprite>(ItemsPath + _currentCharacter);
            View.Name.text = character.Name;

            switch (character.State)
            {
                case ItemState.Purchased:
                    View.Buy.gameObject.SetActive(false);
                    View.IapBuy.gameObject.SetActive(false);
                    DataService.PlayerData.Characters.Select(_currentCharacter);
                    break;
                case ItemState.OnSale:
                    View.Buy.gameObject.SetActive(_currentCharacter != 4);
                    View.IapBuy.gameObject.SetActive(_currentCharacter == 4);
                    break;
                case ItemState.InUse:
                    View.Buy.gameObject.SetActive(false);
                    View.IapBuy.gameObject.SetActive(false);
                    DataService.PlayerData.Characters.Select(_currentCharacter);
                    break;
            }
            
        }
    }
}