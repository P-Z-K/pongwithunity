using _Scripts.Root;
using UnityEngine;
using Zenject;

namespace _Scripts.Ball
{
    public class BallStateInPlayerHole : State<BallStateManager>
    {
        private readonly BallMovement _ballMovement;
        private readonly BallView _ballView;
        private readonly SignalBus _signalBus;
        private readonly BallSettings _ballSettings;

        private float _elapsedTime = 0f;

        public BallStateInPlayerHole(
            BallStateManager owner
            , BallMovement ballMovement
            , BallView ballView
            , SignalBus signalBus
            , BallSettings ballSettings)
            : base(owner)
        {
            _ballMovement = ballMovement;
            _ballView = ballView;
            _signalBus = signalBus;
            _ballSettings = ballSettings;
        }

        public override void EnterState()
        {
            DisableBall();
            _signalBus.Fire(new BallFellIntoPlayerHoleSignal(_ballView.Position));
        }

        private void DisableBall()
        {
            _ballMovement.StopMove();
            _ballView.SpriteRenderer.enabled = false;
        }

        public override void Tick()
        {
            DelayStateChange();
        }

        private void DelayStateChange()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _ballSettings._delayBetweenBallStates)
            {
                _elapsedTime = 0f;
                _owner.ChangeStateTo<BallStateWaitingForStart>();
            }
        }

        public override void FixedTick()
        {
        }

        public override void ExitState()
        {
        }
    }
}