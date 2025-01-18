using System;
using System.Collections.Generic;

namespace Orion.Data
{
    [Serializable]
    public class RewardsData
    {
        public List<RewardData> Items;
        public DateTime NextReward;

        public RewardsData(List<RewardData> items, DateTime nextReward)
        {
            NextReward = nextReward;
            Items = items;
        }

        public void Complete(int id) => Items[id].State = TaskState.Complete;

        public void RewardTaked(int id)
        {
            Items[id].State = TaskState.RewardTaked;
            
            if (id < Items.Count - 1)
            {
                NextReward = DateTime.Now.AddDays(1);
            }
        }
    }
}