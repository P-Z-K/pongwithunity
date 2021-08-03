using _Scripts.Root;
using Zenject;

namespace _Scripts.Ball
{
    public class BallStateManager
    {
        private DiContainer _diContainer;
        public State<BallStateManager> CurrentState { get; private set; }

        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Tick()
        {
            CurrentState?.Tick();
        }

        public void FixedTick()
        {
            CurrentState?.FixedTick();
        }

        public void ChangeStateTo<T>() where T : State<BallStateManager>
        {
            CurrentState?.ExitState();
            CurrentState = _diContainer.Instantiate<T>();
            CurrentState?.EnterState();
        }
    }
}