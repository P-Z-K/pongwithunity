using System.Collections.Generic;
using _Scripts.Composite;

namespace _Scripts.Root
{
    public class GameplayStateComposite : CompositeComponent
    {
        private readonly List<IComponent> _children = new List<IComponent>();
        private readonly GameplayState _gameplayState;

        public GameplayStateComposite(GameplayState gameplayState)
        {
            _gameplayState = gameplayState;
        }

        public override void AddChild(IComponent child)
        {
            _children.Add(child);
        }

        public override void Enter()
        {
            _gameplayState.EnterState();

            foreach (IComponent child in _children)
            {
                child.Enter();
            }
        }

        public override void Tick()
        {
            _gameplayState.Tick();

            foreach (IComponent child in _children)
            {
                child.Tick();
            }
        }

        public override void FixedTick()
        {
            _gameplayState.FixedTick();

            foreach (IComponent child in _children)
            {
                child.FixedTick();
            }
        }

        public override void Exit()
        {
            _gameplayState.ExitState();

            foreach (IComponent child in _children)
            {
                child.Exit();
            }
        }
    }
}