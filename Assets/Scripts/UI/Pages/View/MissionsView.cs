using Orion.UI.Pages.Presenters;

namespace Orion.UI.Pages.View
{
    public class MissionsView : ViewBase,IView<MissionsView>
    {
        private IPresenter<MissionsView> _presenter;
        public override void Initialize()
        {
            _presenter = DiContainer.Instantiate<MissionsPresenter>();
            _presenter.Initialize(this);
        }

        public override void SubscribeUpdates()
        {
            
        }

        public override void Clear()
        {
            _presenter.Clear();
        }
        public MissionsView GetView() => this;
    }
}