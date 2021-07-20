using System;
using UnityEngine;

namespace _Scripts.Audio
{
    public enum Sound
    {
        BallHit,
        PongBatHit,
    }
    
    [Serializable]
    public class SoundSettings
    {
        public SoundAudioClip[] _sounds;


        [Serializable]
        public class SoundAudioClip
        {
            public Sound _sound;
            public AudioClip[] _audioClip;
        }
    }

}