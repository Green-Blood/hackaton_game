using System;

namespace Sound_Game
{
    public class ScoreSystem
    {
        private int _currentScore;
        public Action OnScoreChanged;
        public void IncreaseScore()
        {
            _currentScore++;
            OnScoreChanged?.Invoke();
        }

        public int GetCurrentScore()
        {
            return _currentScore;
        }
    }
}