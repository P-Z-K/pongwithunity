using UnityEngine;
using Zenject;

namespace _Scripts.Particles
{
    public class ParticleEntityPool<T> : MonoMemoryPool<Vector3, T>
    where T : Component, IParticleEntity
    {
        protected override void Reinitialize(Vector3 position, T item)
        {
            item.Position = position;
            item.Active = true;
            item.Play();
        }

        protected override void OnDespawned(T item)
        {
            item.Position = Vector3.zero;
            item.Active = false;
        }
    }
}