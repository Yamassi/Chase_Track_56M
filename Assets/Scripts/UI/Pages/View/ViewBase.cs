using System.Threading.Tasks;
using Orion.Data;
using Orion.System.Audio;
using Orion.System.UI;
using UnityEngine;
using Zenject;

namespace Orion.UI.Pages.View
{
    public abstract class ViewBase : MonoBehaviour, ITransitionable
    {
        [field:SerializeField] public GameObject[] TransitionElements { get; protected set; }
        protected IUIFactory UIFactory;
        protected DataService DataService;
        protected AudioService AudioService;
        protected DiContainer DiContainer;

        [Inject]
        public void Construct(IUIFactory uiFactory,
            DataService dataService,
            AudioService audioService,
            DiContainer diContainer)
        {
            DiContainer = diContainer;
            AudioService = audioService;
            DataService = dataService;
            UIFactory = uiFactory;
        }

        public abstract void Initialize();

        public abstract void SubscribeUpdates();

        public abstract void Clear();

        public void PreInitialize()
        {
            for (int i = 0; i < TransitionElements.Length; i++)
            {
                TransitionElements[i].transform.localScale = Vector3.zero;
            }
        }

        public async Task TransitionIn() => 
            await Transitions.TransitionIn(TransitionElements);

        public async Task TransitionOut() => 
            await Transitions.TransitionOut(TransitionElements);
        private void OnDisable() => Clear();
    }
}