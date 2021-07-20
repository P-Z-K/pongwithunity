using System;
using UnityEngine;
using Zenject;

namespace _Scripts.Ball
{
    public class BallView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public Rigidbody2D Rigidbody2D
        {
            get => _rigidbody2D;
        }

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

        private void OnTriggerEnter2D(Collider2D other)
        {
            _signalBus.Fire(new BallTriggerEntered2DSignal(other));
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _signalBus.Fire(new BallCollisionEntered2DSignal(other));
        }
    }
}