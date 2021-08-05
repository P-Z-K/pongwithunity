using _Scripts.Composite;
using _Scripts.UI.Signals;
using UnityEngine;
using Zenject;

namespace _Scripts.Root
{
    public class StartStateComposite : CompositeComponent
    {
        private readonly Root _root;
        private readonly SignalBus _signalBus;

        public StartStateComposite(SignalBus signalBus, Root root)
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
            _signalBus.Subscribe<StartButtonClickedSignal>(LoadGameplayState);
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
            _signalBus.Unsubscribe<StartButtonClickedSignal>(LoadGameplayState);
            _signalBus.Unsubscribe<QuitButtonClickedSignal>(QuitGame);
        }
    }
}