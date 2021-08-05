using _Scripts.Composite;
using _Scripts.Players;
using Zenject;

namespace _Scripts.Root
{
    public class GameplayStateComposite : CompositeComponent
    {
        private readonly Root _root;
        private readonly SignalBus _signalBus;

        public GameplayStateComposite(SignalBus signalBus, Root root)
        {
            _signalBus = signalBus;
            _root = root;
        }

        public override void Enter()
        {
            SubscribeSignals();
            base.Enter();
        }

        private void SubscribeSignals()
        {
            _signalBus.Subscribe<PlayerWonSignal>(LoadGameOverState);
        }

        private void LoadGameOverState()
        {
            _root.CreateNewState<GameOverStateFactory>();
        }

        public override void Exit()
        {
            base.Exit();
            UnsubscribeSignals();
        }

        private void UnsubscribeSignals()
        {
            _signalBus.Unsubscribe<PlayerWonSignal>(LoadGameOverState);
        }
    }
}