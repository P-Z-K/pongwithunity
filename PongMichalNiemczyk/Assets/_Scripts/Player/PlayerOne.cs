using UnityEngine;

namespace _Scripts.Players
{
    public class PlayerOne : Player
    {
        public override HoleType HoleType
        {
            get => HoleType.PlayerOne;
        }
    }
}