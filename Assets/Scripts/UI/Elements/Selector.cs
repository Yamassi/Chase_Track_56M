using Orion.StaticData;
using Orion.System.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Orion.UI.Elements
{
    [RequireComponent(typeof(Button))]
    public abstract class Selector : MonoBehaviour
    {
        [SerializeField] protected PageId _pageId;
        [SerializeField] protected Button _button;
        protected IUIFactory UIFactory;

        [Inject]
        public void Construct(IUIFactory uiFactory) => UIFactory = uiFactory;

        private void OnValidate() => _button = GetComponent<Button>();
        private void OnEnable() => _button.onClick.AddListener(Select);
        private void OnDisable() => _button.onClick.RemoveAllListeners();
        protected abstract void Select();
    }
}