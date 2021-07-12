using System;
using UnityEngine;
using Zenject;

namespace _Scripts.Ball
{
    public class BallView : MonoBehaviour
    {
        private BallStateManager _ballStateManager;
        
        [Inject]
        public void Construct(BallStateManager ballStateManager)
        {
            _ballStateManager = ballStateManager;
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
            _ballStateManager.CurrentState?.OnTriggerEnter2D(other);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _ballStateManager.CurrentState?.OnCollisionEnter2D(other);
        }
    }
}