using _Scripts.Players;
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
        private readonly PointsTracker _pointsTracker;

        public BallStateMoving(BallStateManager owner, BallMovement ballMovement, SignalBus signalBus, 
            TagsSettings tagsSettings, BallView ballView, PointsTracker pointsTracker)
            : base(owner)
        {
            _ballMovement = ballMovement;
            _signalBus = signalBus;
            _tagsSettings = tagsSettings;
            _ballView = ballView;
            _pointsTracker = pointsTracker;
        }

        private void SubscribeSignals()
        {
            _signalBus.Subscribe<BallTriggerEntered2DSignal>(OnTriggerEnter2D);
            _signalBus.Subscribe<BallCollisionEntered2DSignal>(OnCollisionEnter2D);
        }

        private void UnsubscribeSignals()
        {
            _signalBus.Unsubscribe<BallTriggerEntered2DSignal>(OnTriggerEnter2D);
            _signalBus.Unsubscribe<BallCollisionEntered2DSignal>(OnCollisionEnter2D);
        }
        
        private void OnCollisionEnter2D(BallCollisionEntered2DSignal obj)
        {
            Collision2D other = obj.Other;
            
            if (other.gameObject.CompareTag(_tagsSettings.WallTag))
            {
                _signalBus.Fire(new BallHitWallSignal(_ballView.Position));
                _ballMovement.AddRandomFactorToDirection();
            }
            else if (other.gameObject.CompareTag(_tagsSettings.PlayerPongBatTag))
            {
                _signalBus.Fire(new BallHitPongBatSignal(_ballView.Position));
            }
        }

        private void OnTriggerEnter2D(BallTriggerEntered2DSignal obj)
        {
            Collider2D other = obj.Other;
            
            if (other.gameObject.CompareTag(_tagsSettings.PlayerHoleTag))
            {
                Player player = other.GetComponent<Player>();
                _pointsTracker.DecideWhoGivePointTo(player.HoleType);
                _owner.ChangeStateTo<BallStateInPlayerHole>();
            }
        }

        public override void EnterState()
        {
            Debug.Log("<color=lime>[BALL STATE]</color> Ball starts moving...");
            SubscribeSignals();
            _ballMovement.StartMove();
        }

        public override void Tick()
        {
            _ballMovement.CheckIfBallMovingProperly();
        }

        public override void FixedTick()
        {
        }

        public override void ExitState()
        {
            UnsubscribeSignals();
        }
    }
}