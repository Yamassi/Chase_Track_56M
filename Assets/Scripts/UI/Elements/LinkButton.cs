using System;
using UnityEngine;
using UnityEngine.UI;

namespace Orion.UI.Elements
{
    [RequireComponent(typeof(Button))]
    public class LinkButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private String URL;

        private void OnValidate() => _button = GetComponent<Button>();
        private void OnEnable() => _button.onClick.AddListener(OpenLink);
        private void OnDisable() => _button.onClick.RemoveListener(OpenLink);
        private void OpenLink() => Application.OpenURL(URL);
    }
}