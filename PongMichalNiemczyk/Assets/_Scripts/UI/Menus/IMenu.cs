namespace _Scripts.UI.Menus
{
    public interface IMenu
    {
        public MenuType MenuType { get; }
        public void Show();
        public void Hide();
    }
}