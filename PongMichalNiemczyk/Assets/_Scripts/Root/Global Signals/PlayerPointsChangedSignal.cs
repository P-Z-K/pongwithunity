using _Scripts.Players;

namespace _Scripts.Root.Global_Signals
{
    public class PlayerPointsChangedSignal
    {
        public int PlayerOnePoints { get; private set; }
        public int PlayerTwoPoints { get; private set; }

        public PlayerPointsChangedSignal(int playerOnePoints, int playerTwoPoints)
        {
            PlayerOnePoints = playerOnePoints;
            PlayerTwoPoints = playerTwoPoints;
        }
    }
}