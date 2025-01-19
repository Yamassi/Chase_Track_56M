namespace Orion.UI.Elements
{
    public class BestScoreTextPresenter : StaticTextPresenter
    {
        protected override void Awake()
        {
            base.Awake();
            TextView.SetText($"Best Score: {DataService.PlayerData.BestScore}");
        }
    }
}