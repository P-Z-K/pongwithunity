using UnityEngine;

namespace _Scripts.Ball
{
    public class BallStateInPlayerHole : BallState
    {
        private BallView _ballView;
        public BallStateInPlayerHole(BallStateManager owner, BallView ballView) : base(owner)
        {
            _ballView = ballView;
        }

        public override void EnterState()
        {
            Debug.Log("Ball is in player hole...");
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