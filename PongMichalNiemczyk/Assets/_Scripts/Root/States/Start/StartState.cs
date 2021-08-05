using _Scripts.UI;
using _Scripts.UI.Signals;
using UnityEngine;
using Zenject;

namespace _Scripts.Root
{
    public class StartState : State<Root>
    {
        private readonly SignalBus _signalBus;

        public StartState(Root owner, SignalBus signalBus)
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
            _signalBus.Subscribe<StartButtonClickedSignal>(LoadGameplayState);
            _signalBus.Subscribe<QuitButtonClickedSignal>(QuitGame);
        }

        private void QuitGame()
        {
            Debug.Log("Quit game");
        }

        public override void Tick()
        {
            TEST_HandleUserInput();
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
            _signalBus.Unsubscribe<StartButtonClickedSignal>(LoadGameplayState);
            _signalBus.Unsubscribe<QuitButtonClickedSignal>(QuitGame);
        }

        private void TEST_HandleUserInput()
        {
            if (Input.GetButtonDown("Jump"))
            {
                LoadGameplayState();
            }
        }

        private void LoadGameplayState()
        {
            _owner.CreateNewState<GameplayStateFactory>();
        }
    }
}