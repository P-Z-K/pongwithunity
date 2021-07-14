using System;
using UnityEngine;

namespace _Scripts.Ball
{
    [Serializable]
    public class BallSettings
    {
        [Range(2f, 25f)]  public float _speed;
        [Range(0.5f, 2f)] public float _minimumVerticalMovement;
        [Range(0.5f, 2f)] public float _minimumHorizontalMovement;
    }
}