using _Scripts.Composite;
using _Scripts.Particles;

namespace _Scripts.Root
{
    public class ParticleEntityManagerComponent : PrimitiveComponent
    {
        private readonly ParticleEntityManager _particleEntityManager;

        public ParticleEntityManagerComponent(ParticleEntityManager particleEntityManager)
        {
            _particleEntityManager = particleEntityManager;
        }

        public override void Enter()
        {
            _particleEntityManager.SubscribeSignals();
        }

        public override void Tick()
        {
            _particleEntityManager.Tick();
        }

        public override void Exit()
        {
            _particleEntityManager.UnsubscribeSignals();
        }
    }
}