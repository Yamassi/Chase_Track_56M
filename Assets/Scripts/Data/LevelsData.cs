using System;
using System.Collections.Generic;

namespace Orion.Data
{
    [Serializable]
    public class LevelsData
    {
        public int Current;
        public List<LevelData> Levels;

        public LevelsData(int levelsCount)
        {
            Current = 0;

            Levels = new List<LevelData>();
            
            for (var i = 0; i < levelsCount; i++)
            {
                Levels.Add(new LevelData(i,i==0,0));
            }
        }
        public void OpenNextLevel()
        {
            if (Current != Levels.Count - 1)
            {
                Levels[++Current].IsOpen = true;
            }
        }
    }
}