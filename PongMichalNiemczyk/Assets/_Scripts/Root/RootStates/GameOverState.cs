using _Scripts.Players;
using _Scripts.UI;
using _Scripts.UI.Signals;
using UnityEngine;
using Zenject;

namespace _Scripts.Root
{
    public class GameOverState : State<Root>
    {
        private readonly GameOverMenuController _gameOverMenuController;
        private readonly SignalBus _signalBus;
        public GameOverState(Root owner, GameOverMenuController gameOverMenuController, SignalBus signalBus)
            : base(owner)
        {
            _gameOverMenuController = gameOverMenuController;
            _signalBus = signalBus;
        }

        public override void EnterState()
        {
            Debug.Log("<color=red>[ROOT STATE]</color> Entering Game over state");
            SubscribeSignals();
            _gameOverMenuController.Show();
        }
        
        private void SubscribeSignals()
        {
            _signalBus.Subscribe<PlayAgainButtonClickedSignal>(TEST_LoadGameplayState);
            _signalBus.Subscribe<QuitButtonClickedSignal>(QuitGame);
        }
        
        private void TEST_LoadGameplayState()
        {
            _owner.ChangeStateTo<GameplayState>();
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
            Debug.Log("<color=red>[ROOT STATE]</color> Exiting Game over state");
            _gameOverMenuController.Hide();
            UnsubscribeSignals();
        }
        
        private void UnsubscribeSignals()
        {
            _signalBus.Unsubscribe<PlayAgainButtonClickedSignal>(TEST_LoadGameplayState);
            _signalBus.Unsubscribe<QuitButtonClickedSignal>(QuitGame);
        }

        private void TEST_HandleUserInput()
        {
            if (Input.GetButtonDown("Jump"))
            {
                TEST_LoadStartState();
            }
        }

        private void TEST_LoadStartState()
        {
            _owner.ChangeStateTo<StartState>();
        }
    }
}