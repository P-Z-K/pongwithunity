using System;
using UnityEngine;

namespace _Scripts
{
    public class Root : MonoBehaviour
    {
        private State<Root> _currentState;

        private void Awake()
        {
            ChangeStateTo<StartState>();
        }

        private void Update()
        {
            _currentState?.UpdateState();
        }

        private void FixedUpdate()
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