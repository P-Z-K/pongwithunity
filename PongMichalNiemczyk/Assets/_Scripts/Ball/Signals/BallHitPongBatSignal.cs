using UnityEngine;

namespace _Scripts.Ball
{
    public class BallHitPongBatSignal
    {
        public BallHitPongBatSignal(Vector3 ballPosition)
        {
            BallPosition = ballPosition;
        }

        public Vector3 BallPosition { get; }
    }
}