using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Orion.UI.Pages.View.GamePlayUI
{
    public class Win : GamePlayPage
    {
        [SerializeField] private Button _restart, _exit;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private TextMeshProUGUI _rewardCoins;

        private void Awake()
        {
            _restart.onClick.AddListener(() => OnRestart?.Invoke());
            _exit.onClick.AddListener(() => OnExit?.Invoke());
        }

        public void Initialize(Action onRestart, Action onExit)
        {
            OnExit = onExit;
            OnRestart = onRestart;
        }

        public void SetResults(int score, int rewardCoins)
        {
            _score.text = $"Your score: {score}";
            _rewardCoins.text = rewardCoins.ToString();
        }
    }
}