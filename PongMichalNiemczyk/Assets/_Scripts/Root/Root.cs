using _Scripts.Composite;
using Zenject;

namespace _Scripts.Root
{
    public class Root : IInitializable, ITickable, IFixedTickable
    {
        private readonly DiContainer _diContainer;
        private CompositeComponent _currentState;

        public Root(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void FixedTick()
        {
            _currentState?.FixedTick();
        }

        public void Initialize()
        {
            CreateNewState<StartStateFactory>();
        }

        public void Tick()
        {
            _currentState?.Tick();
        }

        private void ChangeStateTo(IFactory<CompositeComponent> factory)
        {
            _currentState?.Exit();
            _currentState = factory.Create();
            _currentState?.Enter();
        }

        public void CreateNewState<T>() where T : IFactory<CompositeComponent>
        {
            var factory = _diContainer.Instantiate<T>();
            ChangeStateTo(factory);
        }
    }
}