using Orion.System.Audio;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Orion.UI.Elements
{
    [RequireComponent(typeof(Button))]
    public class ButtonBase : MonoBehaviour
    {
        private AudioService _audioService;
        public Button Button;
        
        [Inject]
        public void Construct(AudioService audioService)
        {
            _audioService = audioService;
        }
        private void OnValidate() => Button = GetComponent<Button>();

        private void OnEnable() => Button.onClick.AddListener(Click);

        private void OnDisable() => Button.onClick.RemoveListener(Click);

        protected virtual void Click() => _audioService.Click();
    }
}