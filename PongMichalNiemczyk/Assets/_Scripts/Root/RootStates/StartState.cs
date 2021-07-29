using _Scripts.UI;
using UnityEngine;

namespace _Scripts.Root
{
    public class StartState : State<Root>
    {
        private readonly MenuManager _menuManager;
        public StartState(Root owner, MenuManager menuManager) 
            : base(owner)
        {
            _menuManager = menuManager;
        }

        public override void EnterState()
        {
            Debug.Log("<color=red>[ROOT STATE]</color> Entering Start state");
            _menuManager.ChangeMenuTo(MenuType.StartMenu);
            SubscribeButtonEvents();
        }

        private void SubscribeButtonEvents()
        {
            _menuManager.StartButton.onClick.AddListener(TEST_LoadGameplayState);
            _menuManager.QuitButton.onClick.AddListener(QuitGame);
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
            UnsubscribeButtonEvents();
        }
        
        private void UnsubscribeButtonEvents()
        {
            _menuManager.StartButton.onClick.RemoveListener(TEST_LoadGameplayState);
            _menuManager.QuitButton.onClick.RemoveListener(QuitGame);
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