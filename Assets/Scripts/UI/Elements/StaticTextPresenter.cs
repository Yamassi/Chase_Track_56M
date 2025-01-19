using Orion.Data;
using UnityEngine;
using Zenject;

namespace Orion.UI.Elements
{
    public abstract class StaticTextPresenter : MonoBehaviour
    {
        protected TextView TextView;
        protected DataService DataService;

        [Inject]
        public void Construct(DataService dataService)
        {
            DataService = dataService;
        }

        protected virtual void Awake()
        {
            TextView = GetComponent<TextView>();
        }
    }
}