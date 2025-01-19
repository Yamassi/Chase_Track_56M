using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Orion.UI.Pages.View
{
    public static class Transitions
    {
        public static async Task TransitionIn(GameObject[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                await elements[i].gameObject.transform.DOScale(1, 0.1f).SetEase(Ease.OutBack).SetUpdate(true);
            }
        }
        public static async Task TransitionOut(GameObject[] elements)
        {
            for (int i = elements.Length-1; i >= 0 ; i--)
            {
                await elements[i].gameObject.transform.DOScale(0, 0.1f).SetEase(Ease.InBack).SetUpdate(true);
            }
             
        }
    }
}