using UnityEngine;

namespace _Scripts.Ball
{
    public class BallStateWaitingForStart : BallState
    {
        private readonly BallView _ballView;
        private readonly BallSettings _ballSettings;
        private readonly BallMovement _ballMovement;

        public BallStateWaitingForStart(BallStateManager owner, BallView ballView,
            BallSettings ballSettings, BallMovement ballMovement)
            : base(owner)
        {
            _ballView = ballView;
            _ballSettings = ballSettings;
            _ballMovement = ballMovement;
        }

        public override void EnterState()
        {
            Debug.Log("<color=lime>[BALL STATE]</color> Ball is waiting...");
            _ballMovement.SpawnBallAtSceneCenter();
        }

        public override void UpdateState()
        {
        }

        public override void UpdatePhysicsState()
        {
        }

        public override void ExitState()
        {
        }

        public override void OnTriggerEnter2D(Collider2D other)
        {
            throw new System.NotImplementedException();
        }

        public override void OnCollisionEnter2D(Collision2D other)
        {
            throw new System.NotImplementedException();
        }
    }
}