using System.Collections.Generic;
using UnityEngine;

namespace Orion.StaticData
{
    [CreateAssetMenu(menuName = "Static Data/Page Static Data", fileName = "PageStaticData")]
    public class PagesStaticData : ScriptableObject
    {
        public List<PageConfig> Pages;
    }
}
