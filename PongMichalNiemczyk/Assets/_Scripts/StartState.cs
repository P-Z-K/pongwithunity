using UnityEngine;

namespace _Scripts
{
    public class StartState : State<Root>
    {
        public StartState(Root owner) : base(owner)
        {
        }

        public override void EnterState()
        {
            Debug.Log("Entering Start state");
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
            Debug.Log("Exiting Start state");
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