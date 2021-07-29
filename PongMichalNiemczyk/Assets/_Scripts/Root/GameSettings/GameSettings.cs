using System;
using UnityEngine;
using Zenject;

namespace _Scripts.Root.GameSettings
{
    [Serializable]
    public class GameSettings 
    {
        [Range(0, 20)] public int _pointsToWin;
    }
}