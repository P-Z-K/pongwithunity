using _Scripts.Root;
using UnityEngine;
using Zenject;

namespace _Scripts.Ball
{
    public class BallFacade : MonoBehaviour, IBallFacade
    {
        private BallStateManager _ballStateManager;

        public State<BallStateManager> CurrentState => _ballStateManager.CurrentState;

        [Inject]
        public void Construct(BallStateManager ballStateManager)
        {
            _ballStateManager = ballStateManager;
        }

        public void ChangeStateTo<T>() where T : State<BallStateManager>
        {
            _ballStateManager.ChangeStateTo<T>();
        }

        public void Tick()
        {
            _ballStateManager.Tick();
        }

        public void FixedTick()
        {
            _ballStateManager.FixedTick();
        }
    }
}