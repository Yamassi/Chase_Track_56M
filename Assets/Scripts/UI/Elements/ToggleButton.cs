using System;
using UnityEngine;

namespace Orion.UI.Elements
{
    public class ToggleButton : ButtonBase, IToggle
    {
        [SerializeField] private GameObject Inactive, Active;
        public event Action OnToggle;
        public void Toggle(bool isEnabled)
        {
            if (isEnabled)
            {
                Inactive.SetActive(false);
                Active.SetActive(true);
            }
            else
            {
                Inactive.SetActive(true);
                Active.SetActive(false);
            }
        }

        protected override void Click()
        {
            base.Click();
            OnToggle?.Invoke();
        }
    }
}