using UnityEngine;

namespace Orion.UI.Pages.View
{
    public interface IView<T> where T : MonoBehaviour
    {
        T GetView();
    }
}