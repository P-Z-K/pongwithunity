using System;
using _Scripts.Root.Global_Signals;
using Zenject;

namespace _Scripts.Players
{
    public class PointsTracker
    {
        private readonly PlayerOne _playerOne;
        private readonly PlayerTwo _playerTwo;
        private readonly SignalBus _signalBus;
        private readonly PointsTrackerSettings _pointsTrackerSettings;

        public PointsTracker(PlayerOne playerOne, PlayerTwo playerTwo, SignalBus signalBus, PointsTrackerSettings pointsTrackerSettings)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            _signalBus = signalBus;
            _pointsTrackerSettings = pointsTrackerSettings;
        }

        public void DecideWhoGivePointTo(PlayerHole holeThatBallFallInto)
        {
            Player chosenPlayer = GetPlayerThatShouldGetThePoint(holeThatBallFallInto);
            chosenPlayer.Points++;

            _signalBus.Fire(new PlayerPointsChangedSignal(_playerOne.Points, _playerTwo.Points));

            if (chosenPlayer.Points >= _pointsTrackerSettings._pointsToWin)
            {
                _signalBus.Fire<PlayerWonSignal>();
            }
        }

        private Player GetPlayerThatShouldGetThePoint(PlayerHole playerHole)
        {
            switch (playerHole.HoleType)
            {
                case HoleType.PlayerOne: return _playerTwo;
                case HoleType.PlayerTwo: return _playerOne;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ResetPoints()
        {
            _playerOne.Points = 0;
            _playerTwo.Points = 0;
            _signalBus.Fire(new PlayerPointsChangedSignal(_playerOne.Points, _playerTwo.Points));
        }
    }
}