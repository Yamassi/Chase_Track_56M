using Orion.StaticData;
using Orion.UI.Pages.View;
using UnityEngine;

namespace Orion.UI.Pages.Presenters
{
    public class GameModePresenter : PagePresenter<GameModeView>
    {
        public override void Initialize(IView<GameModeView> view)
        {
            base.Initialize(view);
            
            PlayerPrefs.SetInt(StaticNames.GameMode, 0);
            
            View.Infinity.onClick.AddListener(() =>
            {
                int price = 50;
                if (DataService.PlayerData.Coins.Value >= price)
                {
                    PlayerPrefs.SetInt(StaticNames.GameMode, 1);
                    DataService.PlayerData.Coins.Remove(price);
                    UIFactory.ChangePage(PageId.Game);
                }
            });
        }
        public override void Clear()
        {
            
        }
    }
}