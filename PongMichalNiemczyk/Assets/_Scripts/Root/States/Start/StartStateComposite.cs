using System.Collections.Generic;
using _Scripts.Composite;

namespace _Scripts.Root
{
    public class StartStateComposite : CompositeComponent
    {
        private readonly StartState _startState;

        public StartStateComposite(StartState startState)
        {
            _startState = startState;
        }

        public override void Enter()
        {
            _startState.EnterState();

            base.Enter();
        }

        public override void Tick()
        {
            _startState.Tick();

            base.Tick();
        }

        public override void FixedTick()
        {
            _startState.FixedTick();

            base.FixedTick();
        }

        public override void Exit()
        {
            base.Exit();

            _startState.ExitState();
        }
    }
}