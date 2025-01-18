using Orion.System.Audio;
using Orion.UI.Pages.View;
using UnityEngine;
using Zenject;

namespace Orion.UI.Pages.Presenters
{
    public class SettingsPresenter : IPresenter<SettingsView>
    {
        private AudioService _audioService;
        private SettingsView _view;

        [Inject]
        public void Construct(AudioService audioService)
        {
            _audioService = audioService;
        }
        public void Initialize(IView<SettingsView> view)
        {
            _view = view.GetView();
            
            _view.Music.Toggle(_audioService.IsMusicEnabled);
            _view.Sound.Toggle(_audioService.IsSoundEnabled);
            
            _view.Close.onClick.AddListener(Close);
            _view.Music.Button.onClick.AddListener(SwitchMusic);
            _view.Sound.Button.onClick.AddListener(SwitchSound);
        }
        public void Clear()
        {
            
        }
        private void Close() => GameObject.Destroy(_view.gameObject);
        private void SwitchMusic() => _view.Music.Toggle(_audioService.ToggleMusic());
        private void SwitchSound() => _view.Sound.Toggle(_audioService.ToggleSound());
    }
}