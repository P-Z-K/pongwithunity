using _Scripts.Composite;
using _Scripts.UI;

namespace _Scripts.Root
{
    public class StartMenuComponent : PrimitiveComponent
    {
        private readonly StartMenuController _startMenuController;

        public StartMenuComponent(StartMenuController startMenuController)
        {
            _startMenuController = startMenuController;
        }

        public override void Enter()
        {
            _startMenuController.Show();
        }

        public override void Exit()
        {
            _startMenuController.Hide();
        }
    }
}