using System.Collections.Generic;

namespace _Scripts.Composite
{
    public class CompositeComponent : IComponent
    {
        private readonly List<IComponent> _children = new List<IComponent>();

        public void AddChild(IComponent child)
        {
            _children.Add(child);
        }

        public virtual void Enter()
        {
            foreach (IComponent child in _children)
            {
                child.Enter();
            }
        }

        public virtual void Tick()
        {
            foreach (IComponent child in _children)
            {
                child.Tick();
            }
        }

        public virtual void FixedTick()
        {
            foreach (IComponent child in _children)
            {
                child.FixedTick();
            }
        }

        public virtual void Exit()
        {
            foreach (IComponent child in _children)
            {
                child.Exit();
            }
        }
    }
}