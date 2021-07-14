using UnityEngine;

namespace _Scripts.Ball
{
    public class BallStateMoving : BallState
    {
        private readonly BallView _ballView;
        private readonly BallSettings _ballSettings;
        private readonly BallMovement _ballMovement;

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
            Debug.Log("[BALL STATE] Ball starts moving...");
            _ballMovement.StartMove();
        }

        public override void UpdateState()
        {
            _ballMovement.CheckIfBallMovingProperly();
        }

        public override void UpdatePhysicsState()
        {
            
        }

        public override void ExitState()
        {
        }

        public override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("PlayerHole"))
            {
                Debug.Log("The ball fell into the player hole");
                _owner.ChangeStateTo<BallStateInPlayerHole>();
            }
        }

        public override void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                Debug.Log("The Ball hit the wall");
                _ballMovement.AddRandomFactorToDirection();
            }
        }
    }
}