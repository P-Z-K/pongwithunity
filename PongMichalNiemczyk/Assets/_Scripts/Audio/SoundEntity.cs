using UnityEngine;

namespace _Scripts.Audio
{
    public class SoundEntity : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

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


        private void SetUpProperties(AudioClip audioClip, Vector3 position)
        {
            position.z = -10f;
            transform.position = position;
            Clip = audioClip;
        }
    }
}