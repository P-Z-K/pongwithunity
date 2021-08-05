namespace _Scripts.UI
{
    public class GameplayMenuController
    {
        private readonly GameplayMenuView _gameplayMenuView;

        public GameplayMenuController(GameplayMenuView gameplayMenuView)
        {
            _gameplayMenuView = gameplayMenuView;
        }

        public void Show() => _gameplayMenuView.Show();

        public void Hide() => _gameplayMenuView.Hide();
    }
}