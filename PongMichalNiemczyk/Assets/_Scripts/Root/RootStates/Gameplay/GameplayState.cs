using _Scripts.Ball;
using _Scripts.Players;
using UnityEngine;
using Zenject;

namespace _Scripts.Root
{
    public class GameplayState : State<Root>
    {
        private readonly IBallFacade _ballFacade;
        private readonly SignalBus _signalBus;

        public GameplayState(
            Root owner
            , IBallFacade ballFacade
            , SignalBus signalBus)
            : base(owner)
        {
            _ballFacade = ballFacade;
            _signalBus = signalBus;
        }

        public override void EnterState()
        {
            SubscribeSignals();
        }

        private void SubscribeSignals()
        {
            _signalBus.Subscribe<PlayerWonSignal>(LoadGameOverState);
        }

        public override void Tick()
        {
            TEST_HandleUserInput();
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
            _signalBus.Unsubscribe<PlayerWonSignal>(LoadGameOverState);
        }

        private void TEST_HandleUserInput()
        {
            if (Input.GetButtonDown("Jump"))
            {
                LoadGameOverState();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                if (_ballFacade.CurrentState is BallStateWaitingForStart)
                {
                    TEST_LaunchBall();
                }
                else if (_ballFacade.CurrentState is BallStateInPlayerHole)
                {
                    TEST_RestartBall();
                }
            }
        }

        private void LoadGameOverState()
        {
            _owner.CreateNewState<GameOverStateFactory>();
        }

        private void TEST_LaunchBall()
        {
            _ballFacade.ChangeStateTo<BallStateMoving>();
        }

        private void TEST_RestartBall()
        {
            _ballFacade.ChangeStateTo<BallStateWaitingForStart>();
        }
    }
}