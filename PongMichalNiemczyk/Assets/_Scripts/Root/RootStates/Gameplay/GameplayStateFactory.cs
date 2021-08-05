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

            state.AddChild(_diContainer.Instantiate<GameplayMenuComponent>());
            state.AddChild(_diContainer.Instantiate<PlayerPointsComponent>());
            state.AddChild(_diContainer.Instantiate<ParticleEntityManagerComponent>());
            state.AddChild(_diContainer.Instantiate<SoundEntityManagerComponent>());
            state.AddChild(_diContainer.Instantiate<BallComponent>());
            state.AddChild(_diContainer.Instantiate<PointsTrackerComponent>());
            state.AddChild(_diContainer.Instantiate<PongBatComponent>());

            return state;
        }
    }
}