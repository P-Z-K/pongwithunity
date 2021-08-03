using _Scripts.Audio;
using _Scripts.Composite;

namespace _Scripts.Root
{
    public class SoundEntityManagerComponent : PrimitiveComponent
    {
        private readonly SoundEntityManager _soundEntityManager;

        public SoundEntityManagerComponent(SoundEntityManager soundEntityManager)
        {
            _soundEntityManager = soundEntityManager;
        }

        public override void Enter()
        {
            _soundEntityManager.SubscribeSignals();
        }

        public override void Tick()
        {
            _soundEntityManager.Tick();
        }

        public override void Exit()
        {
            _soundEntityManager.UnsubscribeSignals();
        }
    }
}