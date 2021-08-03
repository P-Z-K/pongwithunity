namespace _Scripts.Players
{
    public class PlayerPointsChangedSignal
    {
        public PlayerPointsChangedSignal(int playerOnePoints, int playerTwoPoints)
        {
            PlayerOnePoints = playerOnePoints;
            PlayerTwoPoints = playerTwoPoints;
        }

        public int PlayerOnePoints { get; }
        public int PlayerTwoPoints { get; }
    }
}