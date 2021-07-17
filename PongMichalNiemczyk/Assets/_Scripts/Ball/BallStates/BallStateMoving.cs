using _Scripts.Root;
using UnityEngine;
using Zenject;

namespace _Scripts.Ball
{
    public class BallStateMoving : State<BallStateManager>
    {
        private readonly BallMovement _ballMovement;
        private readonly SignalBus _signalBus;

        public BallStateMoving(BallStateManager owner, BallMovement ballMovement, SignalBus signalBus)
            : base(owner)
        {
            _ballMovement = ballMovement;
            _signalBus = signalBus;

            SubscribeSignals();
        }

        private void SubscribeSignals()
        {
            _signalBus.Subscribe<TriggerEntered2DSignal>(x => OnTriggerEnter2D(x.Other));
            _signalBus.Subscribe<CollisionEntered2DSignal>(x => OnCollisionEnter2D(x.Other));
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
            if (other.gameObject.CompareTag("PlayerHole"))
            {
                Debug.Log("<color=lime>[BALL INFO]</color> The ball fell into the player hole");
                _owner.ChangeStateTo<BallStateInPlayerHole>();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                Debug.Log("<color=lime>[BALL INFO]</color> The Ball hit the wall");
                _ballMovement.AddRandomFactorToDirection();
            }
        }
    }
}