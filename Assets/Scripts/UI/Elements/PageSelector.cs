namespace Orion.UI.Elements
{
    public class PageSelector : Selector
    {
        protected override void Select() => UIFactory.ChangePage(_pageId);
    }
}