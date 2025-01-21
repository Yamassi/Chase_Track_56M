using System;
using Orion.System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Orion.UI.Pages.View.GamePlayUI
{
    public class Win : GamePlayPage
    {
        [SerializeField] private Button _restart, _exit,_next;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private Image[] _crowns;


        private void Awake()
        {
            _restart.onClick.AddListener(() => OnRestart?.Invoke());
            _exit.onClick.AddListener(() => OnExit?.Invoke());
            _next.onClick.AddListener(() => OnNextLevel?.Invoke());
        }

        public void Initialize(Action onRestart, Action onExit, Action onNext)
        {
            OnNextLevel = onNext;
            OnExit = onExit;
            OnRestart = onRestart;
            
        }

        public void SetResults(int score, int crowns)
        {
            _score.text = $"Your score: {score}";
            _crowns.SetActiveLowerElements(crowns);
        }
    }
}