using _Scripts.Particles.ParticleTypes;
using _Scripts.Particles.ParticleTypes.BallParticle;
using _Scripts.Particles.ParticleTypes.PongBatParticle;
using UnityEngine;
using Zenject;

namespace _Scripts.Particles
{
    public class ParticleInstaller : MonoInstaller
    {
        [SerializeField] private ParticleSettings _particleSettings;

        [SerializeField] private Transform _pongBatHitParticlesWrapper;
        [SerializeField] private Transform _wallHitParticlesWrapper;
        [SerializeField] private Transform _ballFallInPlayerHoleParticlesWrapper;

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
            
            Container.BindMemoryPool<BallFallIntoPlayerHoleParticleEntity, BallFallIntoPlayerHoleParticleEntityPool>()
                .WithInitialSize(2)
                .FromComponentInNewPrefab(_particleSettings._ballFallInPlayerHoleParticle)
                .UnderTransform(_ballFallInPlayerHoleParticlesWrapper);
        }
    }
}