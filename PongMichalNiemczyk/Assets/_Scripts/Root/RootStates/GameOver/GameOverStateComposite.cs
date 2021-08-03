using System.Collections.Generic;
using _Scripts.Composite;

namespace _Scripts.Root
{
    public class GameOverStateComposite : CompositeComponent
    {
        private readonly List<IComponent> _children = new List<IComponent>();
        private readonly GameOverState _gameOverState;


        public GameOverStateComposite(GameOverState gameOverState)
        {
            _gameOverState = gameOverState;
        }

        public override void AddChild(IComponent child)
        {
            _children.Add(child);
        }

        public override void Enter()
        {
            _gameOverState.EnterState();

            foreach (IComponent child in _children)
                child.Enter();
        }

        public override void Tick()
        {
            _gameOverState.Tick();

            foreach (IComponent child in _children)
            {
                child.Tick();
            }
        }

        public override void FixedTick()
        {
            _gameOverState.FixedTick();

            foreach (IComponent child in _children)
            {
                child.FixedTick();
            }
        }

        public override void Exit()
        {
            _gameOverState.ExitState();

            foreach (IComponent child in _children)
            {
                child.Exit();
            }
        }
    }
}