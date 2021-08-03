namespace _Scripts.Composite
{
    public abstract class CompositeComponent : IComponent
    {
        public abstract void AddChild(IComponent child);

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
    }
}