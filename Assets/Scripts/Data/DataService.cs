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