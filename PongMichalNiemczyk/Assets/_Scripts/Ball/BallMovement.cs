using UnityEngine;

namespace _Scripts.Ball
{
    public class BallMovement
    {
        private readonly BallSettings _ballSettings;
        private readonly BallView _ballView;

        public BallMovement(BallView ballView, BallSettings ballSettings)
        {
            _ballView = ballView;
            _ballSettings = ballSettings;
        }

        public void SpawnBallAtSceneCenter()
        {
            ResetPosition();
            ResetRotation();
        }

        private void ResetRotation()
        {
            _ballView.Rotation = new Quaternion(0f, 0f, 0f, 0f);
        }

        private void ResetPosition()
        {
            _ballView.Position = Vector3.zero;
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
            float x = Random.Range(-_ballSettings._maximumStartHorizontalDirection,
                _ballSettings._maximumStartHorizontalDirection
            );
            float y = Random.Range(-_ballSettings._maximumStartVerticalDirection,
                _ballSettings._maximumStartVerticalDirection
            );
            return new Vector2(x, y);
        }

        public void CheckIfBallMovingProperly()
        {
            Vector2 direction = _ballView.Rigidbody2D.velocity;

            float speed = direction.magnitude;
            // If the result of the subtraction is greater than sth small
            // it's a sign that our speed has changed.
            if (Mathf.Abs(speed - _ballSettings._speed) > Mathf.Epsilon)
            {
                PreventBallFromMovingTooFastOrTooSlow(direction);
            }

            float minimumYValue = _ballSettings._minimumVerticalMovement;
            if (direction.y > -minimumYValue && direction.y < minimumYValue)
            {
                PreventHorizontalLoops(direction);
            }

            float minimumXValue = _ballSettings._minimumHorizontalMovement;
            if (direction.x > -minimumXValue && direction.x < minimumXValue)
            {
                PreventVerticalLoops(direction);
            }
        }

        private void PreventBallFromMovingTooFastOrTooSlow(Vector2 direction)
        {
            _ballView.Rigidbody2D.velocity = direction.normalized * _ballSettings._speed;
        }

        private void PreventHorizontalLoops(Vector2 direction)
        {
            float speed = direction.magnitude;

            float minimumYValue = _ballSettings._minimumVerticalMovement;
            // Adjust the y, make sure it keeps going into the direction it was going
            direction.y = direction.y < 0 ? -minimumYValue : minimumYValue;

            _ballView.Rigidbody2D.velocity = direction.normalized * speed;
        }

        private void PreventVerticalLoops(Vector2 direction)
        {
            float speed = direction.magnitude;

            float minimumXValue = _ballSettings._minimumHorizontalMovement;
            // Adjust the x, make sure it keeps going into the direction it was going
            direction.x = direction.x < 0 ? -minimumXValue : minimumXValue;

            _ballView.Rigidbody2D.velocity = direction.normalized * speed;
        }

        public void AddRandomFactorToDirection()
        {
            Vector2 direction = _ballView.Rigidbody2D.velocity;
            float speed = direction.magnitude;

            float randomFactor = _ballSettings._randomDirectionBounceFactor;
            direction += new Vector2(
                Random.Range(-randomFactor, randomFactor),
                Random.Range(-randomFactor, randomFactor)
            );

            _ballView.Rigidbody2D.velocity = direction.normalized * speed;
        }
    }
}