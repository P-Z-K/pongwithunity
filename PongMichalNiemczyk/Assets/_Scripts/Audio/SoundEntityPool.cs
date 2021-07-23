using UnityEngine;
using Zenject;

namespace _Scripts.Audio
{
    public class SoundEntityPool : MonoMemoryPool<AudioClip, Vector3, SoundEntity>
    {
        protected override void Reinitialize(AudioClip audioClip, Vector3 position, SoundEntity item)
        {
            item.SetUpProperties(audioClip, position);
            item.Play();
        }

        protected override void OnDespawned(SoundEntity item)
        {
            item.Active = false;
            item.SetUpProperties(null, Vector3.zero);
        }
    }
}