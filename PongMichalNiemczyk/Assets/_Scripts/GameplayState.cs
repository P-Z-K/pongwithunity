using UnityEngine;

namespace _Scripts
{
    public class GameplayState : State<GameManager>
    {
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