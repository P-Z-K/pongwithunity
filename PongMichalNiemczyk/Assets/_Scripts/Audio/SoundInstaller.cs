using UnityEngine;
using Zenject;

namespace _Scripts.Audio
{
    public class SoundInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _soundClipPrefab;

        public override void InstallBindings()
        {
            Container.Bind<SoundEntityPooler>().AsSingle();

            Container.BindMemoryPool<SoundEntity, SoundEntity.Pool>()
                .WithInitialSize(3)
                .FromComponentInNewPrefab(_soundClipPrefab)
                .UnderTransformGroup("Sounds");
        }

    }
}