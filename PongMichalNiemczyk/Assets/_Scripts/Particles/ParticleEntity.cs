using UnityEngine;

namespace _Scripts.Particles
{
    public class ParticleEntity : MonoBehaviour
    {
        [SerializeField] protected ParticleSystem _particleSystem;
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public void Play()
        {
            Active = true;
            _particleSystem.Play();
        }

        public bool Active
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }

        private void Update()
        {
            if (!_particleSystem.isPlaying)
            {
                // Return object to the pool
            }
        }
    }
}