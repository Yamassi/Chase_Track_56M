using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Orion.UI.Pages.View.GamePlayUI
{
    public class Lose : GamePlayPage
    {
        [SerializeField] private Button _restart, _exit;
        [SerializeField] private TextMeshProUGUI _score;

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

        public void SetResults(int score)
        {
            _score.text = $"Your score: {score}";
        }
    }
}