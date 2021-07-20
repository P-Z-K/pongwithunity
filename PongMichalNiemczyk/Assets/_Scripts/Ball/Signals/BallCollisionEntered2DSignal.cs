using UnityEngine;

namespace _Scripts.Ball
{
    public class BallCollisionEntered2DSignal
    {
        public Collision2D Other { get; private set; }

        public BallCollisionEntered2DSignal(Collision2D other)
        {
            Other = other;
        }
    }
}