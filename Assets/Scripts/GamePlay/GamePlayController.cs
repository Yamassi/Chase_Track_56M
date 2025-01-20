using System;
using Cinemachine;
using NaughtyAttributes;
using Orion.Data;
using Orion.System.Audio;
using UnityEngine;
using Zenject;

namespace Orion.GamePlay
{
    public class GamePlayController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _camera;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Track _track;
        [SerializeField] private Spawner _spawner;
        private DataService _dataService;
        private AudioService _audioService;
        private const string WagonPath = "Prefabs/Wagons/Wagon";
        private Wagon _wagon;

        [Inject]
        public void Construct(DataService dataService, AudioService audioService)
        {
            _audioService = audioService;
            _dataService = dataService;
        }

        public void Initialize(Action onCoin,Action onEnemy)
        {
            gameObject.SetActive(true);

            _spawner.Initialize(_track.LineRenderer);
            _track.GenerateTracks();
            _spawner.RandomSpawn();
            SpawnWagon(onCoin,onEnemy);
        }


        public void ReverseWagon()
        {
            _wagon.Reverse();
            var transposer = _camera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>();
            float offsetX = _wagon.IsReversed ? -1.8f : 1.8f;
            transposer.m_TrackedObjectOffset = new Vector3(offsetX, 0, 0);
        }
        private void SpawnWagon(Action onCoin,Action onEnemy)
        {
            Wagon wagon = Resources.Load<GameObject>(WagonPath+_dataService.PlayerData.Characters.Current).GetComponent<Wagon>();
           _wagon = Instantiate(wagon, _startPoint.position, Quaternion.identity,transform);
           _wagon.Initialize(Generate,onCoin,onEnemy);
           _camera.Follow = _wagon.transform;
           _camera.LookAt = _wagon.transform;
        }


        private void Generate()
        {
            _track.ClearTracks();
            _spawner.Clear();
            
            _track.GenerateTracks();
            _spawner.RandomSpawn();
        }

        public void Clear()
        {
            if (_wagon != null)
            {
                Destroy(_wagon.gameObject);
            }
            
            gameObject.SetActive(false);
        }
    }
}