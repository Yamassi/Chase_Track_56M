using System;
using Cysharp.Threading.Tasks;
using Orion.Data;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace Orion.System.Audio
{
    public class AudioService : MonoBehaviour
    {
        [SerializeField] protected AudioMixer _audioMixer;
        [SerializeField] private AudioSource _musicPlayer;
        [SerializeField] private AudioSource _soundPlayer;
        [SerializeField] private AudioClip[] _gamePlayMusic;
        [SerializeField] private AudioClip[] _menuMusic;
        [SerializeField] private AudioClip[] _sounds;
        private DataService _dataService;

        private bool _isMainMenu;
        private bool _isSoundEnabled;
        private bool _isVibrationEnabled;
        private bool _isMusicEnabled;

        [Inject]
        public void Inject(DataService dataService)
        {
            _dataService = dataService;
        }

        public async void Initialize()
        {
            await UniTask.Delay(100);
            LoadVolumes();
        }

        public void LoadVolumes()
        {
            SetSoundVolume(_dataService.PlayerData.Sound);
            SetMusicVolume(_dataService.PlayerData.Music);

            _isMusicEnabled = _dataService.PlayerData.Music == 1;
            _isSoundEnabled = _dataService.PlayerData.Sound == 1;
        }

        public void SetSoundVolume(float volume)
        {
            _audioMixer.SetFloat("Sound", Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20);
            _dataService.PlayerData.Sound = volume;
        }

        public void SetMusicVolume(float volume)
        {
            _audioMixer.SetFloat("Music", Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20);
            _dataService.PlayerData.Music = volume;
        }

        public void Click() => PlaySound(_sounds[0]);
        public void Win() => PlaySound(_sounds[1]);
        public void Lose() => PlaySound(_sounds[2]);
        public void Swipe() => PlaySound(_sounds[3]);
        public void Match() => PlaySound(_sounds[4]);
        public void Explosion() => PlaySound(_sounds[5]);
        public void Time() => PlaySound(_sounds[6]);
        public void Trash() => PlaySound(_sounds[7]);

        private void PlaySound(AudioClip audio)
        {
            if (audio != null)
                _soundPlayer.PlayOneShot(audio);
        }

        private void PlayMusic(AudioClip audio)
        {
            if (audio != null)
            {
                _musicPlayer.Stop();
                _musicPlayer.clip = audio;
                _musicPlayer.Play();
            }
        }

        public void PlayRandomMusic()
        {
            if (_menuMusic == null || _menuMusic.Length == 0)
                return;

            if (_gamePlayMusic == null || _gamePlayMusic.Length == 0)
                return;

            if (_isMainMenu)
            {
                int randomMusic = UnityEngine.Random.Range(0, _menuMusic.Length);
                PlayMusic(_menuMusic[randomMusic]);
            }

            else
            {
                int randomMusic = UnityEngine.Random.Range(0, _gamePlayMusic.Length);
                PlayMusic(_gamePlayMusic[randomMusic]);
            }
        }

        public void PlayMenuMusic()
        {
            if (_menuMusic == null || _menuMusic.Length == 0)
                return;

            if (_musicPlayer.clip != _menuMusic[0])
            {
                _isMainMenu = true;
                PlayRandomMusic();
            }
        }

        public void PlayGamePlayMusic()
        {
            if (_gamePlayMusic == null || _gamePlayMusic.Length == 0)
                return;

            if (_musicPlayer.clip != _gamePlayMusic[0])
            {
                _isMainMenu = false;
                PlayRandomMusic();
            }
        }

        public bool ToggleSound()
        {
            _isSoundEnabled = !_isSoundEnabled;
            UpdateVolume();
            return _isSoundEnabled;
        }

        public bool ToggleMusic()
        {
            _isMusicEnabled = !_isMusicEnabled;
            UpdateVolume();
            return _isMusicEnabled;
        }

        public bool ToggleVibration()
        {
            _isVibrationEnabled = !_isVibrationEnabled;
            _dataService.PlayerData.Vibration = IsVibrationEnabled;
            return _isVibrationEnabled;
        }

        public bool IsSoundEnabled => _isSoundEnabled;
        public bool IsMusicEnabled => _isMusicEnabled;
        public bool IsVibrationEnabled => _isVibrationEnabled;

        private void UpdateVolume()
        {
            int soundVolume = _isSoundEnabled ? 1 : 0;
            int musicVolume = _isMusicEnabled ? 1 : 0;

            SetSoundVolume(soundVolume);
            SetMusicVolume(musicVolume);
        }

        private void Update()
        {
            if (!_musicPlayer.isPlaying)
            {
                PlayMusic(_musicPlayer.clip);
            }
        }
    }
}