using UnityEngine;

namespace _Scripts.Ball
{
    public class BallFellIntoPlayerHoleSignal
    {
        public Vector3 BallPosition { get; private set; }

        public BallFellIntoPlayerHoleSignal(Vector3 ballPosition)
        {
            BallPosition = ballPosition;
        }
    }
}