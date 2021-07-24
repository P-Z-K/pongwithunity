using System.Collections.Generic;
using _Scripts.Audio;
using _Scripts.Ball;
using _Scripts.PongBat;
using UnityEngine;
using Zenject;

namespace _Scripts.Root
{
    public class GameplayState : State<Root>
    {
        [Inject] private List<PongBatFacade> _pongBatFacades = new List<PongBatFacade>();
        
        private readonly IBallFacadable _ballFacade;
        private readonly SoundEntityPooler _soundEntityPooler;

        public GameplayState(Root owner, SoundEntityPooler soundEntityPooler, IBallFacadable ballFacade) 
            : base(owner)
        {
            _soundEntityPooler = soundEntityPooler;
            _ballFacade = ballFacade;
        }

        public override void EnterState()
        {
            Debug.Log("<color=red>[ROOT STATE]</color> Entering Gameplay state");
            _ballFacade.ChangeStateTo<BallStateWaitingForStart>();
        }

        public override void Tick()
        {
            foreach (var pongBatFacade in _pongBatFacades)
            {
                pongBatFacade.Tick();
            }
            _ballFacade.Tick();
            _soundEntityPooler.Tick();
            
            
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