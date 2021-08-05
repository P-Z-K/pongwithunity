using System.Collections.Generic;
using _Scripts.Composite;

namespace _Scripts.Root
{
    public class GameOverStateComposite : CompositeComponent
    {
        private readonly GameOverState _gameOverState;
        
        public GameOverStateComposite(GameOverState gameOverState)
        {
            _gameOverState = gameOverState;
        }

        public override void Enter()
        {
            _gameOverState.EnterState();

            base.Enter();
        }

        public override void Tick()
        {
            _gameOverState.Tick();

            base.Tick();
        }

        public override void FixedTick()
        {
            _gameOverState.FixedTick();

            base.FixedTick();
        }

        public override void Exit()
        {
            base.Exit();
            
            _gameOverState.ExitState();
        }
    }
}