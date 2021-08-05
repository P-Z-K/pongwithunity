using _Scripts.Ball;
using _Scripts.Composite;

namespace _Scripts.Root
{
    public class BallComponent : PrimitiveComponent
    {
        private readonly IBallFacade _ballFacade;

        public BallComponent(IBallFacade ballFacade)
        {
            _ballFacade = ballFacade;
        }

        public override void Enter()
        {
            _ballFacade.ChangeStateTo<BallStateWaitingForStart>();
        }

        public override void Tick()
        {
            _ballFacade.Tick();
        }

        public override void FixedTick()
        {
            _ballFacade.FixedTick();
        }
    }
}