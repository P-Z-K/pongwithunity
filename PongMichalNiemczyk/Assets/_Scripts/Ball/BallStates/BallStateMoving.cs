using UnityEngine;

namespace _Scripts.Ball
{
    public class BallStateMoving : BallState
    {
        private BallView _ballView;
        private BallSettings _ballSettings;
        public BallStateMoving(BallStateManager owner, BallView ballView, BallSettings ballSettings) 
            : base(owner)
        {
            _ballView = ballView;
            _ballSettings = ballSettings;
        }

        public override void EnterState()
        {
            Debug.Log("Ball starts moving...");
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