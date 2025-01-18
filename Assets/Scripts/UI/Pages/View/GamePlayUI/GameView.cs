using Orion.UI.Pages.Presenters;
using TMPro;
using UnityEngine.UI;

namespace Orion.UI.Pages.View.GamePlayUI
{
    public class GameView : ViewBase, IView<GameView>
    {
        private IPresenter<GameView> _presenter;
        public Button Pause;
        public TextMeshProUGUI ScoreTxt;

        public override void Initialize()
        {
            _presenter = DiContainer.Instantiate<GamePresenter>();
            _presenter.Initialize(this);
            AudioService.PlayGamePlayMusic();
        }

        public override void SubscribeUpdates()
        {
        }

        public override void Clean()
        {
        }

        public GameView GetView() => this;
    }
}