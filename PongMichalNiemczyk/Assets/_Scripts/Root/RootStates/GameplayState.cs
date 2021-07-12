using _Scripts.Ball;
using UnityEngine;

namespace _Scripts.Root
{
    public class GameplayState : State<Root>
    {
        private readonly BallStateManager _ballStateManager;
        public GameplayState(Root owner, BallStateManager ballStateManager) : base(owner)
        {
            _ballStateManager = ballStateManager;
        }

        public override void EnterState()
        {
            Debug.Log("Entering Gameplay state");
            _ballStateManager.ChangeStateTo<BallStateWaitingForStart>();
        }

        public override void UpdateState()
        {
            TEST_HandleUserInput();
        }

        public override void UpdatePhysicsState()
        {
        }

        public override void ExitState()
        {
            Debug.Log("Exiting Gameplay state");
        }

        private void TEST_HandleUserInput()
        {
            if (Input.GetButtonDown("Jump"))
            {
                TEST_LoadGameOverState();
            }

            if (Input.GetButtonDown("Fire1") && !(_ballStateManager.CurrentState is BallStateMoving))
            {
                TEST_LaunchBall();
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
    }
}