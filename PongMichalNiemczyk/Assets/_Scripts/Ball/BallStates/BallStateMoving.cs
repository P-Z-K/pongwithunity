using UnityEngine;

namespace _Scripts.Ball
{
    public class BallStateMoving : BallState
    {
        private BallView _ballView;
        private BallSettings _ballSettings;
        private BallMovement _ballMovement;

        public BallStateMoving(BallStateManager owner, BallView ballView, 
            BallSettings ballSettings, BallMovement ballMovement)
            : base(owner)
        {
            _ballView = ballView;
            _ballSettings = ballSettings;
            _ballMovement = ballMovement;
        }

        public override void EnterState()
        {
            Debug.Log("Ball starts moving...");
            _ballMovement.LaunchBall();
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
            
        }
    }
}