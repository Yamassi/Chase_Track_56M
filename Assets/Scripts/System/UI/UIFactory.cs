using Orion.Data;
using Orion.StaticData;
using Orion.UI.Pages.View;
using UnityEngine;
using Zenject;

namespace Orion.System.UI
{
    public class UIFactory : MonoBehaviour, IUIFactory
    {
        private ViewBase _currentView;
        private PageService _pageService;
        private DiContainer _diContainer;

        [Inject]
        public void Construct(PageService pageService,
            DiContainer diContainer)
        {
            _diContainer = diContainer;
            _pageService = pageService;
        }

        public async void ChangePage(PageId pageId)
        {
            if (_currentView != null)
            {
                var outPage =  _currentView.GetComponent<ITransitionable>();
                await outPage.TransitionOut();
                Destroy(_currentView.gameObject);
            }

            PageConfig pageConfig = _pageService.GetPage(pageId);
            ViewBase view = _diContainer.InstantiatePrefab(pageConfig.Prefab, transform).GetComponent<ViewBase>();
            var inPage =  view.GetComponent<ITransitionable>();
            inPage.PreInitialize();
            
            view.Initialize();
            await inPage.TransitionIn();
            view.SubscribeUpdates();
            _currentView = view;
        }

        public async void CreateModalWindow(PageId pageId)
        {
            PageConfig pageConfig = _pageService.GetPage(pageId);
            ViewBase view = _diContainer.InstantiatePrefab(pageConfig.Prefab, transform).GetComponent<ViewBase>();
            var inPage =  view.GetComponent<ITransitionable>();
            inPage.PreInitialize();
            
            view.Initialize();
            await inPage.TransitionIn();
            view.SubscribeUpdates();
        }

        public async void CloseModalWindow(GameObject gameObject)
        {
            if (gameObject != null)
            {
                var outPage =  gameObject.GetComponent<ITransitionable>();
                await outPage.TransitionOut();
                Destroy(gameObject);
            }
        }

    }
}