using NaughtyAttributes;
using Orion.Data;
using Orion.StaticData;
using Orion.System.Audio;
using Orion.System.UI;
using UnityEngine;
using Zenject;

namespace Orion
{
    public class Boot : MonoBehaviour
    {
        private UIFactory _uiFactory;
        private AudioService _audioService;
        private DataService _dataService;
        private PageService _pageService;

        [Inject]
        public void Construct(UIFactory uiFactory,
            AudioService audioService,
            DataService dataService,
            PageService pageService)
        {
            _pageService = pageService;
            _audioService = audioService;
            _dataService = dataService;
            _uiFactory = uiFactory;
        }

        private void Awake()
        {
            _pageService.LoadConfigs();
            _dataService.LoadPlayerData();
            _uiFactory.ChangePage(PageId.Boot);
            _audioService.Initialize();
        }

        [Button]
        private void Reset() => DataProvider.RemovePlayerData();

        private void OnApplicationFocus(bool isFocus)
        {
            if (!isFocus)
                _dataService.SavePlayerData();
        }

        private void OnApplicationQuit()
        {
            _dataService.SavePlayerData();
        }
    }
}