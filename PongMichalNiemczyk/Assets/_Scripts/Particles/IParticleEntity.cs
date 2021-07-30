using UnityEngine;

namespace _Scripts.Particles
{
    public interface IParticleEntity
    {
        public Vector3 Position { get; set; }
        public bool Active { get; set; }
        public bool IsPlaying { get; }

        public void Play();
        public void Despawn();
    }
}