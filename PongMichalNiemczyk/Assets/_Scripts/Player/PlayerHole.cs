using UnityEngine;

namespace _Scripts.Players
{
    public enum HoleType
    {
        PlayerOne, PlayerTwo
    }

    public abstract class PlayerHole : MonoBehaviour
    {
        public abstract HoleType HoleType { get; }
    }
}