using System.Collections.Generic;
using _Scripts.Audio;
using _Scripts.Ball;
using _Scripts.Particles;
using _Scripts.Players;
using _Scripts.PongBat;
using _Scripts.Root.Global_Signals;
using _Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Scripts.Root
{
    public class GameplayState : State<Root>
    {
        [Inject] private List<PongBatFacade> _pongBatFacades = new List<PongBatFacade>();

        private readonly IBallFacade _ballFacade;
        private readonly SoundEntityManager _soundEntityManager;
        private readonly ParticleEntityManager _particleEntityManager;

        private readonly MenuManager _menuManager;
        private readonly UI_PointsTracker _uiPointsTracker;
        private readonly PointsTracker _pointsTracker;
        private readonly SignalBus _signalBus;

        public GameplayState(Root owner, SoundEntityManager soundEntityManager,
            IBallFacade ballFacade, ParticleEntityManager particleEntityManager, MenuManager menuManager,
            UI_PointsTracker uiPointsTracker, PointsTracker pointsTracker, SignalBus signalBus)
            : base(owner)
        {
            _soundEntityManager = soundEntityManager;
            _ballFacade = ballFacade;
            _particleEntityManager = particleEntityManager;
            _menuManager = menuManager;
            _uiPointsTracker = uiPointsTracker;
            _pointsTracker = pointsTracker;
            _signalBus = signalBus;
        }

        public override void EnterState()
        {
            Debug.Log("<color=red>[ROOT STATE]</color> Entering Gameplay state");

            _menuManager.ChangeMenuTo(MenuType.GameplayMenu);

            SubscribeSignals();
            _particleEntityManager.SubscribeSignals();
            _soundEntityManager.SubscribeSignals();
            _uiPointsTracker.SubscribeSignals();
            _pointsTracker.ResetPoints();

            _ballFacade.ChangeStateTo<BallStateWaitingForStart>();
        }

        private void SubscribeSignals()
        {
            _signalBus.Subscribe<PlayerWonSignal>(TEST_LoadGameOverState);
        }

        public override void Tick()
        {
            foreach (var pongBatFacade in _pongBatFacades)
            {
                pongBatFacade.Tick();
            }

            _ballFacade.Tick();
            _soundEntityManager.Tick();
            _particleEntityManager.Tick();


            TEST_HandleUserInput();
        }

        public override void FixedTick()
        {
            _ballFacade.FixedTick();
            foreach (var pongBatFacade in _pongBatFacades)
            {
                pongBatFacade.FixedTick();
            }
        }

        public override void ExitState()
        {
            Debug.Log("<color=red>[ROOT STATE]</color> Exiting Gameplay state");

            _particleEntityManager.UnsubscribeSignals();
            _soundEntityManager.UnsubscribeSignals();
            _uiPointsTracker.UnsubscribeSignals();
            UnsubscribeSignals();
        }

        private void UnsubscribeSignals()
        {
            _signalBus.Unsubscribe<PlayerWonSignal>(TEST_LoadGameOverState);
        }

        private void TEST_HandleUserInput()
        {
            if (Input.GetButtonDown("Jump"))
            {
                TEST_LoadGameOverState();
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

        private void TEST_LoadGameOverState()
        {
            _owner.ChangeStateTo<GameOverState>();
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