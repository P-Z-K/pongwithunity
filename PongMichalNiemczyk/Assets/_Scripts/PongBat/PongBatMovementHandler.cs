using UnityEngine;
using Zenject;

namespace _Scripts.PongBat
{
    public class PongBatMovementHandler : IFixedTickable
    {
        private readonly PongBatView _pongBatView;
        private readonly PongBatSettings _pongBatSettings;
        private readonly InputManager _inputManager;

        public PongBatMovementHandler(PongBatView pongBatView, InputManager inputManager, PongBatSettings pongBatSettings)
        {
            _pongBatView = pongBatView;
            _inputManager = inputManager;
            _pongBatSettings = pongBatSettings;
        }

        public void FixedTick()
        {
            MoveHorizontally();
        }

        private void MoveHorizontally()
        {
            var rb2D = _pongBatView.Rigidbody2D;
            var horizontalMove = new Vector2(_inputManager.GetHorizontalMove(), 0f) 
                                 * _pongBatSettings._moveSpeed * Time.fixedDeltaTime;
            rb2D.MovePosition(rb2D.position + horizontalMove);
        }
    }
}