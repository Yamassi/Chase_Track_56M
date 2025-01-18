using System;

namespace Orion.Data
{
    [Serializable]
    public class LevelData
    {
        public int Id;
        public bool IsOpen;
        public int Stars;
        public LevelData(int id, bool isOpen, int stars)
        {
            Id = id;
            IsOpen = isOpen;
            Stars = stars;
        }

        public void SetStars(int stars)
        {
            stars = Math.Clamp(stars, 0, 3);
            Stars = stars;
        }
    }
}