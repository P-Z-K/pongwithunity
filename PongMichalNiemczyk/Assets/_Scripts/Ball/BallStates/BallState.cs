using UnityEngine;

namespace _Scripts.Ball.BallStates
{
    public abstract class BallState : State<BallStateManager>
    {
        protected BallState(BallStateManager owner) : base(owner)
        {
        }

        public abstract void OnTriggerEnter2D(Collider2D other);
        public abstract void OnCollisionEnter2D(Collision2D other);
    }
}