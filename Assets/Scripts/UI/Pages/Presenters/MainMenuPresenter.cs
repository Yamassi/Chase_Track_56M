using Orion.System.Audio;
using Orion.UI.Pages.View;
using UnityEngine;
using Zenject;

namespace Orion.UI.Pages.Presenters
{
    public class MainMenuPresenter : IPresenter<MainMenuView>
    {
        private AudioService _audioService;
        private MainMenuView _view;

        [Inject]
        public void Construct(AudioService audioService)
        {
            _audioService = audioService;
        }

        public void Initialize(IView<MainMenuView> view)
        {
            _view = view.GetView();
            _audioService.PlayMenuMusic();
        }

        public void Clear()
        {
            
        }
    }
}