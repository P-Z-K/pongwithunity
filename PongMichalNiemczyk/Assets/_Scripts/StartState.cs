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

        }

        public override void ExitState()
        {
            Debug.Log("Exiting Start state");
        }
    }
}