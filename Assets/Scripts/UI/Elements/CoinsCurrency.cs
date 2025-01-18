namespace Orion.UI.Elements
{
    public class CoinsCurrency : CurrencyBase
    {
        protected override void Awake()
        {
            base.Awake();
            _resource.Initialize(_currency,_dataService.PlayerData.Coins);
        }
    }
}