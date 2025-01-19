using System;

namespace Orion.Data
{
    [Serializable]
    public class EffectData
    {
        public int Level;
        public int MaxLevel;
        public int[] Price;
        public int[] Durations;

        public EffectData(int[] price, int[] durations)
        {
            Level = 0;
            MaxLevel = 4;
            Price = price;
            Durations = durations;
        }

        public void SetLevel(int level)
        {
            if (level > MaxLevel)
                return;
            
            Level = level;
        }
        public int GetCurrentPrice()
        {
            return Price[Level];
        }

        public int GetDuration()
        {
            return Durations[Level];
        }
    }
}