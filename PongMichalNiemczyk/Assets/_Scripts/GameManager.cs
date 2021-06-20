using System;
using UnityEngine;

namespace _Scripts
{
    public class GameManager : MonoBehaviour
    {
        public StateMachine<GameManager> StateMachine { get; private set; }

        private State<GameManager>[] _gameStates = {new StartState(), 
            new GameplayState(), new GameOverState()};
        
        private int TEST_statesIndex = 0;

        private void Awake()
        {
            SetUpStateMachine();
        }

        private void Update()
        {
            TEST_LoopBetweenStatesAtTrigger();
            StateMachine.Update();
        }
        private void SetUpStateMachine()
        {
            StateMachine = new StateMachine<GameManager>(this);
            // Load first state
            StateMachine.ChangeState(_gameStates[TEST_statesIndex]);
        }

        private void TEST_LoopBetweenStatesAtTrigger()
        {
            if (Input.GetButtonDown("Jump"))
            {
                TEST_statesIndex = (TEST_statesIndex + 1) % _gameStates.Length;
                TEST_GoToNextState();
            }
        }

        private void TEST_GoToNextState()
        {
            StateMachine.ChangeState(_gameStates[TEST_statesIndex]);
        }
    }
}

