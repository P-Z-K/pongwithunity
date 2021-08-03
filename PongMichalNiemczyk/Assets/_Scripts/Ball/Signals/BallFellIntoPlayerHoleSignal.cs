using UnityEngine;

namespace _Scripts.Ball
{
    public class BallFellIntoPlayerHoleSignal
    {
        public BallFellIntoPlayerHoleSignal(Vector3 ballPosition)
        {
            BallPosition = ballPosition;
        }

        public Vector3 BallPosition { get; }
    }
}