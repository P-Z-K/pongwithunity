using UnityEngine;

namespace _Scripts.Ball
{
    public class BallMovement
    {
        private readonly BallView _ballView;
        private readonly BallSettings _ballSettings;

        public BallMovement(BallView ballView, BallSettings ballSettings)
        {
            _ballView = ballView;
            _ballSettings = ballSettings;
        }

        public void SpawnBallAtCenter()
        {
            ResetPosition();
            ResetRotation();
        }

        public void StartMove()
        { 
            _ballView.Rigidbody2D.velocity = GetRandomDirection().normalized * _ballSettings._speed;
        }

        public void StopMove()
        {
            _ballView.Rigidbody2D.velocity = Vector2.zero;
        }

        private Vector2 GetRandomDirection()
        {
            // TODO: Remove magic numbers
            var x = Random.Range(-1f, 1f);
            var y = Random.Range(-1f, 1f);
            return new Vector2(x, y);
        }

        private void ResetRotation()
        {
            _ballView.Rotation = new Quaternion(0f, 0f, 0f, 0f);
        }

        private void ResetPosition()
        {
            _ballView.Position = new Vector3(0f, 0f, 0f);
        }
    }
}