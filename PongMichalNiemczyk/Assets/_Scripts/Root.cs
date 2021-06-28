using System;
using Zenject;

namespace _Scripts
{
    public class Root : IInitializable, ITickable, IFixedTickable
    {
        private State<Root> _currentState;
        
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
            _currentState = (T) Activator.CreateInstance(typeof(T), new object[] {this});
            _currentState?.EnterState();
        }
    }
}