using System.Collections.Generic;
using System.Linq;
using _Scripts.Ball;
using UnityEngine;
using Zenject;

namespace _Scripts.Audio
{
    public class SoundEntityPooler
    {
        [Inject] private readonly List<SoundEntity> _soundEntities = new List<SoundEntity>();
        
        private readonly SoundEntityPool _soundEntityPool;
        private readonly SoundSettings _soundSettings;
        private readonly SignalBus _signalBus;


        public SoundEntityPooler(SoundEntityPool soundEntityPool, SoundSettings soundSettings, SignalBus signalBus)
        {
            _soundEntityPool = soundEntityPool;
            _soundSettings = soundSettings;
            _signalBus = signalBus;
            
            SubscribeSignals();
        }

        private void SubscribeSignals()
        {
            _signalBus.Subscribe<BallHitWallSignal>(x => Play(Sound.WallHit, x.BallPosition));
            _signalBus.Subscribe<BallHitPongBatSignal>(x => Play(Sound.PongBatHit, x.BallPosition));
        }

        public void Tick()
        {
            foreach (var soundEntity in _soundEntities.ToList())
            {
                if (!soundEntity.IsPlaying)
                {
                    ReturnSoundEntityToPool(soundEntity);
                }
            }
        }

        private void ReturnSoundEntityToPool(SoundEntity soundEntity)
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