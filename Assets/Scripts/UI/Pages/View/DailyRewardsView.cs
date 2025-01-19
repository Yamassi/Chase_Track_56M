using Orion.UI.Pages.Presenters;

namespace Orion.UI.Pages.View
{
    public class DailyRewardsView : ViewBase, IView<DailyRewardsView>
    {
        private IPresenter<DailyRewardsView> _presenter;
        public override void Initialize()
        {
            _presenter = DiContainer.Instantiate<DailyRewardsPresenter>();
            _presenter.Initialize(this);
        }

        public override void SubscribeUpdates()
        {
            
        }

        public override void Clear()
        {
            _presenter.Clear();
        }
        public DailyRewardsView GetView() => this;
    }
}