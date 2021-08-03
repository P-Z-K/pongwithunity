namespace _Scripts.Composite
{
    public interface IComponent
    {
        public void Enter();
        public void Tick();
        public void FixedTick();
        public void Exit();
    }
}