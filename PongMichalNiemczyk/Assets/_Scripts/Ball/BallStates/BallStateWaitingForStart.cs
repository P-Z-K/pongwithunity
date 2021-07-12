using UnityEngine;

namespace _Scripts.Ball
{
    public class BallStateWaitingForStart : BallState
    {
        private BallView _ballView;
        public BallStateWaitingForStart(BallStateManager owner, BallView ballView) : base(owner)
        {
            _ballView = ballView;
        }

        public override void EnterState()
        {
            Debug.Log("Ball is waiting...");
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