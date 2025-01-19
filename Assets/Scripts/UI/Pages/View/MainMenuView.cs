using Orion.UI.Pages.Presenters;
using UnityEngine.UI;

namespace Orion.UI.Pages.View
{
    public class MainMenuView : ViewBase, IView<MainMenuView>
    {
        public Image Character;
        public Button Prev,Next;
        private IPresenter<MainMenuView> _presenter;
        public override void Initialize()
        {
            _presenter = DiContainer.Instantiate<MainMenuPresenter>();
            _presenter.Initialize(this);
        }

        public override void SubscribeUpdates()
        {
        }

        public override void Clear()
        {
            _presenter.Clear();
        }


        public MainMenuView GetView() => this;
    }
}