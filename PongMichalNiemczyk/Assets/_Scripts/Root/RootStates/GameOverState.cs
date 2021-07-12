using UnityEngine;

namespace _Scripts.Root
{
    public class GameOverState : State<Root>
    {
        public GameOverState(Root owner) 
            : base(owner)
        {
        }

        public override void EnterState()
        {
            Debug.Log("Entering Game over state");
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
            Debug.Log("Exiting Game over state");
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