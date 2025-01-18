using System.Collections.Generic;
using System.Linq;
using Orion.StaticData;
using UnityEngine;

namespace Orion.Data
{
    public class PageService
    {
        private Dictionary<PageId, PageConfig> _pageConfigs;
        private const string StaticDataPagesPath = "StaticData/UI/PagesStaticData";
        
        public void LoadConfigs()
        {
            _pageConfigs = Resources
                .Load<PagesStaticData>(StaticDataPagesPath)
                .Pages.ToDictionary(p => p.PageId, p => p);
        }

        public PageConfig GetPage(PageId pageId) =>
            _pageConfigs.TryGetValue(pageId, out PageConfig pageConfig)
                ? pageConfig
                : null;
    }
}