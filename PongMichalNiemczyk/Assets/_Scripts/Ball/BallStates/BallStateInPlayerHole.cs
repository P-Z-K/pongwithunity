using _Scripts.Root;
using UnityEngine;

namespace _Scripts.Ball
{
    public class BallStateInPlayerHole : State<BallStateManager>
    {
        private readonly BallMovement _ballMovement;

        public BallStateInPlayerHole(BallStateManager owner, BallMovement ballMovement)
            : base(owner)
        {
            _ballMovement = ballMovement;
        }

        public override void EnterState()
        {
            Debug.Log("<color=lime>[BALL STATE]</color> Ball is in player hole...");
            _ballMovement.StopMove();
        }

        public override void Tick()
        {
        }

        public override void FixedTick()
        {
        }

        public override void ExitState()
        {
        }
    }
}