using System;
using TMPro;
using UniRx;
using UnityEngine;

namespace Orion.System
{
    public class Timer : IDisposable
    {
        private CompositeDisposable _disposable = new CompositeDisposable();
        private TextMeshProUGUI _timerText;
        protected readonly int Seconds;
        private Action _onStopped;
        private float _time;

        public Timer(TextMeshProUGUI timerText, int seconds, Action onStopped)
        {
            _onStopped = onStopped;
            Seconds = seconds;
            _timerText = timerText;
        }

        public void Dispose()
        {
            if (_disposable != null)
            {
                _disposable.Clear();
                _disposable.Dispose();
                _disposable = null;
            }
        }

        public void StartTimer()
        {
            _time = Seconds;
            Observable.EveryUpdate().Subscribe(_ =>
            {
                _time -= Time.deltaTime;

                if (_time <= 0)
                {
                    _time = 0;
                    _onStopped?.Invoke();
                    _disposable.Clear();
                }
                SetView(_time);
            }).AddTo(_disposable);
        }

        public void AddTime(float seconds) => _time += seconds;

        public void StopTimer()
        {
            _disposable.Clear();
        }

        protected virtual void SetView(float time)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            _timerText.text = $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
        }
    }
}