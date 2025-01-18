using System;
using System.Collections.Generic;

namespace Orion.Data
{
    [Serializable]
    public class TasksData
    {
        public List<TaskData> Items;

        public TasksData(List<TaskData> items)
        {
            Items = items;
        }

        public void CompleteTask(int id) => Items[id].State = TaskState.Complete;
        public void RewardTaked(int id) => Items[id].State = TaskState.RewardTaked;
    }
}