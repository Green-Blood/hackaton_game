using Sound_Game.Game_End;
using UnityEngine;
using UnityEngine.UI;

namespace Sound_Game.Core
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private GameLevels gameLevels;
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private GameSound gameSound;
        [SerializeField] private GameCanvas gameCanvas;


        private StateMachine _stateMachine;
        private GameState _gameState;
        private ScoreSystem _scoreSystem;
        private LevelStarter _levelStarter;

        private void Awake()
        {
            _stateMachine = new StateMachine();
            _gameState = new GameState(gameLevels);
            _scoreSystem = new ScoreSystem(gameLevels);
            _levelStarter = new LevelStarter(gameCanvas.CheckButtons, gameSound, _scoreSystem, gameSettings);
            
            gameCanvas.Construct(_scoreSystem);
        }

        private void Start() => StartGame();
        private void StartGame() => _gameState.SetLevel(1);

        private void OnEnable()
        {
            _stateMachine.OnStateChange += OnStateChange;
            gameCanvas.HandMover.OnHandFinishedMoving += StartNextLevel;
            gameCanvas.HandMover.OnHandClicked += OnHandClicked;
            _gameState.OnLevelChange += OnLevelChange;
        }

        private void OnStateChange(State state)
        {
            if (state != State.NextGame) return;
            if (_gameState.CanStartNextLevel())
            {
                _gameState.SetNextLevel();
            }
            else
            {
                gameCanvas.ActivateEndPanel();
                gameCanvas.GameEndPanel.StartAnimation();
            }
        }

        private void StartNextLevel() => _stateMachine.ChangeState(State.NextGame);
        private void OnHandClicked(Button button) => gameSound.PlayClickFeedback();
        private void OnLevelChange(LevelSettings levelSettings) => _levelStarter.SetLevel(levelSettings);

        private void OnDisable()
        {
            _stateMachine.OnStateChange -= OnStateChange;
            _gameState.OnLevelChange -= OnLevelChange;
            gameCanvas.HandMover.OnHandFinishedMoving -= StartNextLevel;
            gameCanvas.HandMover.OnHandClicked -= OnHandClicked;
        }
    }
}