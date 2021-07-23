using UnityEngine;
using Zenject;

namespace _Scripts.Audio
{
    public class SoundInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _soundClipPrefab;
        [SerializeField] private Transform _soundsWrapper;

        public override void InstallBindings()
        {
            Container.Bind<SoundEntityPooler>().AsSingle();

            Container.BindMemoryPool<SoundEntity, SoundEntityPool>()
                .WithInitialSize(3)
                .FromComponentInNewPrefab(_soundClipPrefab)
                .UnderTransform(_soundsWrapper);
        }

    }
}