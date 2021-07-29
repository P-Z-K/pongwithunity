using System;
using _Scripts.Root.GameSettings;
using _Scripts.Root.Global_Signals;
using UnityEngine;
using Zenject;

namespace _Scripts.Players
{
    public class PointsTracker
    {
        private readonly PlayerOne _playerOne;
        private readonly PlayerTwo _playerTwo;
        private readonly SignalBus _signalBus;
        private readonly GameSettings _gameSettings;

        public PointsTracker(PlayerOne playerOne, PlayerTwo playerTwo, SignalBus signalBus, GameSettings gameSettings)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            _signalBus = signalBus;
            _gameSettings = gameSettings;
        }

        public void DecideWhoGivePointTo(PlayerHole holeThatBallFallInto)
        {
            Player chosenPlayer = GetPlayerThatShouldGetThePoint(holeThatBallFallInto);
            chosenPlayer.Points++;

            if (chosenPlayer.Points >= _gameSettings._pointsToWin)
            {
                _signalBus.Fire<PlayerWonSignal>();
            }

            _signalBus.Fire(new PlayerPointsChangedSignal(_playerOne.Points, _playerTwo.Points));
        }

        public void ResetPoints()
        {
            _playerOne.Points = 0;
            _playerTwo.Points = 0;
            _signalBus.Fire(new PlayerPointsChangedSignal(_playerOne.Points, _playerTwo.Points));
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
    }
}