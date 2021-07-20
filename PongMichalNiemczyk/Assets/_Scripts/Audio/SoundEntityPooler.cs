using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace _Scripts.Audio
{
    public class SoundEntityPooler
    {
        [Inject] private readonly List<SoundEntity> _soundEntities = new List<SoundEntity>();
        
        private readonly SoundEntity.Pool _soundEntityPool;
        private readonly SoundSettings _soundSettings;


        public SoundEntityPooler(SoundEntity.Pool soundEntityPool, SoundSettings soundSettings)
        {
            _soundEntityPool = soundEntityPool;
            _soundSettings = soundSettings;
        }

        public void Update()
        {
            foreach (var soundEntity in _soundEntities.ToList())
            {
                if (!soundEntity.IsPlaying)
                {
                    ReturnAudioSourceManagerToPool(soundEntity);
                }
            }
        }

        private void ReturnAudioSourceManagerToPool(SoundEntity soundEntity)
        {
            _soundEntityPool.Despawn(soundEntity);
            _soundEntities.Remove(soundEntity);
        }

        private void Play(Sound sound, Vector3 position)
        {
            AudioClip audioClip = ChooseAudioClip(sound);

            _soundEntities.Add(_soundEntityPool.Spawn(audioClip, position));
        }

        private AudioClip ChooseAudioClip(Sound sound)
        {
            SoundSettings.SoundAudioClip[] clips = _soundSettings._sounds;

            foreach (var clip in clips)
            {
                if (clip._sound == sound)
                {
                    return GetRandomAudioClip(clip._audioClip);
                }
            }

            return null;
        }

        private AudioClip GetRandomAudioClip(AudioClip[] clips)
        {
            return clips[Random.Range(0, clips.Length)];
        }
    }
}