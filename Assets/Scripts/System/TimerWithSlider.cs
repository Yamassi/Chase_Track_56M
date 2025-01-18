using System;
using Orion.UI.Pages.Presenters;
using TMPro;
using UnityEngine.UI;

namespace Orion.System
{
    public class TimerWithSlider : Timer
    {
        private Slider _slider;

        public TimerWithSlider(TextMeshProUGUI timerText, int seconds, Action onStopped, Slider slider) : base(timerText, seconds,
            onStopped)
        {
            _slider = slider;
            _slider.maxValue = seconds;
        }

        protected override void SetView(float time)
        {
            base.SetView(time);
            _slider.value = time;
        }
    }
}