using UnityEngine;

namespace _Scripts
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

        }

        public override void ExitState()
        {
            Debug.Log("Exiting Gameplay state");
        }
    }
}