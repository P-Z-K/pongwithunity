using _Scripts.UI;
using _Scripts.UI.Signals;
using UnityEngine;
using Zenject;

namespace _Scripts.Root
{
    public class StartState : State<Root>
    {
        private readonly StartMenuController _startMenuController;
        private readonly SignalBus _signalBus;
        public StartState(Root owner, StartMenuController startMenuController, SignalBus signalBus) 
            : base(owner)
        {
            _startMenuController = startMenuController;
            _signalBus = signalBus;
        }

        public override void EnterState()
        {
            Debug.Log("<color=red>[ROOT STATE]</color> Entering Start state");
            SubscribeSignals();
            _startMenuController.Show();
        }

        private void SubscribeSignals()
        {
            _signalBus.Subscribe<StartButtonClickedSignal>(TEST_LoadGameplayState);
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
            Debug.Log("<color=red>[ROOT STATE]</color> Exiting Start state");
            _startMenuController.Hide();
            UnsubscribeSignals();
        }
        
        private void UnsubscribeSignals()
        {
            _signalBus.Unsubscribe<StartButtonClickedSignal>(TEST_LoadGameplayState);
            _signalBus.Unsubscribe<QuitButtonClickedSignal>(QuitGame);
        }

        private void TEST_HandleUserInput()
        {
            if (Input.GetButtonDown("Jump"))
            {
                TEST_LoadGameplayState();
            }
        }

        private void TEST_LoadGameplayState()
        {
            _owner.ChangeStateTo<GameplayState>();
        }
    }
}