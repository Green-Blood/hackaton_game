using System;
using UnityEngine;

namespace Sound_Game
{
    public class LevelStarter : IDisposable
    {
        private readonly GameState _gameState;
        private readonly CheckButtons _checkButtons;
        private readonly AudioSource _levelAudio;
        private readonly ScoreSystem _scoreSystem;

        public LevelStarter(GameState gameState, CheckButtons checkButtons, AudioSource levelAudio, ScoreSystem scoreSystem)
        {
            _gameState = gameState;
            _checkButtons = checkButtons;
            _levelAudio = levelAudio;
            _scoreSystem = scoreSystem;
            _gameState.OnLevelChange += OnLevelChange;
        }

        private void OnLevelChange(LevelSettings levelSettings) => SetLevel(levelSettings);

        public void SetLevel(LevelSettings levelSettings)
        {
            _checkButtons.InitImages(levelSettings.levelImages, levelSettings.correctImageNumber, () =>
            {
                _scoreSystem.IncreaseScore();
            });
            _levelAudio.clip = levelSettings.levelAudio;
            _levelAudio.Play();
        }

        public void Dispose() => _gameState.OnLevelChange -= OnLevelChange;
    }
}