using Orion.UI.Pages.Presenters;
using TMPro;
using UnityEngine.UI;

namespace Orion.UI.Pages.View
{
    public class CharactersView : ViewBase, IView<CharactersView>
    {
        public TextMeshProUGUI Name, Price;
        public Image Character;
        public Button Prev, Next, Buy, IapBuy;
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