using UnityEngine;

namespace _Scripts.Ball
{
    public class BallTriggerEntered2DSignal
    {
        public Collider2D Other { get; private set; }

        public BallTriggerEntered2DSignal(Collider2D other)
        {
            Other = other;
        }
    }
}