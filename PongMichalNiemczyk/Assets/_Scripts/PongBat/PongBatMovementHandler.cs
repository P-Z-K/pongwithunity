using UnityEngine;
using Zenject;

namespace _Scripts.PongBat
{
    public class PongBatMovementHandler
    {
        private readonly PongBatView _pongBatView;
        private readonly PongBatSettings _pongBatSettings;
        private readonly InputManager _inputManager;

        public PongBatMovementHandler(PongBatView pongBatView, PongBatSettings pongBatSettings, InputManager inputManager)
        {
            _pongBatView = pongBatView;
            _pongBatSettings = pongBatSettings;
            _inputManager = inputManager;
        }

        public void FixedTick()
        {
            MoveHorizontally();
        }

        private void MoveHorizontally()
        {
            var rb2D = _pongBatView.Rigidbody2D;
            var horizontalMove = new Vector2(_inputManager.HorizontalMove, 0f)
                                 * _pongBatSettings._moveSpeed * Time.fixedDeltaTime;
            rb2D.MovePosition(rb2D.position + horizontalMove);
        }
    }
}