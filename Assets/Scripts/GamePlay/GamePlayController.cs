using Orion.Data;
using Orion.System.Audio;
using UnityEngine;
using Zenject;

namespace Orion.GamePlay
{
    public class GamePlayController : MonoBehaviour
    {
        private DataService _dataService;
        private AudioService _audioService;

        [Inject]
        public void Construct(DataService dataService, AudioService audioService)
        {
            _audioService = audioService;
            _dataService = dataService;
        }

        public void Initialize()
        {
            gameObject.SetActive(true);
        }

        public void Clear()
        {
            gameObject.SetActive(false);
        }
    }
}