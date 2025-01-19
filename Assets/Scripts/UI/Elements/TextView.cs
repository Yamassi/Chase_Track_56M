using TMPro;
using UnityEngine;

namespace Orion.UI.Elements
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextView : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}