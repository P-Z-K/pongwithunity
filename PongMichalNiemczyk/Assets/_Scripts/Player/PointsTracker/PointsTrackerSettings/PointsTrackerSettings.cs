using System;
using UnityEngine;

namespace _Scripts.Players
{
    [Serializable]
    public class PointsTrackerSettings
    {
        [Range(1, 20)] public int _pointsToWin;
    }
}