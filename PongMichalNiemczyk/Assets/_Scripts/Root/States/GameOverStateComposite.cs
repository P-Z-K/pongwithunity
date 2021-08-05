using _Scripts.Composite;
using _Scripts.UI.Signals;
using UnityEngine;
using Zenject;

namespace _Scripts.Root
{
    public class GameOverStateComposite : CompositeComponent
    {
        private readonly SignalBus _signalBus;
        private readonly Root _root;

        public GameOverStateComposite(SignalBus signalBus, Root root)
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
            _signalBus.Subscribe<PlayAgainButtonClickedSignal>(LoadGameplayState);
            _signalBus.Subscribe<QuitButtonClickedSignal>(QuitGame);
        }

        private void LoadGameplayState()
        {
            _root.CreateNewState<GameplayStateFactory>();
        }

        private void QuitGame()
        {
            Debug.Log("Quit game");
        }

        public override void Exit()
        {
            base.Exit();
            UnsubscribeSignals();
        }

        private void UnsubscribeSignals()
        {
            _signalBus.Unsubscribe<PlayAgainButtonClickedSignal>(LoadGameplayState);
            _signalBus.Unsubscribe<QuitButtonClickedSignal>(QuitGame);
        }
    }
}