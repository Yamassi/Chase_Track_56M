using Orion.Data;
using Orion.UI.Pages.View;

namespace Orion.UI.Pages.Presenters
{
    public class MissionsPresenter : PagePresenter<MissionsView>
    {
        public override void Initialize(IView<MissionsView> view)
        {
            base.Initialize(view);
            RefreshItems();
        }
        public override void Clear()
        {
            
        }

        private void RefreshItems()
        {
            var missions = DataService.PlayerData.Missions;
            for (var i = 0; i < missions.Items.Count; i++)
            {
                View.Missions[i].Initialize(i, GetReward,
                    missions.Items[i].Reward);

                switch (missions.Items[i].State)
                {
                    case TaskState.Uncomplete:
                        View.Missions[i].SetUncomplete();
                        break;
                    case TaskState.Complete:
                        View.Missions[i].SetComplete();
                        break;
                    case TaskState.RewardTaked:
                        View.Missions[i].SetTaked();
                        break;
                }
            }
        }
        public void GetReward(int id)
        {
            var dailyRewardsData = DataService.PlayerData.Missions;
            DataService.PlayerData.Coins.Add(dailyRewardsData.Items[id].Reward);
            dailyRewardsData.Items[id].State = TaskState.RewardTaked;

            RefreshItems();
        }
    }
}