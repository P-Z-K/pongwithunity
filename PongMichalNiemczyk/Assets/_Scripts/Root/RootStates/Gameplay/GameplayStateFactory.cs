using _Scripts.Composite;
using Zenject;

namespace _Scripts.Root
{
    public class GameplayStateFactory : IFactory<CompositeComponent>
    {
        private readonly DiContainer _diContainer;

        public GameplayStateFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public CompositeComponent Create()
        {
            var state = _diContainer.Instantiate<GameplayStateComposite>();

            state.AddChild(_diContainer.Resolve<GameplayMenuComponent>());
            state.AddChild(_diContainer.Resolve<ParticleEntityManagerComponent>());
            state.AddChild(_diContainer.Resolve<SoundEntityManagerComponent>());
            state.AddChild(_diContainer.Resolve<BallComponent>());
            state.AddChild(_diContainer.Resolve<PointsTrackerComponent>());
            state.AddChild(_diContainer.Resolve<PongBatComponent>());

            return state;
        }
    }
}