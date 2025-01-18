using System;
using TMPro;
using UnityEngine;

namespace Orion.UI.Elements
{
    public class ToggleTxtButton : ButtonBase, IToggle
    {
        [SerializeField] private string _name;
        [SerializeField] private TextMeshProUGUI _text;
        public event Action OnToggle;
        public void Toggle(bool isEnabled)
        {
            if (isEnabled)
            {
                _text.text = $"{_name}:On";
            }
            else
            {
                _text.text = $"{_name}:Off";
            }
        }
        
        protected override void Click()
        {
            Debug.Log("Click");
            base.Click();
            OnToggle?.Invoke();
        }
    }
}