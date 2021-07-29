using UnityEngine;
using Zenject;

namespace _Scripts.Players
{
    public class PlayerOneHole : PlayerHole
    {
        public override HoleType HoleType
        {
            get => HoleType.PlayerOne;
        }
    }
}