using System;
using Cinemachine;
using Orion.Data;
using Orion.StaticData;
using Orion.System;
using Orion.System.Audio;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Orion.GamePlay
{
    public class GamePlayController : MonoBehaviour
    {
        public Wagon Wagon { get; private set; }
        [SerializeField] private CinemachineVirtualCamera _camera;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Track _track;
        [SerializeField] private Spawner _spawner;
        private DataService _dataService;
        private AudioService _audioService;
        private const string WagonPath = "Prefabs/Wagons/Wagon";

        [Inject]
        public void Construct(DataService dataService, AudioService audioService)
        {
            _audioService = audioService;
            _dataService = dataService;
        }

        public void Initialize(Action onCoin,Action onEnemy, Action<int> onEffect)
        {
            gameObject.SetActive(true);

            _spawner.Initialize(_track.LineRenderer);
            _track.GenerateTracks();
            _spawner.RandomSpawn();
            SpawnWagon(onCoin,onEnemy,onEffect);
        }


        public void ReverseWagon()
        {
            Wagon.Reverse();
            var transposer = _camera.GetCinemachineComponent<CinemachineFramingTransposer>();
            float offsetX = Wagon.IsReversed ? -1.8f : 1.8f;
            transposer.m_TrackedObjectOffset = new Vector3(offsetX, 0, 0);
        }
        private void SpawnWagon(Action onCoin,Action onEnemy,Action<int> onEffect)
        {
            int current = _dataService.PlayerData.Characters.Current;
            Wagon wagon = Resources.Load<GameObject>(WagonPath+current).GetComponent<Wagon>();
           Wagon = Instantiate(wagon, _startPoint.position, Quaternion.identity,transform);
           
           var effects = _dataService.PlayerData.Effects;
           
           EffectsDuration effectsDuration = new EffectsDuration(
               effects[0].Durations[effects[0].Level],
               effects[1].Durations[effects[1].Level],
               effects[2].Durations[effects[2].Level]);
           Wagon.Initialize(Generate,onCoin,onEnemy,onEffect,effectsDuration);
           _camera.Follow = Wagon.transform;
           _camera.LookAt = Wagon.transform;
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
            if (Wagon != null)
            {
                Destroy(Wagon.gameObject);
            }
            
            gameObject.SetActive(false);
        }
    }
}