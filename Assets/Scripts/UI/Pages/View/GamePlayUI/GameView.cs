using Orion.UI.Pages.Presenters;
using TMPro;
using UnityEngine.UI;

namespace Orion.UI.Pages.View.GamePlayUI
{
    public class GameView : ViewBase, IView<GameView>
    {
        public Button Pause;
        public TextMeshProUGUI Time,Coins;
        public Image[] Hearts;
        public Button Down, Up;
        private IPresenter<GameView> _presenter;
        public override void Initialize()
        {
            _presenter = DiContainer.Instantiate<GamePresenter>();
            _presenter.Initialize(this);
            
            AudioService.PlayGamePlayMusic();
        }

        public override void SubscribeUpdates()
        {
        }

        public override void Clear()
        {
            _presenter.Clear();
        }

        public GameView GetView() => this;
    }
}