using Orion.GamePlay;
using Orion.StaticData;
using Orion.System.Resource;
using Orion.UI.Pages.View;
using Orion.UI.Pages.View.GamePlayUI;
using Zenject;

namespace Orion.UI.Pages.Presenters
{
    public class GamePresenter : PagePresenter<GameView>
    {
        private const string PausePath = "Prefabs/Modal/Pause";
        private const string WinPath = "Prefabs/Modal/Win";
        private const string LosePath = "Prefabs/Modal/Lose";
        private int _score;
        private IResourceFactory _resourceFactory;
        private GamePlayController _gamePlayController;

        [Inject]
        public void Construct(IResourceFactory resourceFactory, 
            GamePlayController gamePlayController)
        {
            _gamePlayController = gamePlayController;
            _resourceFactory = resourceFactory;
        }

        public override void Initialize(IView<GameView> view)
        {
            base.Initialize(view);
            
            View.Pause.onClick.AddListener(CreatePauseWindow);

            _gamePlayController.Initialize();
        }

        public override void Clear()
        {
            
        }
        
        private void Restart()
        {
            _gamePlayController.Clear();
            UIFactory.ChangePage(PageId.Game);
        }

        private void Exit()
        {
            _gamePlayController.Clear();
            UIFactory.ChangePage(PageId.MainMenu);
        }

        private async void CreatePauseWindow()
        {
            var pause = _resourceFactory.Instantiate<Pause>(PausePath, View.transform);
            pause.Initialize(Restart, Exit);
            await pause.TransitionIn();
        }

        private async void CreateWinWindow(int score, int rewardCoins)
        {
            var win = _resourceFactory.Instantiate<Win>(WinPath,View.transform);
            win.PreInitialize();
            win.Initialize(Restart, Exit);
            win.SetResults(score, rewardCoins);
            await win.TransitionIn();
            AudioService.Win();
        }

        private async void CreateLoseWindow(int score)
        {
            var lose = _resourceFactory.Instantiate<Lose>(LosePath, View.transform);
            lose.PreInitialize();
            lose.Initialize(Restart, Exit);
            lose.SetResults(score);
            await lose.TransitionIn();
            AudioService.Lose();
        }
    }
}