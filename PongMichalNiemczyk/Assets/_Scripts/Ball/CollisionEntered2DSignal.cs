using UnityEngine;

namespace _Scripts.Ball
{
    public class CollisionEntered2DSignal
    {
        public Collision2D Other { get; private set; }

        public CollisionEntered2DSignal(Collision2D other)
        {
            Other = other;
        }
    }
}