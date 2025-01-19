using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Orion.UI.Pages.View
{
    public class EffectItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _duration, _price;
        [SerializeField] private Button _buy;
        [SerializeField] private Slider _slider;

        public void Initialize(int id, Action<int> onBuy, int duration, int price, int level)
        {
            _buy.onClick.AddListener(()=>onBuy?.Invoke(id));
            SetDuration(duration);
            SetPrice(price);
            SetLevel(level);
        }
        
        public void SetDuration(int duration) => 
            _duration.text = $"{duration} Sec";

        public void SetPrice(int price) => 
            _price.text = price.ToString();

        public void SetLevel(int level)
        {
            _slider.value = level;

            if (level >= _slider.maxValue)
            {
                _price.text = "Full";
                _buy.onClick.RemoveAllListeners();
            }
        }
    }
}