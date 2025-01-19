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
                    Coins = new(50000),
                    BestScore = 0,
                    Levels = new LevelsData(24),
                    Characters = new ItemsData(new List<ItemData>()
                    {
                        new ItemData(0,"Endurax",0,ItemState.InUse),
                        new ItemData(1,"Lucius",1500,ItemState.OnSale),
                        new ItemData(2,"Lilian",2000,ItemState.OnSale),
                        new ItemData(3,"Seraphina",2500,ItemState.OnSale),
                        new ItemData(4,"Belzak",0,ItemState.OnSale),
                    }),
                    Lighting = new Effect(new []{0,400,1000,1500,2000},new []{3,4,5,6,7}),
                    Shield = new Effect(new []{0,400,1000,1500,2000},new []{5,6,7,8,9}),
                    Fire = new Effect(new []{0,400,1000,1500,2000},new []{3,4,5,6,7}),
                    Missions = new TasksData(new List<TaskData>()
                    {
                        new TaskData(0,TaskState.Uncomplete,80),
                        new TaskData(1,TaskState.Complete,90),
                        new TaskData(2,TaskState.RewardTaked,100),
                        new TaskData(3,TaskState.Uncomplete,111),
                    }),
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