namespace Orion.UI.Elements
{
    public class ModalWindowSelector : PageSelector
    {
        protected override void Select() => UIFactory.CreateModalWindow(_pageId);
    }
}