using System;
using UnityEngine;

namespace Sound_Game
{
    public class StateMachine : MonoBehaviour
    {
        public Action<State> OnStateChange;

        private State _currentGameState;

        private void Awake()
        {
            ChangeState(State.Start);
        }

        public void ChangeState(State state)
        {
            _currentGameState = state;
            OnStateChange?.Invoke(_currentGameState);
        }
    }
}
