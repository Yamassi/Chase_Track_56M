using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Orion.UI.Elements
{
    public class Currency : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currency;
        private Color _baseColor = Color.white;
        private Color _addColor = Color.green;
        private Color _removeColor = Color.red;
        private Tween _tween;
        private void OnValidate() =>
            _currency.color = _baseColor;

        private void OnDestroy() =>
            _tween.Kill();

        public void SetCurrency(int currency) =>
            SetCurrency(currency.ToString());

        public void AddCurrency(int currency) =>
            AddCurrency(currency.ToString());

        public void RemoveCurrency(int currency) =>
            RemoveCurrency(currency.ToString());

        public void SetCurrency(string currency)
        {
            _currency.text = currency;
        }

        public void AddCurrency(string currency)
        {
            _currency.text = currency;
            BounceAnimation();
            ColorAnimation(_addColor);
        }

        public void RemoveCurrency(string currency)
        {
            _currency.text = currency;
            BounceAnimation();
            ColorAnimation(_removeColor);
        }

        private void BounceAnimation()
        {
            _tween = _currency.transform
                .DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.5f);
        }

        private async void ColorAnimation(Color color)
        {
            _currency.color = color;
            await UniTask.Delay(500);
            _currency.color = _baseColor;
        }
    }
}