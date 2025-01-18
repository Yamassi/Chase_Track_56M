using Orion.StaticData;

namespace Orion.System.UI
{
    public interface IUIFactory
    {
        void ChangePage(PageId pageId);
        void CreateModalWindow(PageId pageId);
    }
}