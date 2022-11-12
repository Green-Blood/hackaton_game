using System;
using UnityEngine;

namespace Sound_Game
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] private StateMachine stateMachine;
        [SerializeField] private GameLevels gameLevels;

        private LevelSettings _currentLevel;
        public Action<LevelSettings> OnLevelChange;

        private int _currentLevelNumber;
        private void Awake()
        {
            SetLevel(1);
            stateMachine.OnStateChange += OnStateChange;
        }

        private void OnStateChange(State state)
        {
            if (state == State.NextGame)
            {
                SetLevel(_currentLevelNumber++);
            }
        }


        public void SetLevel(int levelNumber)
        {
            _currentLevel = gameLevels.levelSettings[levelNumber - 1];
            OnLevelChange?.Invoke(_currentLevel);
        }
    }
}