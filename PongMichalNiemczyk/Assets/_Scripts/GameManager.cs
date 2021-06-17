using System;
using UnityEngine;

namespace _Scripts
{
    public class GameManager : MonoBehaviour
    {
        public StateMachine<GameManager> StateMachine { get; private set; }

        private State<GameManager>[] _gameStates = {new StartState(), 
            new GameplayState(), new GameOverState()};
        
        private int _statesIndex = 0;

        // Testing purposes
        private bool _isButtonClicked = false;
        private float _delayDuration = 5f;
        private float _delayElapsedTime = 0f;

        private void Awake()
        {
            SetUpStateMachine();
        }

        private void OnEnable()
        {
            if (StateMachine == null)
                return;
            StateMachine.OnChangeState += LogState;
        }
        private void OnDisable()
        {
            if (StateMachine == null)
                return;
            StateMachine.OnChangeState -= LogState;
        }

        private void LogState(string prevState, string currState)
        {
            Debug.Log($"State changed from {prevState} to {currState}");
        }
        private void Update()
        {
            HandleStateChanging();
            StateMachine.Update();
            DelayClicks();
        }
        
        // Testing purposes
        private void DelayClicks()
        {
            _delayElapsedTime += Time.deltaTime;
            
            if (_delayElapsedTime >= _delayDuration)
            {
                _isButtonClicked = false;
                _delayElapsedTime = 0f;
            }
                
        }

        // Testing purposes
        private void HandleStateChanging()
        {
            if (Input.GetButtonDown("Jump") && !_isButtonClicked)
            {
                _isButtonClicked = true;
                
                // Choose the next state in the array,
                // go back to the start if necessary.
                _statesIndex = (_statesIndex + 1) % _gameStates.Length;
                StateMachine.ChangeState(_gameStates[_statesIndex]);
            }
        }

        private void SetUpStateMachine()
        {
            StateMachine = new StateMachine<GameManager>(this);
            // Load first state
            StateMachine.ChangeState(_gameStates[_statesIndex]);
        }
    }
}

