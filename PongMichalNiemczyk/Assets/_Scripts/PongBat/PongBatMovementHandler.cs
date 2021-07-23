using UnityEngine;
using Zenject;

namespace _Scripts.PongBat
{
    public class PongBatMovementHandler : MonoBehaviour
    {
        private PongBatView _pongBatView;
        private PongBatSettings _pongBatSettings;
        private InputManager _inputManager;

        [Inject]
        public void Construct(PongBatView pongBatView, InputManager inputManager,
            PongBatSettings pongBatSettings)
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
            var horizontalMove = new Vector2(_inputManager.HorizontalMove, 0f)
                                 * _pongBatSettings._moveSpeed * Time.fixedDeltaTime;
            rb2D.MovePosition(rb2D.position + horizontalMove);
        }
    }
}