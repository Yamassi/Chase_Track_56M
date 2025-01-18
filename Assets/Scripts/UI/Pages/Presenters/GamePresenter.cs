using Orion.Data;
using Orion.GamePlay;
using Orion.StaticData;
using Orion.System.Audio;
using Orion.System.Resource;
using Orion.System.UI;
using Orion.UI.Pages.View;
using Orion.UI.Pages.View.GamePlayUI;
using Zenject;

namespace Orion.UI.Pages.Presenters
{
    public class GamePresenter : IPresenter<GameView>
    {
        private const string PausePath = "Prefabs/Modal/Pause";
        private const string WinPath = "Prefabs/Modal/Win";
        private const string LosePath = "Prefabs/Modal/Lose";

        private int _score;
        private IResourceFactory _resourceFactory;
        private IUIFactory _uiFactory;
        private AudioService _audioService;
        private GamePlayController _gamePlayController;
        private DataService _dataService;
        private GameView _view;

        [Inject]
        public void Construct(DataService dataService, 
            IResourceFactory resourceFactory, 
            IUIFactory uiFactory,
            AudioService audioService,
            GamePlayController gamePlayController)
        {
            _dataService = dataService;
            _gamePlayController = gamePlayController;
            _audioService = audioService;
            _uiFactory = uiFactory;
            _resourceFactory = resourceFactory;
        }

        public void Initialize(IView<GameView> view)
        {
            _view = view.GetView();
            
            _view.Pause.onClick.AddListener(CreatePauseWindow);

            _gamePlayController.Initialize();
        }

        public void Clear()
        {
            
        }
        
        private void Restart()
        {
            _gamePlayController.Clear();
            _uiFactory.ChangePage(PageId.Game);
        }

        private void Exit()
        {
            _gamePlayController.Clear();
            _uiFactory.ChangePage(PageId.MainMenu);
        }

        private async void CreatePauseWindow()
        {
            var pause = _resourceFactory.Instantiate<Pause>(PausePath, _view.transform);
            pause.Initialize(Restart, Exit);
            await pause.TransitionIn();
        }

        private async void CreateWinWindow(int score, int rewardCoins)
        {
            var win = _resourceFactory.Instantiate<Win>(WinPath,_view.transform);
            win.PreInitialize();
            win.Initialize(Restart, Exit);
            win.SetResults(score, rewardCoins);
            await win.TransitionIn();
            _audioService.Win();
        }

        private async void CreateLoseWindow(int score)
        {
            var lose = _resourceFactory.Instantiate<Lose>(LosePath, _view.transform);
            lose.PreInitialize();
            lose.Initialize(Restart, Exit);
            lose.SetResults(score);
            await lose.TransitionIn();
            _audioService.Lose();
        }
    }
}