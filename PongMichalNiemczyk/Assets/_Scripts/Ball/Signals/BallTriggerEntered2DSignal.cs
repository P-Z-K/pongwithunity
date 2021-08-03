using UnityEngine;

namespace _Scripts.Ball
{
    public class BallTriggerEntered2DSignal
    {
        public BallTriggerEntered2DSignal(Collider2D other)
        {
            Other = other;
        }

        public Collider2D Other { get; }
    }
}