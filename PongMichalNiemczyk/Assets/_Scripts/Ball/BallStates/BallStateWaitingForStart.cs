using _Scripts.Root;
using UnityEngine;

namespace _Scripts.Ball
{
    public class BallStateWaitingForStart : State<BallStateManager>
    {
        private readonly BallMovement _ballMovement;
        private readonly BallView _ballView;

        public BallStateWaitingForStart(BallStateManager owner, BallMovement ballMovement, BallView ballView)
            : base(owner)
        {
            _ballMovement = ballMovement;
            _ballView = ballView;
        }

        public override void EnterState()
        {
            PrepareBall();
        }

        private void PrepareBall()
        {
            _ballMovement.SpawnBallAtSceneCenter();
            _ballView.SpriteRenderer.enabled = true;
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