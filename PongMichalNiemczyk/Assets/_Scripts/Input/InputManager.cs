using System;
using UnityEngine;
using Zenject;

namespace _Scripts
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private KeyCode _leftMoveBind;
        [SerializeField] private KeyCode _rightMoveBind;

        private float _horizontalMove;

        public float GetHorizontalMove()
        {
            return _horizontalMove;
        }

        private void Update()
        {
            _horizontalMove = 0f;
            
            if (Input.GetKey(_leftMoveBind))
            {
                _horizontalMove = -1f;
            }
            else if (Input.GetKey(_rightMoveBind))
            {
                _horizontalMove = 1f;
            }
        }
    }
}