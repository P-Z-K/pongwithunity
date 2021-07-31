using System;
using _Scripts.Utils;
using UnityEngine;
using Zenject;

namespace _Scripts.Audio
{
    public class SoundEntity : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private SoundEntityPool _pool;
        private CameraRefHolder _cameraRefHolder;

        [Inject]
        public void Construct(CameraRefHolder cameraRefHolder, SoundEntityPool pool)
        {
            _cameraRefHolder = cameraRefHolder;
            _pool = pool;

            SetUpZValue();
        }
        
        public void Despawn()
        {
            _pool.Despawn(this);
        }

        private void SetUpZValue()
        {
            Vector3 camPosition = _cameraRefHolder.MainCamera.transform.position;
            Vector3 soundPosition = gameObject.transform.position;
            soundPosition.Set(soundPosition.x, soundPosition.y, camPosition.z);
        }

        public AudioClip Clip
        {
            get => _audioSource.clip;
            set => _audioSource.clip = value;
        }

        public bool Active
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }

        public bool IsPlaying
        {
            get => _audioSource.isPlaying;
        }

        public void Play()
        {
            Active = true;
            _audioSource.Play();
        }


        public void SetUpProperties(AudioClip audioClip, Vector3 newPosition)
        {
            Vector3 soundPosition = transform.position;
            soundPosition.Set(newPosition.x, newPosition.y, soundPosition.z);
            Clip = audioClip;
        }
    }
}