using UnityEngine;
using Zenject;

namespace _Scripts.Particles
{
    public class ParticleEntity<T> : MonoBehaviour, IParticleEntity
        where T : IMemoryPool
    {
        [SerializeField] private ParticleSystem _particleSystem;

        private T _pool;

        [Inject]
        public void Construct(T pool)
        {
            _pool = pool;
        }

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
                _pool.Despawn(this);
            }
        }
    }
}