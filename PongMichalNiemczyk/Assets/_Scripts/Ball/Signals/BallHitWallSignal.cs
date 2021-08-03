using UnityEngine;

namespace _Scripts.Ball
{
    public class BallHitWallSignal
    {
        public BallHitWallSignal(Vector3 ballPosition)
        {
            BallPosition = ballPosition;
        }

        public Vector3 BallPosition { get; }
    }
}