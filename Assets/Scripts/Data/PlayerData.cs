using System;

namespace Orion.Data
{
    [Serializable]
    public class PlayerData
    {
        public ResourceData Coins;
        public ItemsData Characters;
        public int BestScore;
        public Effect Lighting;
        public Effect Shield;
        public Effect Fire;
        public LevelsData Levels;
        
        public float Music;
        public float Sound;
        public bool Vibration;
    }
}