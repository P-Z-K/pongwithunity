using System;
using UnityEngine;

namespace _Scripts.UI
{
    [Serializable]
    public class CountdownTimerSettings
    {
        [Range(2, 5)] public int _delayBeforeBallStart;
    }
}