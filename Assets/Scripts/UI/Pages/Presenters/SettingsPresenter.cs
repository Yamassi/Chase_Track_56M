using Orion.UI.Pages.View;
using UnityEngine;

namespace Orion.UI.Pages.Presenters
{
    public class SettingsPresenter : PagePresenter<SettingsView>
    {
        public override void Initialize(IView<SettingsView> view)
        {
            base.Initialize(view);
            
            View.Music.Toggle(AudioService.IsMusicEnabled);
            View.Sound.Toggle(AudioService.IsSoundEnabled);
            
            View.Close.onClick.AddListener(Close);
            View.Music.Button.onClick.AddListener(SwitchMusic);
            View.Sound.Button.onClick.AddListener(SwitchSound);
        }
        public override void Clear()
        {
            View.Close.onClick.RemoveAllListeners();
            View.Music.Button.onClick.RemoveAllListeners();
            View.Sound.Button.onClick.RemoveAllListeners();
        }
        private void Close() => UIFactory.CloseModalWindow(View.gameObject);
        private void SwitchMusic() => View.Music.Toggle(AudioService.ToggleMusic());
        private void SwitchSound() => View.Sound.Toggle(AudioService.ToggleSound());
    }
}