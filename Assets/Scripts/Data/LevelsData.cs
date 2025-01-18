using System;
using System.Collections.Generic;

namespace Orion.Data
{
    [Serializable]
    public class LevelsData
    {
        public int Current;
        public List<LevelData> Levels;

        public LevelsData(int current, List<LevelData> levels)
        {
            Current = current;
            Levels = levels;
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