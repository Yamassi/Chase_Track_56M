using Orion.StaticData;
using Orion.UI.Pages.View;
using UniRx;
using UnityEngine;

namespace Orion.UI.Pages.Presenters
{
    public class BootPresenter : PagePresenter<BootView>
    {
        private CompositeDisposable _disposable;
        
        public override void Initialize(IView<BootView> view)
        {
            base.Initialize(view);
            AudioService.PlayMenuMusic();
            StartLoading();
        }

        public override void Clear()
        {
            _disposable.Dispose();
        }
        
        private void StartLoading()
        {
            _disposable = new();

            float time = 0;
            float loading = 0;
            View.Slider.maxValue = 100;

            Observable.EveryUpdate().Subscribe(_ =>
            {
                time += Time.deltaTime;
                loading = View.Curve.Evaluate(time / 3) * 100;

                if (loading >= 100)
                {
                    loading = 100;
                    View.Slider.value = loading;
                    _disposable.Clear();

                    UIFactory.ChangePage(PageId.MainMenu);
                }

                View.Slider.value = loading;
            }).AddTo(_disposable);
        }
    }
}