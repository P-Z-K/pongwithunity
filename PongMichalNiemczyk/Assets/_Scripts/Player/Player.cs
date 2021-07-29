using UnityEngine;

namespace _Scripts.Players
{
    public enum HoleType
    {
        PlayerOne,
        PlayerTwo,
    }
    public abstract class Player : MonoBehaviour
    {
        public int Points { get; private set; }

        public abstract HoleType HoleType
        {
            get;
        }

        public void AddPoint()
        {
            Points++;
        }
    }
}