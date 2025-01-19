using System.Collections.Generic;
using System.Linq;
using Orion.Data;
using Orion.UI.Pages.View;
using UnityEngine;

namespace Orion.UI.Pages.Presenters
{
    public class MainMenuPresenter : PagePresenter<MainMenuView>
    {
        private int _currentCharacter;
        private const string ItemsPath = "Images/Characters/Character";
        private List<ItemData> _characters;
        public override void Initialize(IView<MainMenuView> view)
        {
            base.Initialize(view);

            AudioService.PlayMenuMusic();
            
            _currentCharacter = DataService.PlayerData.Characters.Current;
           

            _characters = DataService.PlayerData.Characters.Items.Where(c => c.State == ItemState.Purchased || c.State == ItemState.InUse).ToList();
            
            RefreshCharacter();
            View.Prev.onClick.AddListener(Prev);
            View.Next.onClick.AddListener(Next);
        }

        public override void Clear()
        {
            
        }

        private void Next()
        {
            if (_currentCharacter < _characters.Count - 1)
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
            int currentCharacterId = _characters[_currentCharacter].Id;
            DataService.PlayerData.Characters.Select(currentCharacterId);
            View.Character.sprite = Resources.Load<Sprite>(ItemsPath + currentCharacterId);
            
        }
    }
}