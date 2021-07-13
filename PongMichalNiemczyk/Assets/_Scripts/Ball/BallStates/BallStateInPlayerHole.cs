using UnityEngine;

namespace _Scripts.Ball
{
    public class BallStateInPlayerHole : BallState
    {
        private readonly BallView _ballView;
        private readonly BallSettings _ballSettings;

        public BallStateInPlayerHole(BallStateManager owner, BallView ballView, BallSettings ballSettings)
            : base(owner)
        {
            _ballView = ballView;
            _ballSettings = ballSettings;
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