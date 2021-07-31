using _Scripts.Players;

namespace _Scripts.Players
{
    public class PlayerPointsChangedSignal
    {
        public int PlayerOnePoints { get;}
        public int PlayerTwoPoints { get;}

        public PlayerPointsChangedSignal(int playerOnePoints, int playerTwoPoints)
        {
            PlayerOnePoints = playerOnePoints;
            PlayerTwoPoints = playerTwoPoints;
        }
    }
}