using _Scripts.Root;

namespace _Scripts.Ball
{
    public interface IBallFacade
    {
        public State<BallStateManager> CurrentState { get; }

        public void ChangeStateTo<T>() where T : State<BallStateManager>;
        public void Tick();
        public void FixedTick();
    }
}