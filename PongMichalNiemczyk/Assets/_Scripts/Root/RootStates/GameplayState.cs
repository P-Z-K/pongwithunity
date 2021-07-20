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
        [Inject] private List<PongBatMovementHandler> _pongBatMovementHandlers = new List<PongBatMovementHandler>();
        
        private readonly BallStateManager _ballStateManager;
        private SoundEntityPooler _soundEntityPooler;

        public GameplayState(Root owner, BallStateManager ballStateManager, SoundEntityPooler soundEntityPooler) 
            : base(owner)
        {
            _ballStateManager = ballStateManager;
            _soundEntityPooler = soundEntityPooler;
        }

        public override void EnterState()
        {
            Debug.Log("<color=red>[ROOT STATE]</color> Entering Gameplay state");
            _ballStateManager.ChangeStateTo<BallStateWaitingForStart>();
        }

        public override void UpdateState()
        {
            _ballStateManager.Update();
            _soundEntityPooler.Update();
            
            TEST_HandleUserInput();
        }

        public override void UpdatePhysicsState()
        {
            _ballStateManager.UpdatePhysics();
            foreach (var pongBatMovementHandler in _pongBatMovementHandlers)
            {
                pongBatMovementHandler.UpdatePhysics();
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
                if (_ballStateManager.CurrentState is BallStateWaitingForStart)
                {
                    TEST_LaunchBall();
                }
                else if (_ballStateManager.CurrentState is BallStateInPlayerHole)
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
            _ballStateManager.ChangeStateTo<BallStateMoving>();
        }

        private void TEST_RestartBall()
        {
            _ballStateManager.ChangeStateTo<BallStateWaitingForStart>();
        }
    }
}