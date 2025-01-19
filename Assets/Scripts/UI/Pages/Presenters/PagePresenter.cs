using Orion.Data;
using Orion.System.Audio;
using Orion.System.UI;
using Orion.UI.Pages.View;
using UnityEngine;
using Zenject;

namespace Orion.UI.Pages.Presenters
{
    public abstract class PagePresenter<T> : IPresenter<T> where T : MonoBehaviour
    {
        protected T View;
        protected AudioService AudioService;
        protected DataService DataService;
        protected IUIFactory UIFactory;


        [Inject]
        public void Construct(AudioService audioService, DataService dataService, IUIFactory factory)
        {
            AudioService = audioService;
            DataService = dataService;
            UIFactory = factory;
        }

        public virtual void Initialize(IView<T> view)
        {
            View = view.GetView();
        }

        public abstract void Clear();
    }
}