using System;
using UniRx;

namespace Sound_Game.Core
{
    public class LevelStarter
    {
        private readonly CheckButtons _checkButtons;
        private readonly GameSound _levelAudio;
        private readonly ScoreSystem _scoreSystem;
        private readonly GameSettings _gameSettings;

        public LevelStarter(CheckButtons checkButtons, GameSound levelAudio, ScoreSystem scoreSystem,
            GameSettings gameSettings)
        {
            _checkButtons = checkButtons;
            _levelAudio = levelAudio;
            _scoreSystem = scoreSystem;
            _gameSettings = gameSettings;
        }

        public void SetLevel(LevelSettings levelSettings)
        {
            _checkButtons.SetInteractable(false);
            _checkButtons.InitImages(levelSettings.levelImages, levelSettings.correctImageNumber);

            _levelAudio.ChangeLevelAudio(levelSettings.levelAudio);
            Observable.Timer(TimeSpan.FromSeconds(_gameSettings.levelSoundStartDelay))
                .Subscribe(l =>
                {
                    _levelAudio.PlayLevelAudio();
                    Observable.Timer(TimeSpan.FromSeconds(_levelAudio.GetLevelAudioLenght())).Subscribe((l1 =>
                    {
                        _checkButtons.SetInteractable(true);
                    }));
                });
        }
    }
}