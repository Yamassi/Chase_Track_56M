using Orion.UI.Pages.Presenters;
using UnityEngine.UI;

namespace Orion.UI.Pages.View
{
    public class GameModeView : ViewBase, IView<GameModeView>
    {
        public Button Infinity;
        private IPresenter<GameModeView> _presenter;
        public override void Initialize()
        {
            _presenter = DiContainer.Instantiate<GameModePresenter>();
            _presenter.Initialize(this);
        }

        public override void SubscribeUpdates()
        {
            
        }

        public override void Clear()
        {
            _presenter.Clear();
        }
        public GameModeView GetView() => this;
    }
}