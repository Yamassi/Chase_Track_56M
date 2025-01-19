namespace Orion.UI.Elements
{
    public class LevelTextPresenter : StaticTextPresenter
    {
        protected override void Awake()
        {
            base.Awake();
            TextView.SetText($"Level {DataService.PlayerData.Levels.Current+1}");
        }
    }
}