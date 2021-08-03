using UnityEngine;

namespace _Scripts.Ball
{
    public class BallCollisionEntered2DSignal
    {
        public BallCollisionEntered2DSignal(Collision2D other)
        {
            Other = other;
        }

        public Collision2D Other { get; }
    }
}