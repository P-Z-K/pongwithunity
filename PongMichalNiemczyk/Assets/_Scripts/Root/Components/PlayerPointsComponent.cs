using _Scripts.Composite;
using _Scripts.UI;

namespace _Scripts.Root
{
    public class PlayerPointsComponent : PrimitiveComponent
    {
        private readonly PlayerPointsController _playerPointsController;

        public PlayerPointsComponent(PlayerPointsController playerPointsController)
        {
            _playerPointsController = playerPointsController;
        }

        public override void Enter()
        {
            _playerPointsController.SubscribeSignals();
        }

        public override void Exit()
        {
            _playerPointsController.UnsubscribeSignals();
        }
    }
}