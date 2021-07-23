using _Scripts.Root;
using UnityEngine;

namespace _Scripts.Ball
{
    public class BallStateWaitingForStart : State<BallStateManager>
    {
        private readonly BallMovement _ballMovement;

        public BallStateWaitingForStart(BallStateManager owner, BallMovement ballMovement)
            : base(owner)
        {
            _ballMovement = ballMovement;
        }

        public override void EnterState()
        {
            Debug.Log("<color=lime>[BALL STATE]</color> Ball is waiting...");
            _ballMovement.SpawnBallAtSceneCenter();
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