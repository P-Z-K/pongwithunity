namespace _Scripts.Root
{
    public abstract class State<T>
    {
        protected T _owner;

        public State(T owner)
        {
            _owner = owner;
        }

        public abstract void EnterState();
        public abstract void Tick();
        public abstract void FixedTick();
        public abstract void ExitState();
    }
}