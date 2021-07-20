using UnityEngine;

namespace _Scripts.Ball
{
    public class BallHitPongBatSignal
    {
        public Vector3 BallPosition { get; private set; }

        public BallHitPongBatSignal(Vector3 ballPosition)
        {
            BallPosition = ballPosition;
        }
    }
}