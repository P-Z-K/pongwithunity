using _Scripts.Root;
using UnityEngine;
using Zenject;

namespace _Scripts.Ball
{
    public class BallFacade : MonoBehaviour
    {
        private BallStateManager _ballStateManager;

        [Inject]
        public void Construct(BallStateManager ballStateManager)
        {
            _ballStateManager = ballStateManager;
        }

        public State<BallStateManager> CurrentState
        {
            get => _ballStateManager.CurrentState;
        }
        
        public void ChangeStateTo<T>() where T : State<BallStateManager>
        {
            _ballStateManager.ChangeStateTo<T>();
        }

        public void Update()
        {
            _ballStateManager.Update();
        }
        
        public void UpdatePhysics()
        {
            _ballStateManager.UpdatePhysics();
        }
    }
}