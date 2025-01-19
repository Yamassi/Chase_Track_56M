using System;

namespace Orion.Data
{
    [Serializable]
    public class PlayerData
    {
        public ResourceData Coins;
        public ItemsData Characters;
        public int BestScore;
        public EffectData[] Effects;
        public LevelsData Levels;
        public TasksData Missions;
        
        public float Music;
        public float Sound;
        public bool Vibration;
    }
}