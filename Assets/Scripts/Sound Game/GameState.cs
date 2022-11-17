using System;

namespace Sound_Game
{
    public class GameState 
    {
        private readonly GameLevels _gameLevels;
        public GameState(GameLevels gameLevels) => _gameLevels = gameLevels;

        private LevelSettings _currentLevel;
        public Action<LevelSettings> OnLevelChange;

        private int _currentLevelNumber;

        public bool CanStartNextLevel() => _gameLevels.levelSettings[_currentLevelNumber] != null;

        public void SetLevel(int levelNumber)
        {
            _currentLevelNumber = levelNumber;
            _currentLevel = _gameLevels.levelSettings[levelNumber - 1];
            OnLevelChange?.Invoke(_currentLevel);
        }

        public void SetNextLevel()
        {
            _currentLevelNumber++;
            _currentLevel = _gameLevels.levelSettings[_currentLevelNumber - 1];
            OnLevelChange?.Invoke(_currentLevel);
        }
    }
}