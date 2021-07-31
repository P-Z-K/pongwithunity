namespace _Scripts.UI
{
    public interface IMenu
    {
        public MenuType MenuType { get; }
        public void Show();
        public void Hide();
    }
}