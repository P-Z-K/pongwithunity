using System.Collections.Generic;
using _Scripts.Composite;

namespace _Scripts.Root
{
    public class StartStateComposite : CompositeComponent
    {
        private readonly List<IComponent> _children = new List<IComponent>();
        private readonly StartState _startState;

        public StartStateComposite(StartState startState)
        {
            _startState = startState;
        }

        public override void AddChild(IComponent child)
        {
            _children.Add(child);
        }

        public override void Enter()
        {
            _startState.EnterState();

            foreach (IComponent child in _children)
            {
                child.Enter();
            }
        }

        public override void Tick()
        {
            _startState.Tick();

            foreach (IComponent child in _children)
            {
                child.Tick();
            }
        }

        public override void FixedTick()
        {
            _startState.FixedTick();

            foreach (IComponent child in _children)
            {
                child.FixedTick();
            }
        }

        public override void Exit()
        {
            _startState.ExitState();

            foreach (IComponent child in _children)
            {
                child.Exit();
            }
        }
    }
}