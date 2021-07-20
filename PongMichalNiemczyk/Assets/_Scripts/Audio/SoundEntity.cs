using System;
using _Scripts.Utils;
using UnityEngine;
using Zenject;

namespace _Scripts.Audio
{
    public class SoundEntity : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private TagsSettings _tagsSettings;
        private Camera _mainCamera;

        [Inject]
        public void Construct(TagsSettings tagsSettings)
        {
            _tagsSettings = tagsSettings;
        }

        private void Awake()
        {
            _mainCamera = GameObject.FindWithTag(_tagsSettings.MainCameraTag).GetComponent<Camera>();
            SetUpZValue();
        }

        private void SetUpZValue()
        {
            Vector3 camPosition = _mainCamera.transform.position;
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

        private void Play()
        {
            Active = true;
            _audioSource.Play();
        }


        private void SetUpProperties(AudioClip audioClip, Vector3 newPosition)
        {
            Vector3 soundPosition = transform.position;
            soundPosition.Set(newPosition.x, newPosition.y, soundPosition.z);
            Clip = audioClip;
        }
        
        public class Pool : MonoMemoryPool<AudioClip, Vector3, SoundEntity>
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
}