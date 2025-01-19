using System.Collections.Generic;

namespace Orion.Data
{
    public class DataService 
    {
        private PlayerData _playerData;
        public void LoadPlayerData()
        {
            _playerData = DataProvider.LoadPlayerData();

            if (_playerData == null)
            {
                _playerData = new PlayerData()
                {
                    Coins = new(50),
                    BestScore = 0,
                    Levels = new LevelsData(24),
                    Characters = new ItemsData(new List<ItemData>()
                    {
                        new ItemData(0,0,ItemState.InUse),
                        new ItemData(1,1500,ItemState.OnSale),
                        new ItemData(2,2000,ItemState.Purchased),
                        new ItemData(3,2500,ItemState.OnSale),
                        new ItemData(4,0,ItemState.OnSale),
                    }),
                    Lighting = new Effect(new []{0,400,1000,1500,2000},new []{3,4,5,6,7}),
                    Shield = new Effect(new []{0,400,1000,1500,2000},new []{5,6,7,8,9}),
                    Fire = new Effect(new []{0,400,1000,1500,2000},new []{3,4,5,6,7}),
                    Sound = 1,
                    Music = 1,
                };
                DataProvider.SavePlayerData(_playerData);
            }
        }
        public void SavePlayerData() => DataProvider.SavePlayerData(_playerData);
        public PlayerData PlayerData => _playerData;
    }
}