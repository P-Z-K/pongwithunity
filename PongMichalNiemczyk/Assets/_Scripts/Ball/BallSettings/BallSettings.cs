using System;
using UnityEngine;

namespace _Scripts.Ball
{
    [Serializable]
    public class BallSettings
    {
        [Range(2f, 25f)] public float _speed;
        [Range(0.5f, 2f)] public float _minimumVerticalMovement;
        [Range(0.5f, 2f)] public float _minimumHorizontalMovement;
        [Range(0.1f, 1f)] public float _randomDirectionBounceFactor;
        [Range(0.1f, 11f)] public float _maximumStartHorizontalDirection;
        [Range(0.1f, 5f)] public float _maximumStartVerticalDirection;
    }
}