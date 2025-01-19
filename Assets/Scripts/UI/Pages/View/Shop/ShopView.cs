using Orion.UI.Pages.Presenters;

namespace Orion.UI.Pages.View.Shop
{
    public class ShopView : ViewBase, IView<ShopView>
    {
        public EffectItem[] Effects;
        private IPresenter<ShopView> _presenter;

        public override void Initialize()
        {
            _presenter = DiContainer.Instantiate<ShopPresenter>();
            _presenter.Initialize(this);
        }

        public override void SubscribeUpdates()
        {
        }

        public override void Clear()
        {
        }
        
        public ShopView GetView() => this;
    }
}