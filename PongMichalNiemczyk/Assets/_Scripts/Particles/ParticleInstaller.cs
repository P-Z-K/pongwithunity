using _Scripts.Particles.ParticleTypes.PongBatParticle;
using Zenject;

namespace _Scripts.Particles
{
    public class ParticleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ParticleEntityManager>().AsSingle();
            
            // Container.BindMemoryPool<PongBatHitParticleEntity, PongBatHitParticleEntityPool>()
            //     .WithInitialSize(4)
            //     .FromComponentInNewPrefab()
            //     .UnderTransform()
        }
    }
}