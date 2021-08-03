using UnityEngine;
using Zenject;

namespace _Scripts.Ball
{
    public class BallView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private SignalBus _signalBus;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public Quaternion Rotation
        {
            get => transform.rotation;
            set => transform.rotation = value;
        }

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _signalBus.Fire(new BallCollisionEntered2DSignal(other));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _signalBus.Fire(new BallTriggerEntered2DSignal(other));
        }
    }
}