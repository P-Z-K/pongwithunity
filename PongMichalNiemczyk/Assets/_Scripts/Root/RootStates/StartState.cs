using UnityEngine;

namespace _Scripts.Root
{
    public class StartState : State<Root>
    {
        public StartState(Root owner) 
            : base(owner)
        {
        }

        public override void EnterState()
        {
            Debug.Log("<color=red>[ROOT STATE]</color> Entering Start state");
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