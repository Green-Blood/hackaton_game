using System;

namespace Sound_Game.Core
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
