using Orion.StaticData;
using UnityEngine;

namespace Orion.System.UI
{
    public interface IUIFactory
    {
        void ChangePage(PageId pageId);
        void CreateModalWindow(PageId pageId);
        void CloseModalWindow(GameObject gameObject);
    }
}