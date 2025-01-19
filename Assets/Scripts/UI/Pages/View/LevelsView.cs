using Orion.UI.Pages.Presenters;

namespace Orion.UI.Pages.View
{
    public class LevelsView : ViewBase,IView<LevelsView>
    {
        private IPresenter<LevelsView> _presenter;
        public override void Initialize()
        {
            _presenter = DiContainer.Instantiate<LevelsPresenter>();
            _presenter.Initialize(this);
        }

        public override void SubscribeUpdates()
        {
            
        }

        public override void Clear()
        {
            _presenter.Clear();
        }
        public LevelsView GetView() => this;
    }
}