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

        public BallStateInPlayerHole(BallStateManager owner, BallMovement ballMovement, BallView ballView, 
            SignalBus signalBus)
            : base(owner)
        {
            _ballMovement = ballMovement;
            _ballView = ballView;
            _signalBus = signalBus;
        }

        public override void EnterState()
        {
            Debug.Log("<color=lime>[BALL STATE]</color> Ball is in player hole...");
            
            _ballMovement.StopMove();
            _signalBus.Fire(new BallFellIntoPlayerHoleSignal(_ballView.Position));
        }

        public override void Tick()
        {
        }

        public override void FixedTick()
        {
        }

        public override void ExitState()
        {
        }
    }
}