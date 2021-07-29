using System;
using UnityEngine;

namespace _Scripts.Players
{
    public class PointsTracker
    {
        private readonly PlayerOne _playerOne;
        private readonly PlayerTwo _playerTwo;

        public PointsTracker(PlayerOne playerOne, PlayerTwo playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
        }

        public void DecideWhoGivePointTo(HoleType holeThatBallFallInto)
        {
            Player chosenPlayer = GetPlayerThatShouldGetThePoint(holeThatBallFallInto);
            chosenPlayer.AddPoint();
            
            Debug.Log(
                $"Player One: {_playerOne.Points}\n" +
                $"Player Two: {_playerTwo.Points}\n"
                );
        }

        private Player GetPlayerThatShouldGetThePoint(HoleType type)
        {
            switch (type)
            {
                case HoleType.PlayerOne:
                    return _playerTwo;
                case HoleType.PlayerTwo:
                    return _playerOne;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}