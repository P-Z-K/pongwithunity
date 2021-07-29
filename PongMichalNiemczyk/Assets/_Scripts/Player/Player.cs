using UnityEngine;

namespace _Scripts.Players
{
    public abstract class Player
    {
        public int Points { get; private set; }

        public void AddPoint()
        {
            Points++;
        }
    }
}