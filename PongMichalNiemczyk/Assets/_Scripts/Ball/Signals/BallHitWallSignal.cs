using UnityEngine;

namespace _Scripts.Ball
{
    public class BallHitWallSignal
    {
        public Vector3 BallPosition { get; private set; }

        public BallHitWallSignal(Vector3 ballPosition)
        {
            BallPosition = ballPosition;
        }
    }
}