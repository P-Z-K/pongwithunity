using UnityEngine;

namespace _Scripts.Ball
{
    public class TriggerEntered2DSignal
    {
        public Collider2D Other { get; private set; }

        public TriggerEntered2DSignal(Collider2D other)
        {
            Other = other;
        }
    }
}