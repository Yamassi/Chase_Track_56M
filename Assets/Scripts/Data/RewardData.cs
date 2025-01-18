using System;

namespace Orion.Data
{
    [Serializable]
    public class RewardData
    {
        public RewardData(int id, TaskState state, int reward)
        {
            Id = id;
            State = state;
            Reward = reward;
        }

        public int Id;
        public TaskState State;
        public int Reward;
    }
}