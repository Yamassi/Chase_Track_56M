using System;
using Orion.System.Audio;
using Orion.UI.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace Orion.UI.Pages.View.GamePlayUI
{
    public class Pause : GamePlayPage
    {
        [SerializeField] private Button _close, _continue;
        [SerializeField] private Button _restart, _exit;
        [SerializeField] private ToggleButton _sound, _music;
        private AudioService _audioService;

        public void Initialize(Action onRestart, Action onExit)
        {
            OnExit = onExit;
            OnRestart = onRestart;
            _music.Toggle(_audioService.IsMusicEnabled);
            _sound.Toggle(_audioService.IsSoundEnabled);
        }

        private void Awake()
        {
            _restart.onClick.AddListener(() => OnRestart?.Invoke());
            _exit.onClick.AddListener(() => OnExit?.Invoke());
            _close.onClick.AddListener(Close);
            _continue.onClick.AddListener(Close);
            _music.Button.onClick.AddListener(SwitchMusic);
            _sound.Button.onClick.AddListener(SwitchSound);
        }

        private void SwitchMusic() => _music.Toggle(_audioService.ToggleMusic());
        private void SwitchSound() => _sound.Toggle(_audioService.ToggleSound());
        private void Close() => Destroy(gameObject);
    }
}