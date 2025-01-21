using Orion.GamePlay;
using Orion.StaticData;
using Orion.System;
using Orion.System.Resource;
using Orion.UI.Pages.View;
using Orion.UI.Pages.View.GamePlayUI;
using UnityEngine;
using Zenject;
using NotImplementedException = System.NotImplementedException;

namespace Orion.UI.Pages.Presenters
{
    public class GamePresenter : PagePresenter<GameView>
    {
        private const string PausePath = "Prefabs/Modal/Pause";
        private const string WinPath = "Prefabs/Modal/Win";
        private const string LosePath = "Prefabs/Modal/Lose";
        private int _coins;
        private int _hearts;
        private IResourceFactory _resourceFactory;
        private GamePlayController _gamePlayController;
        private Timer _timer;
        
        
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

            _gamePlayController.Initialize(GetCoin,Enemy,Effect);
            
            bool isLevels = PlayerPrefs.GetInt(StaticNames.GameMode) == 0;

            if (isLevels)
            {
                int currentLevel = DataService.PlayerData.Levels.Current +1;
                int seconds = 30;
                _timer = new Timer(View.Time, seconds * currentLevel, Win);
                _timer.StartTimer();
                
                View.Time.gameObject.SetActive(true);
            }
            else
            {
                View.Time.gameObject.SetActive(false);
            }

            _coins = 0;
            RefreshCoins();

            _hearts = 3;
            RefreshHearts();

            RefreshReverse();
            View.Up.onClick.AddListener(Reverse);
            View.Down.onClick.AddListener(Reverse);
        }

        public override void Clear()
        {
            if (_timer != null)
            {
                _timer.StopTimer();
                _timer.Dispose();
                _timer = null;
            }   
        }

        private void Reverse()
        {
            _gamePlayController.ReverseWagon();
            RefreshReverse();
        }

        private void RefreshReverse()
        {
            View.Up.gameObject.SetActive(_gamePlayController.Wagon.IsReversed);
            View.Down.gameObject.SetActive(!_gamePlayController.Wagon.IsReversed);
        }
        private void RefreshHearts() => 
            View.Hearts.SetActiveLowerElements(_hearts);

        private void RefreshCoins() => 
            View.Coins.text = _coins.ToString();

        private void Effect(int effect)
        {
            switch (effect)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }

        private void Win()
        {
            Debug.Log("Win");
        }
        private void GameOver()
        {
            Debug.Log("Game Over");
        }

        private void GetCoin()
        {
            _coins++;
            RefreshCoins();
        }

        private void Enemy()
        {
            _hearts--;
            RefreshHearts();
Debug.Log("Enemy hit");
            if (_hearts <= 0)
            {
                GameOver();
            }
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