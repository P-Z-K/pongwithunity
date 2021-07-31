using System.Collections.Generic;
using System.Linq;
using _Scripts.Ball;
using UnityEngine;
using Zenject;

namespace _Scripts.Audio
{
    public class SoundEntityManager
    {
        [Inject] private readonly List<SoundEntity> _soundEntities = new List<SoundEntity>();
        
        private readonly SoundEntityPool _soundEntityPool;
        private readonly SoundSettings _soundSettings;
        private readonly SignalBus _signalBus;


        public SoundEntityManager(SoundEntityPool soundEntityPool, SoundSettings soundSettings, SignalBus signalBus)
        {
            _soundEntityPool = soundEntityPool;
            _soundSettings = soundSettings;
            _signalBus = signalBus;
        }

        public void SubscribeSignals()
        {
            _signalBus.Subscribe<BallHitWallSignal>(PlayWallHit);
            _signalBus.Subscribe<BallHitPongBatSignal>(PlayPongBatHit);
        }

        public void UnsubscribeSignals()
        {
            _signalBus.Unsubscribe<BallHitWallSignal>(PlayWallHit);
            _signalBus.Unsubscribe<BallHitPongBatSignal>(PlayPongBatHit);
        }

        private void PlayPongBatHit(BallHitPongBatSignal obj)
        {
            Play(Sound.PongBatHit, obj.BallPosition);
        }

        private void PlayWallHit(BallHitWallSignal obj)
        {
            Play(Sound.WallHit, obj.BallPosition);
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
            soundEntity.Despawn();
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