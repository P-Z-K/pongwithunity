using _Scripts.Composite;
using _Scripts.UI;

namespace _Scripts.Root.Components
{
    public class GameOverMenuComponent : PrimitiveComponent
    {
        private readonly GameOverMenuController _gameOverMenuController;

        public GameOverMenuComponent(GameOverMenuController gameOverMenuController)
        {
            _gameOverMenuController = gameOverMenuController;
        }

        public override void Enter()
        {
            _gameOverMenuController.Show();
        }

        public override void Exit()
        {
            _gameOverMenuController.Hide();
        }
    }
}