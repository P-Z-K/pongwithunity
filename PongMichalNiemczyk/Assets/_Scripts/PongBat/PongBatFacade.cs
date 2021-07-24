using UnityEngine;
using Zenject;

namespace _Scripts.PongBat
{
    public class PongBatFacade : MonoBehaviour
    {
        private PongBatMovementHandler _pongBatMovementHandler;
        private InputManager _inputManager;

        [Inject]
        public void Construct(PongBatMovementHandler pongBatMovementHandler, InputManager inputManager)
        {
            _pongBatMovementHandler = pongBatMovementHandler;
            _inputManager = inputManager;
        }

        public void Tick()
        {
            _inputManager.Tick();
        }

        public void FixedTick()
        {
            _pongBatMovementHandler.FixedTick();
        }
    }
}