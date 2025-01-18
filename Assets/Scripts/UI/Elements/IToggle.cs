using System;

namespace Orion.UI.Elements
{
    public interface IToggle
    {
        public void Toggle(bool isEnable);
        public event Action OnToggle;
    }
}