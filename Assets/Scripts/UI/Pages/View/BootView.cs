using Orion.UI.Pages.Presenters;
using UnityEngine;
using UnityEngine.UI;

namespace Orion.UI.Pages.View
{
    public class BootView : ViewBase, IView<BootView>
    {
        private IPresenter<BootView> _presenter;
        
        public Slider Slider;
        public AnimationCurve Curve;

        public override void Initialize()
        {
            _presenter = DiContainer.Instantiate<BootPresenter>();
            _presenter.Initialize(this);
        }

        public override void SubscribeUpdates()
        {
        }

        public override void Clean()
        {
            _presenter.Clear();
        }

        public BootView GetView() => this;
    }
}