using _Scripts.UI;
using UnityEngine;

namespace _Scripts.Root
{
    public class GameOverState : State<Root>
    {
        private readonly MenuManager _menuManager;

        public GameOverState(Root owner, MenuManager menuManager)
            : base(owner)
        {
            _menuManager = menuManager;
        }

        public override void EnterState()
        {
            Debug.Log("<color=red>[ROOT STATE]</color> Entering Game over state");
            _menuManager.ChangeMenuTo(MenuType.GameOverMenu);
            SubscribeButtonEvents();
        }

        private void SubscribeButtonEvents()
        {
            _menuManager.PlayAgainButton.onClick.AddListener(TEST_LoadStartState);
            _menuManager.QuitButton.onClick.AddListener(QuitGame);
        }

        private void UnsubscribeButtonEvents()
        {
            _menuManager.PlayAgainButton.onClick.RemoveListener(TEST_LoadStartState);
            _menuManager.QuitButton.onClick.RemoveListener(QuitGame);
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
            UnsubscribeButtonEvents();
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