using _Scripts.Composite;
using Zenject;

namespace _Scripts.Root
{
    public class GameOverStateFactory : IFactory<CompositeComponent>
    {
        private readonly DiContainer _diContainer;

        public GameOverStateFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public CompositeComponent Create()
        {
            var state = _diContainer.Instantiate<GameOverStateComposite>();

            state.AddChild(_diContainer.Instantiate<GameOverMenuComponent>());

            return state;
        }
    }
}