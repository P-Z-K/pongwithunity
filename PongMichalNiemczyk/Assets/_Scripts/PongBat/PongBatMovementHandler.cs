using UnityEngine;

namespace _Scripts.PongBat
{
    public class PongBatMovementHandler
    {
        private readonly InputManager _inputManager;
        private readonly PongBatSettings _pongBatSettings;
        private readonly PongBatView _pongBatView;

        public PongBatMovementHandler(
            PongBatView pongBatView
            , PongBatSettings pongBatSettings
            , InputManager inputManager)
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
            Rigidbody2D rb2D = _pongBatView.Rigidbody2D;
            Vector2 horizontalMove = new Vector2(_inputManager.HorizontalMove, 0f)
                                     * _pongBatSettings._moveSpeed * Time.fixedDeltaTime;
            rb2D.MovePosition(rb2D.position + horizontalMove);
        }
    }
}