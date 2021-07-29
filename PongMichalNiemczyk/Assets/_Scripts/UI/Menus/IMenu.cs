namespace _Scripts.UI.Menus
{
    public interface IMenu
    {
        public MenuType MenuType { get; }
        public bool IsVisible { get; set; }
    }
}