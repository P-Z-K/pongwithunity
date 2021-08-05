using _Scripts.Root;
using _Scripts.UI;
using _Scripts.UI.Signals;
using Zenject;

namespace _Scripts.Ball
{
    public class BallStateWaitingForStart : State<BallStateManager>
    {
        private readonly BallMovement _ballMovement;
        private readonly BallView _ballView;
        private readonly SignalBus _signalBus;
        private readonly CountdownTimerController _countdownTimerController;

        public BallStateWaitingForStart(
            BallStateManager owner
            , BallMovement ballMovement
            , BallView ballView
            , SignalBus signalBus
            , CountdownTimerController countdownTimerController)
            : base(owner)
        {
            _ballMovement = ballMovement;
            _ballView = ballView;
            _signalBus = signalBus;
            _countdownTimerController = countdownTimerController;
        }

        public override void EnterState()
        {
            SubscribeSignals();
            _countdownTimerController.Show();
        }

        private void SubscribeSignals()
        {
            _signalBus.Subscribe<CountdownAnimationFinishedSignal>(OnCountdownAnimationEnd);
        }

        private void OnCountdownAnimationEnd()
        {
            PrepareBall();
            _owner.ChangeStateTo<BallStateMoving>();
        }

        private void PrepareBall()
        {
            _ballMovement.SpawnBallAtSceneCenter();
            _ballView.SpriteRenderer.enabled = true;
        }

        public override void Tick()
        {
            _countdownTimerController.Countdown();
        }

        public override void FixedTick()
        {
        }

        public override void ExitState()
        {
            UnsubscribeSignals();
        }

        private void UnsubscribeSignals()
        {
            _signalBus.Unsubscribe<CountdownAnimationFinishedSignal>(OnCountdownAnimationEnd);
        }
    }
}