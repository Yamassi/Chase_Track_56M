using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Orion.UI.Pages.View.GamePlayUI
{
    public class GamePlayPage : MonoBehaviour, ITransitionable
    {
        protected Action OnRestart;
        protected Action OnExit;
        protected Action OnNextLevel;
        [field:SerializeField] public GameObject[]  TransitionElements { get; private set;}
        public void PreInitialize()
        {
            for (int i = 0; i < TransitionElements.Length; i++)
            {
                TransitionElements[i].transform.localScale = Vector3.zero;
            }
        }
        public async Task TransitionIn()
        {
            Time.timeScale = 0;
            await Transitions.TransitionIn(TransitionElements);
        }

        public async Task TransitionOut()
        {
            await Transitions.TransitionOut(TransitionElements);
            Time.timeScale = 1;
        }

        protected async void Restart()
        {
            await TransitionOut();
            OnRestart?.Invoke();
        }

        protected async void Exit()
        {
            await TransitionOut();
            OnExit?.Invoke();
        }

        protected async void NextLevel()
        {
            await TransitionOut();
            OnNextLevel?.Invoke();
        }
    }
}