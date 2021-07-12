using Zenject;

namespace _Scripts.Ball
{
    public class BallStateManager : ITickable, IInitializable, IFixedTickable
    {
        public BallState CurrentState { get; private set; }
        private readonly DiContainer _diContainer;

        public BallStateManager(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Initialize()
        {
        }

        public void Tick()
        {
            CurrentState?.UpdateState();
        }

        public void FixedTick()
        {
            CurrentState?.UpdatePhysicsState();
        }

        public void ChangeStateTo<T>() where T : BallState
        {
            CurrentState?.ExitState();
            CurrentState = _diContainer.Instantiate<T>();
            CurrentState?.EnterState();
        }
    }
}