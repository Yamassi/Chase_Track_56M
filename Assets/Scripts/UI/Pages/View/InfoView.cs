using Orion.UI.Pages.Presenters;

namespace Orion.UI.Pages.View
{
    public class InfoView : ViewBase,IView<InfoView>
    {
        private IPresenter<InfoView> _presenter;
        public override void Initialize()
        {
            _presenter = DiContainer.Instantiate<InfoPresenter>();
            _presenter.Initialize(this);
        }

        public override void SubscribeUpdates()
        {
            
        }

        public override void Clear()
        {
            _presenter.Clear();
        }
        public InfoView GetView() => this;
    }
}