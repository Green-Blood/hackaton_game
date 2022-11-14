using System;

namespace Sound_Game
{
    public class StateMachine 
    {
        public Action<State> OnStateChange;

        private State _currentGameState;

        public void ChangeState(State state)
        {
            _currentGameState = state;
            OnStateChange?.Invoke(_currentGameState);
        }
    }
}
