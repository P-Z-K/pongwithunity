using System.Collections.Generic;
using _Scripts.Composite;

namespace _Scripts.Root
{
    public class GameplayStateComposite : CompositeComponent
    {
        private readonly GameplayState _gameplayState;

        public GameplayStateComposite(GameplayState gameplayState)
        {
            _gameplayState = gameplayState;
        }

        public override void Enter()
        {
            _gameplayState.EnterState();

            base.Enter();
        }

        public override void Tick()
        {
            _gameplayState.Tick();

            base.Tick();
        }

        public override void FixedTick()
        {
            _gameplayState.FixedTick();

            base.FixedTick();
        }

        public override void Exit()
        {
            base.Exit();
            
            _gameplayState.ExitState();
        }
    }
}