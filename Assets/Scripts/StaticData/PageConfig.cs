using System;
using Orion.UI;
using Orion.UI.Pages;
using Orion.UI.Pages.View;

namespace Orion.StaticData
{
    [Serializable]
    public class PageConfig
    {
        public PageId PageId;
        public ViewBase Prefab;
    }
}