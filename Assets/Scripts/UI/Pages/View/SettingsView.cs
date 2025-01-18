using Orion.UI.Elements;
using Orion.UI.Pages.Presenters;
using UnityEngine.UI;

namespace Orion.UI.Pages.View
{
    public class SettingsView : ViewBase, IView<SettingsView>
    {
        public Button Close;
        public ToggleButton Music, Sound;
        
        private IPresenter<SettingsView> _presenter;
        public override void Initialize()
        {
            _presenter = DiContainer.Instantiate<SettingsPresenter>();
            _presenter.Initialize(this);
        }

        public override void SubscribeUpdates()
        {
            
        }

        public override void Clean()
        {
            _presenter.Clear();
        }

        public SettingsView GetView() => this;
    }
}