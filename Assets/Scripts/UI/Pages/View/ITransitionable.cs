using System.Threading.Tasks;
using UnityEngine;

namespace Orion.UI.Pages.View
{
    public interface ITransitionable
    {
        GameObject[] TransitionElements { get; }
        void PreInitialize();
        Task TransitionIn();
        Task TransitionOut();
    }
}