namespace _Scripts.Composite
{
    public abstract class CompositeComponent : IComponent
    {
        public virtual void Enter()
        {
        }

        public virtual void Tick()
        {
        }

        public virtual void FixedTick()
        {
        }

        public virtual void Exit()
        {
        }

        public abstract void AddChild(IComponent child);
    }
}