using _Scripts.Composite;
using _Scripts.UI;

namespace _Scripts.Root
{
    public class GameplayMenuComponent : PrimitiveComponent
    {
        private readonly GameplayMenuController _gameplayMenuController;

        public GameplayMenuComponent(GameplayMenuController gameplayMenuController)
        {
            _gameplayMenuController = gameplayMenuController;
        }

        public override void Enter()
        {
            _gameplayMenuController.Show();
        }

        public override void Exit()
        {
            _gameplayMenuController.Hide();
        }
    }
}