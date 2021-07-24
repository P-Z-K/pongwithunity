using System;
using UnityEngine;
using Zenject;

namespace _Scripts
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private KeyCode _leftMoveBind;
        [SerializeField] private KeyCode _rightMoveBind;

        public float HorizontalMove { get; private set; }

        public void Tick()
        {
            HorizontalMove = 0f;

            if (Input.GetKey(_leftMoveBind))
            {
                HorizontalMove = -1f;
            }
            else if (Input.GetKey(_rightMoveBind))
            {
                HorizontalMove = 1f;
            }
        }
    }
}