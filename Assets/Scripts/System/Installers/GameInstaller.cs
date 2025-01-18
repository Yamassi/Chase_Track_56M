using Orion.Data;
using Orion.GamePlay;
using Orion.System.Audio;
using Orion.System.Resource;
// using Orion.System.IAP;
using Orion.System.UI;
using UnityEngine;
using Zenject;

namespace Orion.System.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private AudioService _audioService;
        [SerializeField] private UIFactory _uiFactory;
        [SerializeField] private GamePlayController _gamePlayController;
        // [SerializeField] private IAPService _iapService;
        public override void InstallBindings()
        {
            BindServices();
        }

        private void BindServices()
        {
            Container.Bind<DataService>().FromNew().AsSingle();
            Container.Bind<PageService>().FromNew().AsSingle();
            Container.Bind<IResourceFactory>().To<ResourceFactory>().FromNew().AsSingle();
            Container.Bind<IResourceLoader>().To<ResourceLoader>().FromNew().AsSingle();
            Container.Bind<AudioService>().FromInstance(_audioService).AsSingle();
            Container.Bind<UIFactory>().FromInstance(_uiFactory).AsSingle();
            Container.Bind<IUIFactory>().FromInstance(_uiFactory).AsSingle();
            Container.Bind<GamePlayController>().FromInstance(_gamePlayController).AsSingle();
            // Container.Bind<IAPService>().FromInstance(_iapService).AsSingle();
        }
    }
}
