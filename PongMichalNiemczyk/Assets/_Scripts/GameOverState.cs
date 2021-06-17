using UnityEngine;

namespace _Scripts
{
    public class GameOverState : State<GameManager>
    {
        public override void EnterState()
        {
            Debug.Log("Entering Game over state");
        }

        public override void UpdateState()
        {
            
        }

        public override void ExitState()
        {
            Debug.Log("Exiting Game over state");
        }
    }
}
