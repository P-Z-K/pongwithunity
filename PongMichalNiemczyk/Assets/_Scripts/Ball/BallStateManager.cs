using Zenject;

namespace _Scripts.Ball
{
    public class BallStateManager
    {
        public BallState CurrentState { get; private set; }
        private DiContainer _diContainer;

        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Update()
        {
            CurrentState?.UpdateState();
        }

        public void UpdatePhysics()
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