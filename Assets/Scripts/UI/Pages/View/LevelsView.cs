using Orion.UI.Pages.Presenters;
using UnityEngine.UI;

namespace Orion.UI.Pages.View
{
    public class LevelsView : ViewBase,IView<LevelsView>
    {
        public Button Close;
        public LevelsItem[] Levels;
        private IPresenter<LevelsView> _presenter;
        public override void Initialize()
        {
            _presenter = DiContainer.Instantiate<LevelsPresenter>();
            _presenter.Initialize(this);
        }

        public override void SubscribeUpdates()
        {
            
        }

        public override void Clear()
        {
            _presenter.Clear();
        }
        public LevelsView GetView() => this;
    }
}