using System;
using UnityEngine;

namespace _Scripts
{
    public class Root : MonoBehaviour
    {
        private State<Root>[] TEST_gameStates;

        private State<Root> _currentState;
        
        private int TEST_statesIndex = 0;

        private void Awake()
        {
            LoadInitialState();
            TEST_SetUpStates();
        }

        private void Update()
        {
            _currentState.UpdateState();
            TEST_LoopBetweenStatesAtTrigger();
        }

        public void ChangeState(State<Root> newState) 
        {
            _currentState?.ExitState();
            
            _currentState = newState;
            
            _currentState?.EnterState();
        }

        private void TEST_LoopBetweenStatesAtTrigger()
        {
            if (Input.GetButtonDown("Jump"))
            {
                TEST_statesIndex = (TEST_statesIndex + 1) % TEST_gameStates.Length;
                TEST_GoToNextState();
            }
        }

        private void TEST_GoToNextState()
        {
            ChangeState(TEST_gameStates[TEST_statesIndex]);
        }

        private void TEST_SetUpStates()
        {
            TEST_gameStates = new State<Root>[] 
            {
                new StartState(this),
                new GameplayState(this), 
                new GameOverState(this)
            };
        }

        private void LoadInitialState()
        {
            _currentState = new StartState(this);
            _currentState.EnterState();
        }
    }
}