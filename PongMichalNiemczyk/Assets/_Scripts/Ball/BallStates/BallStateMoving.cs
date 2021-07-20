using _Scripts.Root;
using _Scripts.Utils;
using UnityEngine;
using Zenject;

namespace _Scripts.Ball
{
    public class BallStateMoving : State<BallStateManager>
    {
        private readonly BallMovement _ballMovement;
        private readonly BallView _ballView;
        private readonly SignalBus _signalBus;
        private readonly TagsSettings _tagsSettings;

        public BallStateMoving(BallStateManager owner, BallMovement ballMovement, SignalBus signalBus, 
            TagsSettings tagsSettings, BallView ballView)
            : base(owner)
        {
            _ballMovement = ballMovement;
            _signalBus = signalBus;
            _tagsSettings = tagsSettings;
            _ballView = ballView;

            SubscribeSignals();
        }

        private void SubscribeSignals()
        {
            _signalBus.Subscribe<BallTriggerEntered2DSignal>(x => OnTriggerEnter2D(x.Other));
            _signalBus.Subscribe<BallCollisionEntered2DSignal>(x => OnCollisionEnter2D(x.Other));
        }

        public override void EnterState()
        {
            Debug.Log("<color=lime>[BALL STATE]</color> Ball starts moving...");
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(_tagsSettings.PlayerHoleTag))
            {
                Debug.Log("<color=lime>[BALL INFO]</color> The ball fell into the player hole");
                _owner.ChangeStateTo<BallStateInPlayerHole>();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(_tagsSettings.WallTag))
            {
                Debug.Log("<color=lime>[BALL INFO]</color> The Ball hit the wall");
                
                _signalBus.Fire(new BallHitWallSignal(_ballView.Position));
                _ballMovement.AddRandomFactorToDirection();
            }
            else if (other.gameObject.CompareTag(_tagsSettings.PlayerPongBatTag))
            {
                Debug.Log("<color=lime>[BALL INFO]</color> The Ball hit the pong bat");
                _signalBus.Fire(new BallHitPongBatSignal(_ballView.Position));
            }
        }
    }
}