using Orion.UI.Pages.Presenters;

namespace Orion.UI.Pages.View
{
    public class CharactersView : ViewBase, IView<CharactersView>
    {
        private IPresenter<CharactersView> _presenter;
        public override void Initialize()
        {
            _presenter = DiContainer.Instantiate<CharactersPresenter>();
            _presenter.Initialize(this);
        }

        public override void SubscribeUpdates()
        {
            
        }

        public override void Clear()
        {
            _presenter.Clear();
        }
        public CharactersView GetView() => this;
    }
}