using _Scripts.Composite;
using Zenject;

namespace _Scripts.Root
{
    public class StartStateFactory : IFactory<CompositeComponent>
    {
        private readonly DiContainer _diContainer;

        public StartStateFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public CompositeComponent Create()
        {
            var state = _diContainer.Instantiate<StartStateComposite>();

            state.AddChild(_diContainer.Resolve<StartMenuComponent>());

            return state;
        }
    }
}