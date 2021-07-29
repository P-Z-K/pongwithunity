using UnityEngine;
using Zenject;

namespace _Scripts.Players
{
    public class PlayerTwoHole : PlayerHole
    {
        public override HoleType HoleType
        {
            get => HoleType.PlayerTwo;
        }
    }
}