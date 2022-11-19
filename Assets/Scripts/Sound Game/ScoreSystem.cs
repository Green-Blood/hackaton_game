using System;
using Sound_Game.Core;

namespace Sound_Game
{
    public class ScoreSystem
    {
        private readonly GameLevels _gameLevels;

        public ScoreSystem(GameLevels gameLevels)
        {
            _gameLevels = gameLevels;
        }
        private int _currentScore;
        public Action OnScoreChanged;
        public void IncreaseScore()
        {
            _currentScore++;
            OnScoreChanged?.Invoke();
        }
        public int GetMaxScore() => _gameLevels.levelSettings.Length;
        public int GetCurrentScore() => _currentScore;
    }
}