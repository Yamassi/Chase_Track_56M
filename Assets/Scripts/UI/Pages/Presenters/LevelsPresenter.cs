using Orion.StaticData;
using Orion.UI.Pages.View;
using UnityEngine;

namespace Orion.UI.Pages.Presenters
{
    public class LevelsPresenter : PagePresenter<LevelsView>
    {
        public override void Initialize(IView<LevelsView> view)
        {
            base.Initialize(view);
            RefreshItems();
            View.Close.onClick.AddListener(Close);
        }
        public override void Clear()
        {
            View.Close.onClick.RemoveAllListeners();
        }
        private void RefreshItems()
        {
            var levels = DataService.PlayerData.Levels;
            for (var i = 0; i < levels.Levels.Count; i++)
            {
                View.Levels[i].Initialize(i,StartLevel,levels.Levels[i].Stars);

                if (levels.Levels[i].IsOpen)
                {
                    View.Levels[i].SetOpen();
                }
                else
                {
                    View.Levels[i].SetLock();
                }
            }
            
            View.Levels[levels.Current].SetCurrent();
        }

        private void StartLevel(int level)
        {
            PlayerPrefs.SetInt(StaticNames.Level, level);
            UIFactory.ChangePage(PageId.Game);
        }
        private void Close() => UIFactory.CloseModalWindow(View.gameObject);
    }
}