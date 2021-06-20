using System;

namespace _Scripts
{
    public class StateMachine<T>
    {
        private State<T> _currentState;
        private T _owner;

        public StateMachine(T owner)
        {
            _owner = owner;
        }

        public void ChangeState(State<T> newState)
        {
            // 
            if (newState == null)
                return;
            
            if (_currentState != null)
            {
                _currentState.ExitState();
            }
            
            _currentState = newState;

            _currentState.SetOwner(_owner);
            _currentState.EnterState();
        }

        public void Update()
        {
            _currentState?.UpdateState();
        }
    }
}
