using System;
using Zenject;

namespace _Scripts
{
    public class Root : IInitializable, ITickable, IFixedTickable
    {
        private State<Root> _currentState;

        private DiContainer TEST_diContainer;

        public Root(DiContainer diContainer)
        {
            TEST_diContainer = diContainer;
        }
        
        public void Initialize()
        {
            ChangeStateTo<StartState>();
        }

        public void Tick()
        {
            _currentState?.UpdateState();
        }

        public void FixedTick()
        {
            _currentState?.UpdatePhysicsState();
        }

        public void ChangeStateTo<T>() where T : State<Root>
        {
            _currentState?.ExitState();
            _currentState = TEST_diContainer.Instantiate<T>();
            _currentState?.EnterState();
        }
    }
}