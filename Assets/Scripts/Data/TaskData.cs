using System;

namespace Orion.Data
{
    [Serializable]
    public class TaskData
    {
        public int Id;
        public TaskState State;
        public string Description;
        public int Reward;

        public TaskData(int id, TaskState state, string description, int reward)
        {
            Id = id;
            State = state;
            Description = description;
            Reward = reward;
        }
    }
}