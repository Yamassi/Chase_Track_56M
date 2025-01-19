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
        public override void Initialize(IView<ShopView> view)
        {
            View = view.GetView();

            RefreshEffects();
            
            var effectsData = DataService.PlayerData.Effects;
            
            for (var i = 0; i < View.Effects.Length; i++)
            {
                int effectsLevel = effectsData[i].Level;
                View.Effects[i].Initialize(i,
                    TryToBuy,
                    effectsData[i].Durations[effectsLevel],
                    effectsData[i].Price[effectsLevel],
                    effectsLevel+1);
            }
        }
        public override void Clear()
        {
            
        }

        private void TryToBuy(int id)
        {
            var effectsData = DataService.PlayerData.Effects;
            var price = effectsData[id].Price[effectsData[id].Level];
            var coins = DataService.PlayerData.Coins;

            if (coins.Value >= price)
            {
                coins.Remove(price);
                effectsData[id].Level++;
                RefreshEffects();
            }
        }

        private void RefreshEffects()
        {
            var effectsData = DataService.PlayerData.Effects;
            
            for (var i = 0; i < View.Effects.Length; i++)
            {
                int effectsLevel = effectsData[i].Level;
                View.Effects[i].SetDuration(effectsData[i].Durations[effectsLevel]);
                View.Effects[i].SetPrice(effectsData[i].Price[effectsLevel]);
                View.Effects[i].SetLevel(effectsLevel+1);
            }
        }
    }
}