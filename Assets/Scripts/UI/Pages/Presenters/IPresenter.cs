using Orion.UI.Pages.View;
using UnityEngine;

namespace Orion.UI.Pages.Presenters
{
    public interface IPresenter<T> where T : MonoBehaviour
    {
        void Initialize(IView<T> view);
        void Clear();
    }
}