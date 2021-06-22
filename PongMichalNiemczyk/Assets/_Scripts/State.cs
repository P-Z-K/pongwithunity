namespace _Scripts
{
    public abstract class State<T>
    {
        protected T _owner;

        public State(T owner)
        {
            _owner = owner;
        }

        public abstract void EnterState();
        public abstract void UpdateState();
        public abstract void UpdatePhysicsState();
        public abstract void ExitState();
    }
}