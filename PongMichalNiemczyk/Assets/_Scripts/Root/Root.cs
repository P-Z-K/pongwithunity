using System;
using Zenject;

namespace _Scripts
{
    public class Root : IInitializable, ITickable, IFixedTickable
    {
        private State<Root> _currentState;
        private DiContainer _diContainer;

        public Root(DiContainer diContainer)
        {
            _diContainer = diContainer;
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
            _currentState = _diContainer.Instantiate<T>();
            _currentState?.EnterState();
        }
    }
}