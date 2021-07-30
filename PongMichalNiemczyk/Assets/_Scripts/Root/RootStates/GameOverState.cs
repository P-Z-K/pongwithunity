using _Scripts.Players;
using _Scripts.UI;
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
            Debug.Log("<color=red>[ROOT STATE]</color> Entering Game over state");
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