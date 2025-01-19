using System;

namespace Orion.Data
{
    [Serializable]
    public class TaskData
    {
        public int Id;
        public TaskState State;
        public int Reward;

        public TaskData(int id, TaskState state, int reward)
        {
            Id = id;
            State = state;
            Reward = reward;
        }
    }
}