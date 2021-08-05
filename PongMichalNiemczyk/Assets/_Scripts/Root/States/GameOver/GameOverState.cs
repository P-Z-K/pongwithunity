using _Scripts.UI.Signals;
using UnityEngine;
using Zenject;

namespace _Scripts.Root
{
    public class GameOverState : State<Root>
    {
        private readonly SignalBus _signalBus;

        public GameOverState(Root owner, SignalBus signalBus)
            : base(owner)
        {
            _signalBus = signalBus;
        }

        public override void EnterState()
        {
            SubscribeSignals();
        }

        private void SubscribeSignals()
        {
            _signalBus.Subscribe<PlayAgainButtonClickedSignal>(LoadGameplayState);
            _signalBus.Subscribe<QuitButtonClickedSignal>(QuitGame);
        }

        private void LoadGameplayState()
        {
            _owner.CreateNewState<GameplayStateFactory>();
        }

        private void QuitGame()
        {
            Debug.Log("Quit game");
        }

        public override void Tick()
        {
        }

        public override void FixedTick()
        {
        }

        public override void ExitState()
        {
            UnsubscribeSignals();
        }

        private void UnsubscribeSignals()
        {
            _signalBus.Unsubscribe<PlayAgainButtonClickedSignal>(LoadGameplayState);
            _signalBus.Unsubscribe<QuitButtonClickedSignal>(QuitGame);
        }
    }
}