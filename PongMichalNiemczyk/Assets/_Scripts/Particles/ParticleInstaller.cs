using _Scripts.Particles.ParticleTypes;
using _Scripts.Particles.ParticleTypes.PongBatParticle;
using UnityEngine;
using Zenject;

namespace _Scripts.Particles
{
    public class ParticleInstaller : MonoInstaller
    {
        private ParticleSettings _particleSettings;

        [SerializeField] private Transform _pongBatHitParticlesWrapper;
        [SerializeField] private Transform _wallHitParticlesWrapper;

        [Inject]
        public void Construct(ParticleSettings particleSettings)
        {
            _particleSettings = particleSettings;
        }

        public override void InstallBindings()
        {
            Container.Bind<ParticleEntityManager>().AsSingle();

            Container.BindMemoryPool<PongBatHitParticleEntity, PongBatHitParticleEntityPool>()
                .WithInitialSize(4)
                .FromComponentInNewPrefab(_particleSettings._pongBatHitParticle)
                .UnderTransform(_pongBatHitParticlesWrapper);
            
            Container.BindMemoryPool<WallHitParticleEntity, WallHitParticleEntityPool>()
                .WithInitialSize(4)
                .FromComponentInNewPrefab(_particleSettings._wallHitParticle)
                .UnderTransform(_wallHitParticlesWrapper);
        }
    }
}