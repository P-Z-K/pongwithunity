using UnityEngine;

namespace _Scripts.Players
{
    public class PlayerTwo : Player
    {
        public override HoleType HoleType
        {
            get => HoleType.PlayerTwo;
        }
    }
}