using System;
using Orion.StaticData;
using Orion.System.Audio;
using Orion.System.UI;
using Orion.UI.Pages.View;
using UniRx;
using UnityEngine;
using Zenject;

namespace Orion.UI.Pages.Presenters
{
    public class BootPresenter : IPresenter<BootView>
    {
        private CompositeDisposable _disposable;
        private BootView _view;
        private AudioService _audioService;
        private IUIFactory _uiFactory;

        [Inject]
        public void Construct(AudioService audioService,
            IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _audioService = audioService;
        }

        public void Initialize(IView<BootView> view)
        {
            _view = view.GetView();
            _audioService.PlayMenuMusic();
            StartLoading();
        }

        public void Clear()
        {
            _disposable.Dispose();
        }
        
        private void StartLoading()
        {
            _disposable = new();

            float time = 0;
            float loading = 0;
            _view.Slider.maxValue = 100;

            Observable.EveryUpdate().Subscribe(_ =>
            {
                time += Time.deltaTime;
                loading = _view.Curve.Evaluate(time / 3) * 100;

                if (loading >= 100)
                {
                    loading = 100;
                    _view.Slider.value = loading;
                    _disposable.Clear();

                    _uiFactory.ChangePage(PageId.MainMenu);
                }

                _view.Slider.value = loading;
            }).AddTo(_disposable);
        }
    }
}