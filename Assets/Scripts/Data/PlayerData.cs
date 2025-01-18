using System;

namespace Orion.Data
{
    [Serializable]
    public class PlayerData
    {
        public ResourceData Coins;
        public ItemsData Items;
        
        public float Music;
        public float Sound;
        public bool Vibration;
    }
}