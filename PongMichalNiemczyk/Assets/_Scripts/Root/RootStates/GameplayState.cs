using UnityEngine;

namespace _Scripts.Root
{
    public class GameplayState : State<Root>
    {
        public GameplayState(Root owner) : base(owner)
        {
        }

        public override void EnterState()
        {
            Debug.Log("Entering Gameplay state");
        }

        public override void UpdateState()
        {
            TEST_HandleUserInput();
        }

        public override void UpdatePhysicsState()
        {
        }

        public override void ExitState()
        {
            Debug.Log("Exiting Gameplay state");
        }

        private void TEST_HandleUserInput()
        {
            if (Input.GetButtonDown("Jump"))
            {
                TEST_LoadGameOverState();
            }
        }

        private void TEST_LoadGameOverState()
        {
            _owner.ChangeStateTo<GameOverState>();
        }
    }
}